using System.Collections.Generic;
using TaskManager.Classes;
public class RepeatingTask : TaskManager.Classes.Task {

    public RepeatingTask(TaskManager.Classes.Task t) {
        this.Id = t.Id;
        this.TaskName = t.TaskName;
        this.TaskDescription = t.TaskDescription; 
        this.CarryOver = t.CarryOver;


}
    public RepeatingTask() {

    }


    public string? Guid;
    // 0 = Stunday, 1 = Monday... 6 = Saturday
    public List<List<TaskManager.Classes.Task>> WeekDays = new List<List<TaskManager.Classes.Task>>();
    
/*    //1 = Monday, 2 = Tuesday..., 7 = Sunday
    public List<TaskManager.Classes.Task>? Monday = new List<TaskManager.Classes.Task>();
    public List<TaskManager.Classes.Task>? Tuesday = new List<TaskManager.Classes.Task>();  
    public List<TaskManager.Classes.Task>? Wednesday = new List<TaskManager.Classes.Task>();
    public List<TaskManager.Classes.Task>? Thursday = new List<TaskManager.Classes.Task>();
    public List<TaskManager.Classes.Task>? Friday = new List<TaskManager.Classes.Task>();
    public List<TaskManager.Classes.Task>? Saturday = new List<TaskManager.Classes.Task>();
    public List<TaskManager.Classes.Task>? Sunday = new List<TaskManager.Classes.Task>();

*/
    public int RepeatInDays;
}