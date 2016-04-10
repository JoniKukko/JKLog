using JKLog.Configuration;
using JKLog.Interface;
using System;



namespace JKLog.Mapper
{
    public class JKConsole : IWritable
    {
        private bool verbose;



        public JKConsole()
        {
            string verboseString = ConfigurationManager.GetValue(typeof(JKConsole), "verbose");
            this.verbose = (verboseString != "false");
        }



        public void WriteEntry(IEntry entry)
        {
            if (this.verbose)
                this.Verbose(entry);
            else
                this.Simple(entry);
        }



        private void Simple(IEntry entry)
        {
            Console.WriteLine(string.Format(
                "{0} {1}: {2} {3}",
                entry.Type, entry.Category, entry.Message, entry.Context
                ));
        }



        private void Verbose(IEntry entry)
        {
            Console.WriteLine(string.Format(
                "{0} {1} {2}: {3} {4} in {5}:{6}:{7}",
                entry.Timestamp, entry.Type, entry.Category, entry.Message, entry.Context, entry.FilePath, entry.Caller, entry.LineNumber
                ));
        }
    }
}
