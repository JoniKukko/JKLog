using System.Configuration;



namespace JKLog.Configuration
{
    internal class KeyValue : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)base["key"]; }
        }



        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)base["value"]; }
        }
    }
}