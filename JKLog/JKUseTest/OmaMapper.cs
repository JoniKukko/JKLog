using JKLog.Interface;
using System;



namespace JKUseTest
{
    [JKMapper]
    public class OmaMapper : IWritable
    {
        public void WriteEntry(IEntry entry)
        {
            Console.WriteLine("OMASTA MAPPERISTA: " + entry.Message);
        }
    }
}
