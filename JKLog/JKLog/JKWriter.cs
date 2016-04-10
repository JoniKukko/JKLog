using JKLog.Interface;
using JKLog.Util;
using System;
using System.Collections.Generic;



namespace JKLog
{
    public class JKWriter : IWritable, IDisposable
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
        /// Initializes writer instance with or without default IWritables.
        /// </summary>
        /// <param name="loadDefaultMappers">Decides if default IWritables are loaded or not.</param>
        public JKWriter(Boolean loadDefaultMappers)
        {
            if (loadDefaultMappers)
                this.mappers = MapperManager.GetDefaultMappers();
            else
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



        #region IWritable

        /// <summary>
        /// Writes a new entry to all attached IWritables.
        /// </summary>
        /// <param name="entry">New IEntry to write.</param>
        public void WriteEntry(IEntry entry)
        {
            this.mappers.ForEach(item => item.WriteEntry(entry));
        }

        #endregion



        #region IDisposable

        public void Dispose()
        {
            MapperManager.DisposeMappers(this.mappers);
        }

        #endregion
    }
}
