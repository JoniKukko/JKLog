using JKLog.Interface;
using System.Collections.Generic;
using System;

namespace JKLog
{
    class JKReader : IReadable
    {
        private IReadable reader;

        public IEntry Peek()
        {
            throw new NotImplementedException();
        }

        public IEntry PeekAt(int id)
        {
            throw new NotImplementedException();
        }

        public List<IEntry> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IEntry ReadAt(int id)
        {
            throw new NotImplementedException();
        }

        public IEntry ReadNext()
        {
            throw new NotImplementedException();
        }

        public IEntry ReadPrevious()
        {
            throw new NotImplementedException();
        }

        public List<IEntry> ReadToEnd()
        {
            throw new NotImplementedException();
        }

        public List<IEntry> ReadToStart()
        {
            throw new NotImplementedException();
        }
    }
}
