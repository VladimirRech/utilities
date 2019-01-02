using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Linq;
using System.Text;

namespace WindowsForms
{
    /// <summary>
    /// Class to build a dynamic form
    /// </summary>
    /// 
    [Serializable]
    public class DynamicDialog
    {
        [Required]
        public string FormName { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public EDialogType DialogType { get; set; }
        [Required]
        public List<DynamicControl> DynamicControls { get; set; }

        // Fields
        DynamicForm _DynamicForm;

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
                ret = new JavaScriptSerializer().Deserialize<DynamicDialog>(json);
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

        }

        /// <summary>
        /// Returns the value entered in form fields
        /// </summary>
        /// <param name="key">Key used to get the value.</param>
        /// <returns>Value entered in the form control.</returns>
        public object GetValueByKey(string key)
        {
            return null;
        }
    }

    public enum EDialogType { EOkDialog, EYesNoDialog }
}
