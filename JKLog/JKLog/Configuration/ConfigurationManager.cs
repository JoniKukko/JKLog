using System;
using System.Collections.Generic;



namespace JKLog.Configuration
{
    internal static class ConfigurationManager
    {
        private static JKLogSection section = (JKLogSection)System.Configuration.ConfigurationManager.GetSection("JKLog");
        
        private static List<string> mapperNames = null;
        /// <summary>
        /// List of strings containing mapper names from App.config
        /// </summary>
        public static List<string> MapperNames
        {
            get
            {
                if (mapperNames == null)
                {
                    // parsitaan nimilista sectionista.
                    mapperNames = new List<string>();
                    foreach (MapperElement mapper in section.Mappers)
                        mapperNames.Add(mapper.Name);
                }

                return mapperNames;
            }
        }



        /// <summary>
        /// Fetches mapper configuration from App.config by mapper type.
        /// </summary>
        /// <param name="mapperType">Mapper type.</param>
        /// <returns>Key-Value dictionary containing mapper configuration.</returns>
        public static Dictionary<string, string> GetConfiguration(Type mapperType)
        {
            Dictionary<string, string> configuration = new Dictionary<string, string>();

            foreach (MapperElement mapper in section.Mappers)
            {
                // jos oikea mapper tyyppi löytyy.
                if (mapper.Name == mapperType.Name)
                {
                    // loopataan conffit läpi ja lisätään palautettavaan dictionaryyn.
                    foreach (KeyValue pair in mapper.Elements)
                        configuration.Add(pair.Key, pair.Value);
                    break;
                }
            }

            return configuration;
        }
    }
}
