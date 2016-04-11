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



        #region Creates default mappers.

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
        /// Turns mapper names from ConfigurationMapper to list of defaultWritables and defaultReadables
        /// </summary>
        private static void CreateDefaultMappers()
        {
            defaultWritables = new List<IWritable>();
            defaultReadables = new List<IReadable>();


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
                }
            }
        }

        #endregion



        public static void ClearMappers()
        {
            MapperManager.defaultWritables = null;
            MapperManager.defaultReadables = null;
        }
        
    }
}
