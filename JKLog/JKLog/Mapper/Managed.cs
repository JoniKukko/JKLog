using JKLog.Interface;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace JKLog.Mapper
{
    public class Managed : IWritable, IReadable
    {
        private List<IEntry> entries = new List<IEntry>();

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

        public void WriteEntry(IEntry entry)
        {
            this.entries.Add(entry);
        }
    }
}
