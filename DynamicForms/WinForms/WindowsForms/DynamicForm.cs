using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class DynamicForm : Form
    {
        List<DynamicControl> _dynamicControls;
        Dictionary<string, object> _returnValues;
        int MAXHEIGHT = 600;

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

        private void DynamicForm_Load(object sender, System.EventArgs e)
        {
            CreateDynamicControls();
        }

        private void CreateDynamicControls()
        {
            System.Drawing.Point lastLocation = panel1.Location;
            lastLocation.X += 5;
            lastLocation.Y += 5;
            
            foreach(DynamicControl ctr in _dynamicControls)
            {
                var lbl = new Label { Text = ctr.Label, Width = 300, AutoSize = false, Location = lastLocation };
                var winCtr = GetControl(ctr, lastLocation);

                if (winCtr != null)
                {
                    panel1.Controls.Add(lbl);
                    panel1.Controls.Add(winCtr);
                    lastLocation.Y += winCtr.Location.Y + winCtr.Height + 2;
                }
            }
        }

        private Control GetControl(DynamicControl ctr, System.Drawing.Point lastLocation)
        {
            Control winCtl = null;

            switch (ctr.ControlType)
            {
                case "TextBox":
                    winCtl = new TextBox
                    {
                        Tag = ctr.Key,
                        Name = ctr.Name,
                        Location = new System.Drawing.Point(lastLocation.X + 2, lastLocation.Y),
                        Text = ctr.InitialValue.ToString()
                    };

                    _returnValues.Add(ctr.Key, null);
                    return winCtl;

                case "ComboBox":
                    winCtl = new ComboBox
                    {
                        Tag = ctr.Key,
                        Name = ctr.Name,
                        Location = new System.Drawing.Point(lastLocation.X + 2, lastLocation.Y)
                    };

                    _returnValues.Add(ctr.Key, null);

                    if (ctr.BindingSource != null && ctr.BindingSource.Items != null)
                    {
                        (winCtl as ComboBox).Items.AddRange(ctr.BindingSource.Items.ToArray());
                    }

                    return winCtl;

                case "DataTime":
                    winCtl = new DateTimePicker
                    {
                        Tag = ctr.Key,
                        Name = ctr.Name,
                        Location = new System.Drawing.Point(lastLocation.X + 2, lastLocation.Y),
                        Format = DateTimePickerFormat.Short,
                        Value = ctr.InitialValue != null ? DateTime.Parse(ctr.InitialValue.ToString()) : DateTime.Now
                    };

                    _returnValues.Add(ctr.Key, null);

                    return winCtl;

                case "CheckBox":
                    winCtl = new CheckBox
                    {
                        Tag = ctr.Key,
                        Name = ctr.Name,
                        Location = new System.Drawing.Point(lastLocation.X + 2, lastLocation.Y),
                        Checked = ctr.InitialValue != null ? Convert.ToBoolean(ctr.InitialValue) : false
                    };

                    _returnValues.Add(ctr.Key, null);

                    return winCtl;
            }

            return winCtl;
        }
    }
}
