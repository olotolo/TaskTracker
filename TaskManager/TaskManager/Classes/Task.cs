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
        public int Id { get; set; }
        public string? TaskString { get; set; }
        public bool Checked { get; set; } = false;
    }
}
