using System;
using System.Collections.Generic;



namespace JKLog.Configuration
{
    internal static class ConfigurationManager
    {
        private static JKLogSection section = (JKLogSection)System.Configuration.ConfigurationManager.GetSection("JKLog");

        private static List<string> mapperNames = null;
        public static List<string> MapperNames
        {
            get
            {
                if (mapperNames == null)
                {
                    mapperNames = new List<string>();
                    foreach (MapperElement mapper in section.Mappers)
                        mapperNames.Add(mapper.Name);
                }

                return mapperNames;
            }
        }



        public static Dictionary<string, string> GetConfiguration(Type mapperType)
        {
            Dictionary<string, string> configuration = new Dictionary<string, string>();

            foreach (MapperElement mapper in section.Mappers)
            {
                if (mapper.Name == mapperType.Name)
                {
                    foreach (KeyValue pair in mapper.Elements)
                        configuration.Add(pair.Key, pair.Value);

                    break;
                }
            }

            return configuration;
        }
    }
}
