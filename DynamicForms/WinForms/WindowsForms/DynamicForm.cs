using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class DynamicForm : Form
    {
        List<DynamicControl> _dynamicControls;
        Dictionary<string, object> _returnValues;
        int _labelWidth = 150;
        int _controlWidth = 350;
        int _panelOffset = 20;
        int _controlOffset = 2;

        public DynamicForm(List<DynamicControl> dynamicControls)
        {
            InitializeComponent();
            Application.EnableVisualStyles();
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
            System.Drawing.Point lastLocation = new System.Drawing.Point(panel1.Location.X, panel1.Location.Y);
            lastLocation.X += 5;
            lastLocation.Y += 5;
            int controlsTotalHeight = panel1.Height;

            foreach (DynamicControl ctr in _dynamicControls)
            {
                var lbl = new Label { Text = ctr.Label, Width = _labelWidth, AutoSize = false, Location = lastLocation };
                var winCtr = GetControl(ctr, lastLocation);

                if (winCtr != null)
                {
                    panel1.Controls.Add(lbl);
                    panel1.Controls.Add(winCtr);
                    lastLocation.Y = winCtr.Location.Y + winCtr.Height + 2;
                    controlsTotalHeight += winCtr.Height + _controlOffset;
                }
            }

            Height = controlsTotalHeight + (_panelOffset * 2) + btnOk.Height + _controlOffset;
            Width = _labelWidth + _controlWidth + (_controlOffset * 2) + (_panelOffset * 5);
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
                        Location = new System.Drawing.Point(lastLocation.X + _labelWidth + 2, lastLocation.Y),
                        Text = ctr.InitialValue.ToString(),
                        Width = _controlWidth
                    };

                    _returnValues.Add(ctr.Key, null);
                    return winCtl;

                case "ComboBox":
                    winCtl = new ComboBox
                    {
                        Tag = ctr.Key,
                        Name = ctr.Name,
                        Location = new System.Drawing.Point(lastLocation.X + _labelWidth + 2, lastLocation.Y),
                        Width = _controlWidth,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    _returnValues.Add(ctr.Key, null);

                    if (ctr.BindingSource != null)
                    {
                        if (ctr.BindingSource.Items != null)
                        {
                            (winCtl as ComboBox).Items.AddRange(ctr.BindingSource.Items.ToArray());
                        }
                        else if (!string.IsNullOrEmpty(ctr.BindingSource.ConnectionString) &&
                          !string.IsNullOrEmpty(ctr.BindingSource.DisplayValue) &&
                          !string.IsNullOrEmpty(ctr.BindingSource.KeyValue) &&
                          !string.IsNullOrEmpty(ctr.BindingSource.Sql))
                        {
                            ConfigComboBoxBinding(ctr.BindingSource.ConnectionString, ctr.BindingSource.Sql, ctr.BindingSource.KeyValue, ctr.BindingSource.DisplayValue, (winCtl as ComboBox));
                        }
                    }

                    return winCtl;

                case "DataTime":
                    winCtl = new DateTimePicker
                    {
                        Tag = ctr.Key,
                        Name = ctr.Name,
                        Location = new System.Drawing.Point(lastLocation.X + _labelWidth + 2, lastLocation.Y),
                        Format = DateTimePickerFormat.Short,
                        Value = ctr.InitialValue != null ? DateTime.Parse(ctr.InitialValue.ToString()) : DateTime.Now,
                        Width = _controlWidth
                    };

                    _returnValues.Add(ctr.Key, null);

                    return winCtl;

                case "CheckBox":
                    winCtl = new CheckBox
                    {
                        Tag = ctr.Key,
                        Name = ctr.Name,
                        Location = new System.Drawing.Point(lastLocation.X + _labelWidth + 2, lastLocation.Y),
                        Checked = ctr.InitialValue != null ? Convert.ToBoolean(ctr.InitialValue) : false,
                        Width = _controlWidth
                    };

                    _returnValues.Add(ctr.Key, null);

                    return winCtl;
            }

            return winCtl;
        }

        private void ConfigComboBoxBinding(string connectionString, string sql, string keyValue, string displayValue, ComboBox cb)
        {
            using (DataTable dt = DataConnection.GetDataTable(connectionString, sql))
            {
                if (dt == null)
                {
                    return;
                }

                cb.DisplayMember = displayValue;
                cb.ValueMember = keyValue;
                cb.DataSource = dt.DefaultView;
            }
        }
    }
}
