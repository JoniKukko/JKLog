using System;
using JKLog.Interface;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;



namespace JKLog.Mapper
{
    [JKMapper]
    public class WindowsEvent : IWritable, IConfigurable
    {
        private Dictionary<string, string> configuration = new Dictionary<string, string>();
        public Dictionary<string, string> Configuration
        {
            set
            {
                if (this.configuration == null)
                    this.configuration = value;
            }
            private get
            {
                return this.configuration;
            }
        }


        private string source;
        private string Source
        {
            get
            {
                if (this.source == null)
                    if (!this.Configuration.TryGetValue("source", out this.source))
                        this.source = "JKLog";

                return this.source;
            }
        }

        public void WriteEntry(IEntry entry)
        {
            if (entry.Category != "JKLog" && (entry.Context as Type) != typeof(WindowsEvent))
            {
                try
                {
                    // if there is a match between entry type and windows type
                    EventLogEntryType type = EventLogEntryType.Information;
                    if (Enum.IsDefined(typeof(EventLogEntryType), (int)entry.Type))
                        type = (EventLogEntryType)entry.Type;

                    // context to byte array
                    byte[] toBytes = new byte[] { };
                    if (entry.Context != null)
                        toBytes = Encoding.ASCII.GetBytes(entry.Context.ToString());

                    EventLog.WriteEntry(this.Source, entry.Message, type, (int)entry.Type, (short)entry.Type, toBytes);
                }
                catch (Exception)
                {
                    JKLogger.FailureAudit("Failed to open Windows Event source. Source is not registered, configured or there is an internal failure in WindowsEvent mapper.", typeof(WindowsEvent), "JKLog");
                }
            }
        }



        public void RegisterSource()
        {
            try
            {
                if (!EventLog.SourceExists(this.Source))
                {
                    EventLog.CreateEventSource(this.Source, this.Source);
                    JKLogger.SuccessAudit("Windows Event source \"" + this.Source + "\" is created. Restart the application to allow it to be registered.", typeof(WindowsEvent), "JKLog");
                    return;
                }
            }
            catch (Exception)
            {
                JKLogger.FailureAudit("Failed to create Windows Event source. Call RegisterSource() while running as Administrator.", typeof(WindowsEvent), "JKLog");
            }
        }
    }
}
