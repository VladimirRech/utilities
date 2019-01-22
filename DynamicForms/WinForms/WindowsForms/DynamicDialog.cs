using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsForms
{
    /// <summary>
    /// Class to build a dynamic form
    /// </summary>
    [Serializable]
    public class DynamicDialog
    {
        #region fields
        string _dialogType;
        IEnumerable<string> _validDialogTypes = new List<string>() { "OK", "YesNo" };
        DynamicForm _DynamicForm;
        #endregion

        #region properties
        [JsonProperty(PropertyName = "name")]
        public string FormName { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string DialogType
        {
            get { return _dialogType; }
            set
            {
                if (_validDialogTypes.Contains(value))
                {
                    _dialogType = value;
                }
                else
                {
                    throw new Exception("Dialog type is not valid.\nCurrent valid types are:\n\n\t\"OK\" and \"YesNo\"");
                }
            }
        }
        [JsonProperty(PropertyName = "controls")]
        public List<DynamicControl> DynamicControls { get; set; }
        #endregion

        public static DynamicDialog GetFromJson(string json, out string error)
        {
            error = string.Empty;
            DynamicDialog ret = null;

            if (string.IsNullOrEmpty(json))
            {
                error = "A empty JSON was sent to service.";
                return ret;
            }

            try
            {
                ret = JsonConvert.DeserializeObject<DynamicDialog>(json);
            }
            catch (Exception ex)
            {
                error = string.Format("The content of JSON is invalid.\n{0}", ex.Message);
            }

            return ret;
        }

        /// <summary>
        /// Builds and show the dynamic form
        /// </summary>
        public void ShowDialog()
        {
            _DynamicForm = new DynamicForm(DynamicControls) { Text = Text };
            _DynamicForm.ShowDialog();
        }

        /// <summary>
        /// Returns the value entered in form fields
        /// </summary>
        /// <param name="key">Key used to get the value.</param>
        /// <returns>Value entered in the form control.</returns>
        public string GetValueByKey(string key)
        {
            return _DynamicForm.GetValueByey(key);
        }

        public Dictionary<string, string> GetAllReturnValues()
        {
            return _DynamicForm.dicReturnValues;
        }
    }
}
