using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes
{
    public class ControlPanel : Panel
    {
        public int PanelId { get; set; }
        public string? PanelName { get; set; }
        public string? PanelDescription { get; set; }

        public Button? button { get; set; }
        public CheckBox? checkBox { get; set; }
        public Label? label { get; set; }

    }
}
