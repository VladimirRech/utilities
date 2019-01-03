using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class DynamicForm : Form
    {
        List<DynamicControl> _dynamicControls;
        Dictionary<string, object> _returnValues;

        public DynamicForm(List<DynamicControl> dynamicControls)
        {
            InitializeComponent();
            _dynamicControls = dynamicControls;
            _returnValues = new Dictionary<string, object>();
        }

        public object GetValueByey(string key)
        {
            return _returnValues.ContainsKey(key) ? _returnValues[key] : null;
        }
    }
}
