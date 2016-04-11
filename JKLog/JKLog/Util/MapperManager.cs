using JKLog.Configuration;
using JKLog.Interface;
using JKLog.Mapper;
using System;
using System.Collections.Generic;



namespace JKLog.Util
{
    internal static class MapperManager
    {
        private static List<object> defaultMappers = null;
        private static List<object> DefaultMappers
        {
            get
            {
                if (defaultMappers == null)
                {
                    defaultMappers = new List<object>();

                    foreach (string mapperName in ConfigurationManager.GetRegisteredMapperNames())
                    {
                        // sallii käytön myös muista namespacesta
                        Type mapperType = Type.GetType(mapperName);

                        // jos mapperia ei löydy niin etsitään sitä omasta namespacesta
                        if (mapperType == null)
                            mapperType = Type.GetType("JKLog.Mapper." + mapperName);

                        // jos mapperi löytyi niin lisätään se defaultteihin.
                        if (mapperType != null)
                            defaultMappers.Add(Activator.CreateInstance(mapperType));
                    }
                }

                return defaultMappers;
            }

            set
            {
                if (value == null)
                {
                    DefaultWritables = null;
                    DefaultReadables = null;
                }

                defaultMappers = value;
            }
        }


        private static List<IWritable> defaultWritables = null;
        public static List<IWritable> DefaultWritables
        {
            get
            {
                if (defaultWritables == null)
                {
                    defaultWritables = new List<IWritable>();

                    foreach (object mapper in DefaultMappers)
                    {
                        IWritable writableMapper = mapper as IWritable;
                        if (writableMapper != null)
                            defaultWritables.Add(writableMapper);
                    }

                    if (defaultWritables.Count == 0)
                        defaultWritables.Add(new JKConsole());
                }

                return defaultWritables;
            }

            private set
            {
                defaultWritables = value;
            }
        }


        private static List<IReadable> defaultReadables = null;
        public static List<IReadable> DefaultReadables
        {
            get
            {
                if (defaultReadables == null)
                {
                    defaultReadables = new List<IReadable>();

                    foreach (object mapper in DefaultMappers)
                    {
                        IReadable readableMapper = mapper as IReadable;
                        if (readableMapper != null)
                            defaultReadables.Add(readableMapper);
                    }
                }

                return defaultReadables;
            }

            private set
            {
                defaultReadables = value;
            }
        }


        
        public static IWritable GetDefaultWritable(Type defaultMapperType)
        {
            foreach (IWritable writable in DefaultWritables)
                if (defaultMapperType == writable.GetType())
                    return writable;

            return null;
        }
        


        public static IReadable GetDefaultReadable(Type defaultMapperType)
        {
            foreach (IReadable readable in DefaultReadables)
                if (defaultMapperType == readable.GetType())
                    return readable;

            return null;
        }



        public static void DisposeDefaultMappers()
        {
            foreach (object mapper in DefaultMappers)
            {
                IDisposable disposable = mapper as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }

            DefaultMappers = null;
        }
    }
}
