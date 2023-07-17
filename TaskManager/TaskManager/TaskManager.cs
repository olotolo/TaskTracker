using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing.Text;
using System.Threading.Tasks;
using TaskManager.Classes;

namespace TaskManager
{
    public partial class TaskManager : System.Windows.Forms.Form
    {
        public SaveObject? saveObject;
        //Used to save in which month the current changes are made.
        public DateTime currentTime = DateTime.Now;
        public TaskManager()
        {
            InitializeComponent();

            MoveLastTasks moveLastTasks = new MoveLastTasks();
            moveLastTasks.MoveUnfinishedTasks();

            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            FileManagement fm = new FileManagement();
            saveObject = fm.GetSaveObject(DateTime.Now);
            List<RepeatingTask> rtasks = fm.LoadRepeatingTask();

            
            //errorLogText.Text = System.IO.Directory.GetCurrentDirectory();
            DisplayTasks();
            taskName.PlaceholderText = "Enter Task Name";
            taskDescription.PlaceholderText = "Enter Task Description";

            LoadRepeatingTasks();

        }

        private void LoadRepeatingTasks() {

            DateTime dt = dateTimePicker1.Value.Date;
            bool add = true;
            FileManagement fm = new FileManagement();
            RepeatingTasks rt = new RepeatingTasks();
            List<RepeatingTask> rtasks = fm.LoadRepeatingTask();
            foreach (RepeatingTask rtask in rtasks) {
                System.Diagnostics.Debug.WriteLine("Monday Tasks: " + rtask.WeekDays.Count);

                //Fix this 
                if (rtask.WeekDays[(int)dt.DayOfWeek] != null && rtask.WeekDays[(int)dt.DayOfWeek].Count > 0) {
                    if (saveObject != null && saveObject.Days.Count < currentTime.Day) {
                        while (saveObject.Days.Count < dt.Day) {
                            AddDays(dt);
                        }
                    }
                    if(saveObject == null || saveObject.Days == null || saveObject.Days.Count < currentTime.Day) {
                        return;
                    }
                    //Check if the task with the id already exists in there
                    foreach(Classes.Task t in saveObject.Days[currentTime.Day-1].Tasks) {
                        if(t.Id == rtask.Id) {
                            add = false;
                            break;
                        }
                    }
                    if(add == true) {
                        saveObject.Days[dt.Day - 1].Tasks.Add(rtask);
                    }
                }
            }
        }

        //Called when the Application (Form1) is closed
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (saveObject != null)
            {
                FileManagement fm = new FileManagement();
                fm.WriteFileText(saveObject, currentTime);
            }
        }

        //Button press adds a Task
        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            FileManagement fm = new FileManagement();

            int temp = taskPanel.VerticalScroll.Value;
            taskPanel.VerticalScroll.Value = 0;

            Classes.Task task = new Classes.Task();
            task.TaskName = taskName.Text;
            task.TaskDescription = taskDescription.Text;
            task.Id = Guid.NewGuid().ToString();
            task.CarryOver = carryOverCheckBox.Checked;
            DateTime dt = dateTimePicker1.Value.Date;

            if (repeatTaskCheckBox.Checked)
            {
                List<RepeatingTask> taskList = fm.LoadRepeatingTask();
                RepeatingTask newTask = new RepeatingTask();
                newTask.TaskName = task.TaskName;
                newTask.TaskDescription = task.TaskDescription;
                newTask.Id = task.Id;
                System.Diagnostics.Debug.WriteLine("new task week days"+newTask.WeekDays.Count);


                newTask.TaskName = task.TaskName;
                if (taskList == null)
                {
                    taskList = new List<RepeatingTask>();
                }
                while(newTask.WeekDays.Count < 7) {
                    newTask.WeekDays.Add(new List<Classes.Task>());
                }
                if(mondayCheckBox.Checked) { newTask.WeekDays[1].Add(task); }
                if(tuesdayCheckBox.Checked) { newTask.WeekDays[2].Add(task); }
                if(WednesdayCheckBox.Checked) { newTask.WeekDays[3].Add(task); }
                if(thursdayCheckBox.Checked) { newTask.WeekDays[4].Add(task); }
                if(fridayCheckBox.Checked) { newTask.WeekDays[5].Add(task); }
                if(saturdayCheckBox.Checked) { newTask.WeekDays[6].Add(task); }
                if(sundayCheckBox.Checked) { newTask.WeekDays[0].Add(task); }

                System.Diagnostics.Debug.WriteLine("List before adding new task: " + JsonConvert.SerializeObject(taskList));

                taskList.Add(newTask);
                System.Diagnostics.Debug.WriteLine("List after adding new task: " + JsonConvert.SerializeObject(taskList));
                fm.SaveRepeatingTask(taskList);
                System.Diagnostics.Debug.WriteLine("new task week days" + newTask.WeekDays.Count);
                return;

            }


