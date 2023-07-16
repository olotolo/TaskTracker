using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager.Classes
{
    public class MoveLastTasks
    {
        // Called when the Programm is opened. 
        // Checkes the past days of there are Tasks that are unfullfilled and have been tagged to be carried over to the next days.
        public void MoveUnfinishedTasks()
        {
            int daysToCheck = 10;
            //Get the SaveObject from 7 Days ago (To check last month if neccessary)
            DateTime dt = DateTime.Now;
            dt.AddDays(daysToCheck);
            FileManagement fm = new FileManagement();
            SaveObject so = fm.GetSaveObject(dt);
            List<Task> tasks = new List<Task>();

            foreach(Day days in so.Days.TakeWhile(d => dt < DateTime.Now))
            {
                foreach(Task task in days.Tasks.TakeWhile(t => t.CarryOver))
                {
                    
                    tasks.Add(task);
                    //Remove task from day
                }
                foreach(Task t in tasks) {
                    days.Tasks.Remove(t);
                }

            }
            fm.WriteFileText(so, dt);
            so = fm.GetSaveObject(DateTime.Now);


            foreach (Task task in tasks)
            {
                so.Days[dt.Day-1].Tasks.Add(task);
            }

            fm.WriteFileText(so, DateTime.Now);



            //Check this month aswell
            if(dt.Day < daysToCheck)
            {

            }
        }
    }
}
