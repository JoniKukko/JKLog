using System.Configuration;



namespace JKLog.Configuration
{
    internal class MapperElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["type"];
            }
        }



        [ConfigurationProperty("", IsDefaultCollection = true)]
        public KeyValueCollection Elements
        {
            get
            {
                return (KeyValueCollection)base[""];
            }
        }
    }
}