            if (saveObject != null)
            {
                while (saveObject.Days.Count < dt.Day)
                {
                    AddDays(dt);
                }
                saveObject.Days[dt.Day - 1].Tasks.Add(task);
                addTask(saveObject.Days[dt.Day - 1].Tasks.Count);
            }

            //Save Changes to txt file.

            if (saveObject != null)
            {
                fm.WriteFileText(saveObject, currentTime);
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            deleteAllTasks();

            DateTime dt = dateTimePicker1.Value.Date;


            if (currentTime.Month != dt.Month || currentTime.Year != dt.Year)
            {
                FileManagement fm = new FileManagement();
                //Save Changes to txt file.
                if (saveObject != null)
                {
                    fm.WriteFileText(saveObject, currentTime);
                }

                //Load current month
                string SaveText = fm.GetFileText(dt);

                saveObject = JsonConvert.DeserializeObject<SaveObject>(SaveText);
                if (saveObject == null)
                {
                    saveObject = new SaveObject();
                }
            }
            currentTime = dt;

            if (saveObject != null)
            {
                while (saveObject.Days.Count < dt.Day)
                {
                    AddDays(dt);
                }
                LoadRepeatingTasks();

                DisplayTasks();

            }



        }
        private List<Label> labels = new List<Label>();
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private List<Button> buttons = new List<Button>();
        private List<Panel> panels = new List<Panel>();
        public void DisplayTasks()
        {
            if (saveObject == null || saveObject.Days == null || saveObject.Days.Count <= currentTime.Day - 1 || saveObject.Days[currentTime.Day - 1] == null)
            {
                return;
            }


            for (int i = 0; i < saveObject.Days[currentTime.Day - 1].Tasks.Count(); i++)
            {
                addTask(i + 1);
            }

        }

