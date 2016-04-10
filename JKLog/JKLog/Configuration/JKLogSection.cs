using System.Configuration;



namespace JKLog.Configuration
{
    internal class JKLogSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public MapperCollection Mappers
        {
            get
            {
                return (MapperCollection)base[""];
            }
        }
    }
}