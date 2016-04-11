using System.Collections.Generic;



namespace JKLog.Interface
{
    public interface IConfigurable
    {
        Dictionary<string, string> Configuration { set; }
    }
}
