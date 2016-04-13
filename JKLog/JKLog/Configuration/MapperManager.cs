using JKLog.Interface;
using JKLog.Mapper;
using System;
using System.Collections.Generic;



namespace JKLog.Configuration
{
    public static class MapperManager
    {
        private static List<object> defaultMappers;
        public static List<object> DefaultMappers
        {
            get
            {
                if (defaultMappers == null)
                    CreateDefaultMappers();
                return defaultMappers;
            }
        }



        private static void CreateDefaultMappers()
        {
            defaultMappers = new List<object>();

            foreach (string mapperName in ConfigurationManager.MapperNames)
            {
                // sallii käytön myös muista namespacesta
                Type mapperType = Type.GetType(mapperName) ?? Type.GetType("JKLog.Mapper." + mapperName);

                // jos mapperi löytyi niin lisätään se defaultteihin.
                if (mapperType != null && Attribute.IsDefined(mapperType, typeof(JKMapper)))
                {
                    object mapperInstance = Activator.CreateInstance(mapperType);

                    // jos se on configuroitavissa niin injectoidaan conffit mukaan
                    if (mapperInstance is IConfigurable)
                        (mapperInstance as IConfigurable).Configuration = ConfigurationManager.GetConfiguration(mapperType);

                    defaultMappers.Add(mapperInstance);
                }
            }

            // lisätään JKConsole jos mitään muuta ei ole..
            if (defaultMappers.Count == 0)
                defaultMappers.Add(new JKConsole());
        }



        public static object GetDefaultMapper(Type defaultMapperType)
        {
            foreach (object defaultMapper in DefaultMappers)
                if (defaultMapperType == defaultMapper.GetType())
                    return defaultMapper;

            return null;
        }



        /// <summary>
        /// Disposes mapper safely if it's not a default mapper.
        /// </summary>
        /// <param name="mapper">Mapper to dispose.</param>
        public static void DisposeMapper(object mapper)
        {
            if ((defaultMappers == null || DefaultMappers.Find(item => item == mapper) == null) && mapper is IDisposable)
                (mapper as IDisposable).Dispose();
        }



        /// <summary>
        /// Disposes all mapper's in a list safely if item is not a default mapper.
        /// </summary>
        /// <param name="mappers">List of mappers to dispose.</param>
        public static void DisposeMapper(List<object> mappers)
        {
            foreach (object mapper in mappers)
                if ((defaultMappers == null || DefaultMappers.Find(item => item == mapper) == null) && mapper is IDisposable)
                    (mapper as IDisposable).Dispose();
        }



        /// <summary>
        /// Disposes default mappers safely
        /// </summary>
        public static void DisposeDefaultMappers()
        {
            if (defaultMappers != null)
            {
                foreach (object mapper in DefaultMappers)
                    if (mapper is IDisposable)
                        (mapper as IDisposable).Dispose();

                defaultMappers = null;
            }
        }
    }
}
