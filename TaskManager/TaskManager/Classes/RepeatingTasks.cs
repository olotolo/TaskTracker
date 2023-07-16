using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes
{
    public class RepeatingTasks
    {
        public void SetRepeatingTask()
        {
            FileManagement fm = new FileManagement();
            List<RepeatingTask> tasks = new List<RepeatingTask>();
            fm.LoadRepeatingTask();
        }
    }
}
