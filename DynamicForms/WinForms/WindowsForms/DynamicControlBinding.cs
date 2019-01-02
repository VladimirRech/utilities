using System;
using System.Collections.Generic;

namespace WindowsForms
{
    /// <summary>
    /// Provides properties to binding a combo box control
    /// </summary>
    [Serializable]
    public class DynamicControlBinding
    {
        public string ConnectionString { get; set; }
        public string Sql { get; set; }
        public string KeyValue{ get; set; }
        public string DisplayValue { get; set; }
        public List<string> Items { get; set; }

        bool IsValid()
        {
            return false;
        }

        bool SafeSql()
        {
            return false;
        }
    }
}
