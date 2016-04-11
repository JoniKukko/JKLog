using JKLog.Interface;
using System;
using System.Runtime.CompilerServices;



namespace JKLog.Model
{
    public class Entry : IEntry
    {
        public DateTime Timestamp { get; set; }
        public EntryType Type { get; set; }
        public string Message { get; set; }
        public object Context { get; set; }
        public string Category { get; set; }
        public string Caller { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }




        /// <summary>
        /// Creates a new Entry with every value possible.
        /// </summary>
        /// <param name="type">One of the EntryType values.</param>
        /// <param name="message">Message to write.</param>
        /// <param name="context">Context to write with message.</param>
        /// <param name="category">Witch category (if any) this message belongs to.</param>
        /// <param name="caller">This is an automatic [CallerMemberName] parameter.</param>
        /// <param name="filePath">This is an automatic [CallerFilePath] parameter.</param>
        /// <param name="lineNumber">This is an automatic [CallerLineNumber] parameter.</param>
        public Entry(EntryType type, string message, object context, string category, [CallerMemberName] string caller = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            this.Timestamp = DateTime.Now;
            this.Type = type;
            this.Message = message;
            this.Context = context;
            this.Category = (category == null) ? "None" : category;
            this.Caller = caller;
            this.FilePath = filePath;
            this.LineNumber = lineNumber;
        }
    }
}
