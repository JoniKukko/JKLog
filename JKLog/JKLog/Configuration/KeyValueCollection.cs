using System.Configuration;



namespace JKLog.Configuration
{
    internal class KeyValueCollection : ConfigurationElementCollection
    {
        protected override string ElementName
        {
            get
            {
                return "add";
            }
        }



        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }



        protected override ConfigurationElement CreateNewElement()
        {
            return new KeyValue();
        }



        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((KeyValue)element).Key;
        }
    }
}