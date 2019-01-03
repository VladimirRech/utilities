using System;

namespace WindowsForms
{
    /// <summary>
    /// Properties to create a dynamic control
    /// </summary>
    [Serializable]
    public class DynamicControl
    {
        public string Name { get; set; }
        public EDynamicControlType ControlType { get; set; }
        public string Key { get; set; }
        public string label { get; set; }
        public object InitialValue { get; set; }
        public DynamicControlBinding BindingSource { get; set; }
    }
}
