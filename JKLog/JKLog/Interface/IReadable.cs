using System.Collections.Generic;

namespace JKLog.Interface
{
    interface IReadable
    {
        List<IEntry> ReadToStart();
        List<IEntry> ReadToEnd();
        List<IEntry> ReadAll();

        IEntry ReadPrevious();
        IEntry ReadAt(int id);
        IEntry ReadNext();

        IEntry PeekAt(int id);
        IEntry Peek();
    }
}
