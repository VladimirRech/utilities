using System;
using System.Collections.Generic;
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
        public string FormName { get; set; }
        public string Text { get; set; }
        public EDialogType DialogType { get; set; }
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
