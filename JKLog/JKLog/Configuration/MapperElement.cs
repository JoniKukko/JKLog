using System.Configuration;



namespace JKLog.Configuration
{
    internal class MapperElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
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