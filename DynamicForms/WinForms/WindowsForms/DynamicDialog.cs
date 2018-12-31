using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsForms
{
    /// <summary>
    /// Class to build a dynamic form
    /// </summary>
    public class DynamicDialog
    {
        public string FormName { get; set; }
        public string Text { get; set; }
        public EDialogType DialogType { get; set; }
        public List<DynamicControl> DynamicControls { get; set; }
    }

    public enum EDialogType { EOkDialog, EYesNoDialog }
}
