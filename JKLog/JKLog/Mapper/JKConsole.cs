using JKLog.Interface;
using System;
using System.Collections.Generic;



namespace JKLog.Mapper
{
    [JKMapper]
    public class JKConsole : IWritable, IConfigurable
    {
        private Dictionary<string, string> configuration = new Dictionary<string, string>();
        public Dictionary<string, string> Configuration
        {
            set
            {
                this.configuration = value;
            }
        }
        

        public void WriteEntry(IEntry entry)
        {
            string conf;
            if (!this.configuration.TryGetValue("verbose", out conf))
                conf = "true";


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
