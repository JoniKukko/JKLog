using JKLog.Interface;
using JKLog.Mapper;
using System;
using System.Collections.Generic;



namespace JKLog.Configuration
{
    public static class MapperManager
    {
        private static List<object> defaultMappers = null;
        public static List<object> DefaultMappers
        {
            get
            {
                if (defaultMappers == null)
                {
                    defaultMappers = new List<object>();

                    foreach (string mapperName in ConfigurationManager.MapperNames)
                    {
                        // sallii käytön myös muista namespacesta
                        Type mapperType = Type.GetType(mapperName);

                        // jos mapperia ei löydy niin etsitään sitä omasta namespacesta
                        if (mapperType == null)
                            mapperType = Type.GetType("JKLog.Mapper." + mapperName);

                        // jos mapperi löytyi niin lisätään se defaultteihin.
                        if (mapperType != null)
                        {
                            object mapperInstance = Activator.CreateInstance(mapperType);

                            // jos se on configuroitavissa niin injectoidaan conffit mukaan
                            IConfigurable configurable = mapperInstance as IConfigurable;
                            if (configurable != null)
                                configurable.Configuration = ConfigurationManager.GetConfiguration(configurable.GetType());

                            defaultMappers.Add(mapperInstance);
                        }
                    }
                }

                return defaultMappers;
            }

            private set
            {
                defaultMappers = value;
            }
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
            // käytetään defaultMappers ettei DefaultMappers lataa niitä turhaan
            // jos mapperia ei löydy defaulteista niin sen voi disposata 
            if (defaultMappers == null || DefaultMappers.Find(item => item == mapper) == null)
            {
                IDisposable disposable = mapper as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
        }



        /// <summary>
        /// Disposes all mapper's in a list safely if item is not a default mapper.
        /// </summary>
        /// <param name="mappers">List of mappers to dispose.</param>
        public static void DisposeMapper(List<object> mappers)
        {
            foreach (object mapper in mappers)
            {
                // käytetään defaultMappers ettei DefaultMappers lataa niitä turhaan
                // jos mapperia ei löydy defaulteista niin sen voi disposata 
                if (defaultMappers == null || DefaultMappers.Find(item => item == mapper) == null)
                {
                    IDisposable disposable = mapper as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }
            }
        }



        /// <summary>
        /// Disposes default mappers safely
        /// </summary>
        public static void DisposeDefaultMappers()
        {
            // käytetään defaultMappers ettei DefaultMappers lataa niitä turhaan
            if (defaultMappers != null)
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
}
