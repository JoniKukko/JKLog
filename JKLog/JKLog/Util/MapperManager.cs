using JKLog.Configuration;
using JKLog.Interface;
using JKLog.Mapper;
using System;
using System.Collections.Generic;



namespace JKLog.Util
{
    internal static class MapperManager
    {
        private static List<IWritable> defaultWritables = null;
        private static List<IReadable> defaultReadables = null;
        private static List<IDisposable> defaultDisposables = null;



        #region Create and Dispose default mappers.

        /// <summary>
        /// Returns list of writable mappers parsed from app.config. If there is none then JKConsole is used by default.
        /// </summary>
        /// <returns>List of writable mappers.</returns>
        public static List<IWritable> GetDefaultWritables()
        {
            // if null, then parse default mappers from app.config
            if (defaultWritables == null)
                CreateDefaultMappers();

            // if there is none then add default JKConsole mapper.
            if (defaultWritables.Count == 0)
                defaultWritables.Add(new JKConsole());

            return defaultWritables;
        }



        public static IReadable GetDefaultReadable(Type defaultMapperType)
        {
            if (defaultReadables == null)
                CreateDefaultMappers();

            foreach (IReadable readable in defaultReadables)
                if (defaultMapperType == readable.GetType())
                    return readable;

            return null;
        }



        /// <summary>
        /// Disposes all instances of default mappers.
        /// </summary>
        public static void DisposeDefaultMappers()
        {
            // if null, then there is no default mappers used at all
            if (defaultDisposables != null)
                defaultDisposables.ForEach(item => item.Dispose());
        }



        /// <summary>
        /// Turns mapper names from ConfigurationMapper to list of defaultWritables, defaultReadables and defaultDisposables.
        /// </summary>
        private static void CreateDefaultMappers()
        {
            defaultWritables = new List<IWritable>();
            defaultReadables = new List<IReadable>();
            defaultDisposables = new List<IDisposable>();


            foreach (string mapperName in ConfigurationManager.GetRegisteredMapperNames())
            {
                // sallii käytön myös muista namespacesta
                Type mapperType = Type.GetType(mapperName);

                // jos mapperia ei löydy niin etsitään sitä omasta namespacesta
                if (mapperType == null)
                    mapperType = Type.GetType("JKLog.Mapper." + mapperName);


                if (mapperType != null)
                {
                    object instance = Activator.CreateInstance(mapperType);

                    IWritable writableInstance = instance as IWritable;
                    if (writableInstance != null)
                        defaultWritables.Add(writableInstance);

                    IReadable readableInstance = instance as IReadable;
                    if (readableInstance != null)
                        defaultReadables.Add(readableInstance);

                    IDisposable disposableInstance = instance as IDisposable;
                    if (disposableInstance != null)
                        defaultDisposables.Add(disposableInstance);
                }
            }
        }

        #endregion



        #region DisposeMappers overloads

        /// <summary>
        /// Disposes all disposable mappers from list of writables.
        /// </summary>
        /// <param name="mappers">List of writable mappers.</param>
        public static void DisposeMappers(List<IWritable> mappers)
        {
            foreach (IWritable mapper in mappers)
            {
                IDisposable disposable = mapper as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
        }



        /// <summary>
        /// Disposes all disposable mappers from list of readables.
        /// </summary>
        /// <param name="mappers">List of readable mappers.</param>
        public static void DisposeMappers(List<IReadable> mappers)
        {
            foreach (IReadable mapper in mappers)
            {
                IDisposable disposable = mapper as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
        }



        /// <summary>
        /// Disposes all from list of disposables.
        /// </summary>
        /// <param name="mappers">List of disposable mappers.</param>
        public static void DisposeMappers(List<IDisposable> mappers)
        {
            mappers.ForEach(mapper => mapper.Dispose());
        }

        #endregion



        #region DisposeMapper overloads

        /// <summary>
        /// Disposes writable mapper if possible.
        /// </summary>
        /// <param name="mapper">Writable mapper.</param>
        public static void DisposeMapper(IWritable mapper)
        {
            IDisposable disposable = mapper as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }



        /// <summary>
        /// Disposes readable mapper if possible.
        /// </summary>
        /// <param name="mapper">Readable mapper.</param>
        public static void DisposeMapper(IReadable mapper)
        {
            IDisposable disposable = mapper as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }



        /// <summary>
        /// Disposes a disposable mapper.
        /// </summary>
        /// <param name="mapper">Disposable mapper</param>
        public static void DisposeMapper(IDisposable mapper)
        {
            mapper.Dispose();
        }

        #endregion
    }
}
