using System.Configuration;



namespace JKLog.Configuration
{
    internal class MapperCollection : ConfigurationElementCollection
    {
        protected override string ElementName
        {
            get
            {
                return "mapper";
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
            return new MapperElement();
        }



        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MapperElement)element).Name;
        }
    }
}