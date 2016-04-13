using JKLog.Interface;
using System.Collections.Generic;



namespace JKLog.Mapper
{
    [JKMapper]
    public class Managed : IWritable, IReadable
    {
        private List<IEntry> entries = new List<IEntry>();

        public IEnumerator<IEntry> Entries
        {
            get
            {
                return this.entries.GetEnumerator();
            }
        }



        public void WriteEntry(IEntry entry)
        {
            this.entries.Add(entry);
        }
    }
}
