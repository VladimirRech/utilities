using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "connection")]
        public string ConnectionString { get; set; }
        [JsonProperty(PropertyName = "sql")]
        public string Sql { get; set; }
        [JsonProperty(PropertyName = "keyValue")]
        public string KeyValue { get; set; }
        [JsonProperty(PropertyName = "displayValue")]
        public string DisplayValue { get; set; }
        [JsonProperty(PropertyName = "items")]
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
