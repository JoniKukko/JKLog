using JKLog.Interface;
using JKLog.Util;
using System;
using System.Collections.Generic;



namespace JKLog
{
    public class JKWriter : IDisposable
    {
        private List<IWritable> mappers;



        #region Constructors

        /// <summary>
        /// Initializes empty writer instance
        /// </summary>
        public JKWriter()
        {
            this.mappers = new List<IWritable>();
        }



        /// <summary>
        /// Initializes writer instance with one IWritable.
        /// </summary>
        /// <param name="writable">IWritable to use within writer.</param>
        public JKWriter(IWritable writable)
        {
            this.mappers = new List<IWritable>();
            this.mappers.Add(writable);
        }



        /// <summary>
        /// Initializes writer instance with multiple IWritables.
        /// </summary>
        /// <param name="writables">List of IWritables to use within writer.</param>
        public JKWriter(List<IWritable> writables)
        {
            this.mappers = writables;
        }

        #endregion



        #region Attach/Detach

        /// <summary>
        /// Adds IWritable to writer instance.
        /// </summary>
        /// <param name="writable">IWritable to add to the writer instance.</param>
        public void Attach(IWritable writable)
        {
            this.mappers.Add(writable);
        }



        /// <summary>
        /// Removes IWritables from writer instance by given IWritable type and then returns the count of removed IWritables.
        /// </summary>
        /// <param name="writable">Type of the IWritable to remove</param>
        /// <returns>Count of removed IWritables</returns>
        public int Detach(Type writable)
        {
            int count = this.mappers.Count;
            this.mappers.RemoveAll(item => item.GetType() == writable);
            return count - this.mappers.Count;
        }

        #endregion



        #region WriteEntry

        /// <summary>
        /// Writes a new entry to all attached IWritables.
        /// </summary>
        /// <param name="entry">New IEntry to write.</param>
        public void WriteEntry(IEntry entry)
        {
            this.mappers.ForEach(mapper => mapper.WriteEntry(entry));
        }

        #endregion



        #region IDisposable

        /// <summary>
        /// Disposes disposable mappers safely.
        /// </summary>
        public void Dispose()
        {
            MapperManager.DisposeMapper(this.mappers);
            this.mappers = null;
        }

        #endregion
    }
}
