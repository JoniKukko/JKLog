using JKLog.Model;
using System;



namespace JKLog.Interface
{
    public interface IEntry
    {
        DateTime Timestamp { get; set; }
        EntryType Type { get; set; }
        string Message { get; set; }
        object Context { get; set; }
        string Category { get; set; }
        string Caller { get; set; }
        string FilePath { get; set; }
        int LineNumber { get; set; }
    }
}
