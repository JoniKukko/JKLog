using System.Collections.Generic;



namespace JKLog.Interface
{
    public interface IReadable
    {
        IEnumerator<IEntry> Entries { get; }
    }
}
