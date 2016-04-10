using System;
using System.Collections.Generic;



namespace JKLog.Configuration
{
    internal static class ConfigurationManager
    {
        private static JKLogSection section = (JKLogSection)System.Configuration.ConfigurationManager.GetSection("JKLog");



        public static List<string> GetRegisteredMapperNames()
        {
            List<string> names = new List<string>();

            foreach (MapperElement mapper in section.Mappers)
                names.Add(mapper.Name);

            return names;
        }



        public static string GetValue(Type mapperType, string key)
        {
            foreach (MapperElement mapper in section.Mappers)
                if (mapper.Name == mapperType.Name)
                    foreach (KeyValue pair in mapper.Elements)
                        if (pair.Key == key)
                            return pair.Value;

            return null;
        }
    }
}
