using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsForms
{
    /// <summary>
    /// Properties to create a dynamic control
    /// </summary>
    [Serializable]
    public class DynamicControl
    {
        #region fields
        IEnumerable<string> _validControls = new List<string>()
        {
                "TextBox",
                "ComboBox",
                "DateTime",
                "CheckBox"
        };
        string _controlType;
        #endregion

        #region properties
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string ControlType
        {
            get { return _controlType; }
            set
            {
                if (_validControls.Contains(value))
                {
                    _controlType = value;
                }
                else
                {
                    throw new Exception("Control type is not valid.");
                }
            }
        }
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
        [JsonProperty(PropertyName = "initialValue")]
        public object InitialValue { get; set; }
        [JsonProperty(PropertyName = "bindingSource")]
        public DynamicControlBinding BindingSource { get; set; }
        #endregion
    }
}
