using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes
{
    [Serializable]
    public class Day
    {
        public List<Task> Tasks = new List<Task>();
    }
}
