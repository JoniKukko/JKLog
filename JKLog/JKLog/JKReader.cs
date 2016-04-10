using JKLog.Interface;
using JKLog.Util;
using System;
using System.Collections;
using System.Collections.Generic;



namespace JKLog
{
    public class JKReader : IEnumerable<IEntry>, IDisposable
    {
        private IReadable mapper;



        public JKReader(IReadable mapper)
        {
            this.mapper = mapper;
        }



        #region IEnumerable

        public IEnumerator<IEntry> GetEnumerator()
        {
            return mapper.Entries;
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion



        #region IDisposable

        public void Dispose()
        {
            MapperManager.DisposeMapper(this.mapper);
        }

        #endregion
    }
}
