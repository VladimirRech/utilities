using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
