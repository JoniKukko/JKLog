using JKLog.Interface;
using System.Collections.Generic;



namespace JKLog.Mapper
{
    [JKMapper]
    public class Managed : IWritable, IReadable
    {
        /// <summary>
        /// IReadable
        /// </summary>
        private List<IEntry> entries = new List<IEntry>();
        public IEnumerator<IEntry> Entries
        {
            get
            {
                return this.entries.GetEnumerator();
            }
        }
        

        /// <summary>
        /// Writes entry to in memory list.
        /// </summary>
        /// <param name="entry">Entry to write.</param>
        public void WriteEntry(IEntry entry)
        {
            this.entries.Add(entry);
        }
    }
}
