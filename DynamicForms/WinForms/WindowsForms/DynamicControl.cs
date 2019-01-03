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
        public string Name { get; set; }
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
        public string Key { get; set; }
        public string label { get; set; }
        public object InitialValue { get; set; }
        public DynamicControlBinding BindingSource { get; set; }
        #endregion
    }
}
