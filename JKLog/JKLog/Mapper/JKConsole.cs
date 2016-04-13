using JKLog.Interface;
using System;
using System.Collections.Generic;



namespace JKLog.Mapper
{
    [JKMapper]
    public class JKConsole : IWritable, IConfigurable
    {
        private Dictionary<string, string> configuration;
        public Dictionary<string, string> Configuration
        {
            set
            {
                // set can be done only once
                if (this.configuration == null)
                    this.configuration = value;
            }
            private get
            {
                if (this.configuration == null)
                    this.configuration = new Dictionary<string, string>();
                return this.configuration;
            }
        }
    
        

        /// <summary>
        /// Writes entry to console
        /// </summary>
        /// <param name="entry">Entry to write.</param>
        public void WriteEntry(IEntry entry)
        {
            // Haetaan app.configista verbose asetus, default on true.
            string conf;
            if (!this.Configuration.TryGetValue("verbose", out conf))
                conf = "true";

            // päätetään kuinka paljon puhutaan.
            if (conf != "false")
                Console.WriteLine(string.Format(
                    "{0} {1} {2}: {3} {4} in {5}:{6}:{7}",
                    entry.Timestamp, entry.Type, entry.Category, entry.Message, entry.Context, entry.FilePath, entry.Caller, entry.LineNumber
                    ));
            else
                Console.WriteLine(string.Format(
                    "{0} {1}: {2} {3}",
                    entry.Type, entry.Category, entry.Message, entry.Context
                    ));
        }
    }
}