        //delete button
        void button_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null || saveObject == null) return;
            ControlPanel cp = (ControlPanel)btn.Parent;

            var itemToRemove = saveObject.Days[currentTime.Day - 1].Tasks.Single(r => r.Id == btn.Name);

            saveObject.Days[currentTime.Day - 1].Tasks.Remove(itemToRemove);
            FileManagement fm = new FileManagement();
            //Save Changes to txt file.
            if (saveObject != null)
            {
                fm.WriteFileText(saveObject, currentTime);
            }

            //Load current month
            string SaveText = fm.GetFileText(currentTime);

            saveObject = JsonConvert.DeserializeObject<SaveObject>(SaveText);
            if (saveObject == null)
            {
                saveObject = new SaveObject();
            }

            deleteAllTasks();
            DisplayTasks();
            //removeTask(itemToRemove.Id);
        }

        public void deleteAllTasks()
        {
            for (int i = 0; i < panels.Count; i++)
            {
                taskPanel.Controls.Remove(panels[i]);
            }


        }


        private void addTask(int i)
        {
            ControlPanel panel = new ControlPanel();
            panel.PanelId = i;
            panels.Add(panel);
            panel.Name = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].Id.ToString();
            panel.Parent = taskPanel;
            panel.Location = new Point(5, (i * 30));
            panel.Size = new Size(375, 30);
            panel.Click += Panel_Click;

            panel.PanelName = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].TaskName;
            panel.PanelDescription = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].TaskDescription;

            taskPanel.AutoScroll = true;
            if (i % 2 == 0)
            {
                panel.BackColor = Color.White;
            }
            else
            {
                panel.BackColor = Color.LightGray;
            }


            Label label = new Label();
            labels.Add(label);
            this.Controls.Add(label);
            label.Name = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].Id.ToString() + "label";
            label.Text = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].TaskName;
            label.Location = new Point(80, 0);
            label.Size = new Size(170, 30);
            label.Parent = panel;
            label.BringToFront();
            label.Click += Text_Click;

            CheckBox c = new CheckBox();
            checkBoxes.Add(c);
            c.Checked = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].Checked;
            c.Location = new Point(10, 0);
            c.Size = new Size(30, 30);
            c.Width = 20;
            c.Name = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].Id.ToString();
            this.Controls.Add(c);
            c.Click += c_Click;
            c.Parent = panel;
            label.BringToFront();

            Button button = new Button();
            this.Controls.Add(button);
            buttons.Add(button);
            button.Location = new Point(280, 0);
            button.Size = new Size(90, 30);
            button.Text = "Delete";
            button.Name = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].Id.ToString();
            button.Click += button_Click;
            button.Parent = panel;
            button.BringToFront();

            panel.button = button;
            panel.checkBox = c;
            panel.label = label;
        }

        // Checkbox
        void c_Click(object sender, EventArgs e)
        {
            CheckBox? c = sender as CheckBox;
            if (saveObject == null)
            {
                return;
            }
            int index = saveObject.Days[currentTime.Day - 1].Tasks.FindIndex(r => r.Id == c.Name);
            if (saveObject.Days[currentTime.Day - 1].Tasks[index].Checked == true)
            {
                saveObject.Days[currentTime.Day - 1].Tasks[index].Checked = false;
            }
            else
            {
                saveObject.Days[currentTime.Day - 1].Tasks[index].Checked = true;
            }
        }

        void carryOver_Click(object sender, EventArgs e)
        {
            if (currentPanel == null || saveObject == null) return;
            saveObject.Days[currentTime.Day - 1].Tasks[currentPanel.PanelId - 1].CarryOver = carryOverCheckBox.Checked;
            /*if(carryOverCheckBox.Checked == true)
            {
                carryOverCheckBox.Checked = false;
            } else
            {
                carryOverCheckBox.Checked = true;
            }*/
        }

        private ControlPanel? currentPanel;
        private Color panelColor;

        void Text_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            Panel_Click(label.Parent, e);
        }

        //When the panel is clicked;
        void Panel_Click(object sender, EventArgs e)
        {
            ControlPanel? panel = (ControlPanel)sender;
            if (currentPanel != null)
            {
                currentPanel.BackColor = panelColor;
            }

            if (panel == currentPanel)
            {
                currentPanel.BackColor = panelColor;
                currentPanel = null;
                taskName.Text = "";
                taskDescription.Text = "";
                carryOverCheckBox.Checked = false;
                return;
            }
            panelColor = panel.BackColor;
            panel.BackColor = Color.LightBlue;
            currentPanel = panel;
            taskName.Text = saveObject.Days[currentTime.Day - 1].Tasks[panel.PanelId - 1].TaskName;
            taskDescription.Text = saveObject.Days[currentTime.Day - 1].Tasks[panel.PanelId - 1].TaskDescription;
            carryOverCheckBox.Checked = saveObject.Days[currentTime.Day - 1].Tasks[panel.PanelId - 1].CarryOver;
        }

        public void AddDays(DateTime dt)
        {
            int _month = Convert.ToInt32(dt.ToString("MM"));
            int _year = Convert.ToInt32(dt.ToString("yyyy"));
            int max = DateTime.DaysInMonth(_year, _month);

            Classes.Day day = new Classes.Day();
            if (saveObject != null)
            {
                saveObject.Days.Add(day);
            }

        }


        //Auto save when changes are made
        private void taskDescription_TextChanged(object sender, EventArgs e)
        {
            if (saveObject == null || currentPanel == null) return;
            saveObject.Days[currentTime.Day - 1].Tasks[currentPanel.PanelId - 1].TaskDescription = taskDescription.Text;
        }

        private void taskName_TextChanged(object sender, EventArgs e)
        {
            if (saveObject == null || currentPanel == null) return;
            saveObject.Days[currentTime.Day - 1].Tasks[currentPanel.PanelId - 1].TaskName = taskName.Text;
            currentPanel.label.Text = taskName.Text;

        }

        private void tuesdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mondayCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TaskManager_Load(object sender, EventArgs e)
        {

        }
    }
}