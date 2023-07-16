using TaskManager.Classes;
public class RepeatingTask : TaskManager.Classes.Task
{
    //1 = Monday, 2 = Tuesday..., 7 = Sunday
    public int[]? RepatingDays { get; set; }

    public int RepeatInDays;
}