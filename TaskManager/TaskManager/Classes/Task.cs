using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes
{
    [Serializable]
    public class Task
    {
        public string? Id { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public bool Checked { get; set; } = false;

        public bool CarryOver { get; set; }

        //Might need this for every day (so you can just repeat tasks on specific Days)
        public bool Repeat { get; set; }
    }
}
