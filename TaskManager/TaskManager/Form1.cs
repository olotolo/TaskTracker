using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaskManager.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TaskManager
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public string SaveText;
        public SaveObject? saveObject;
        //Used to save in which month the current changes are made.
        public DateTime currentTime = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            FileManagement fm = new FileManagement();
            SaveText = fm.GetFileText(DateTime.Now);
            if (SaveText != "")
            {
                try
                {
                    saveObject = JsonConvert.DeserializeObject<SaveObject>(SaveText);
                    DisplayTasks();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                saveObject = new SaveObject();
            }

            

        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (saveObject != null)
            {
                FileManagement fm = new FileManagement();
                fm.WriteFileText(saveObject, currentTime);
            }
        }

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            taskPanel.VerticalScroll.Value = 0;

            Classes.Task task = new Classes.Task();
            task.TaskString = taskInput.Text;
            task.Id = Guid.NewGuid().ToString();

            DateTime dt = dateTimePicker1.Value.Date;

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
            FileManagement fm = new FileManagement();

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
                DisplayTasks();

            }



        }
        private List<Label> labels = new List<Label>();
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private List<Button> buttons = new List<Button>();
        private List<Panel> panels = new List<Panel>();
        public void DisplayTasks()
        {

            for (int i = 0; i < saveObject.Days[currentTime.Day - 1].Tasks.Count(); i++)
            {
                addTask(i + 1);
            }

        }

        //delete button
        void button_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
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
            for(int i = 0; i < panels.Count; i++)
            {
                taskPanel.Controls.Remove(panels[i]);
            }


        }

        private int colorCount = 0;
        private void addTask(int i)
        {
            Panel panel = new Panel();
            panels.Add(panel);
            panel.Parent = taskPanel;
            panel.Location = new Point(5, (i*30));
            panel.Size = new Size(375, 30);
            taskPanel.AutoScroll = true;
            if(colorCount % 2 == 0)
            {
                panel.BackColor = Color.White;
            } else
            {
                panel.BackColor = Color.LightGray;
            }
            colorCount++;
            Label label = new Label();
            labels.Add(label);
            this.Controls.Add(label);
            label.Name = saveObject.Days[currentTime.Day - 1].Tasks[i-1].Id.ToString();
            label.Text = saveObject.Days[currentTime.Day - 1].Tasks[i-1].TaskString;
            label.Location = new Point(50, 0);
            label.Size = new Size(200, 30);
            label.Parent = panel;
            label.BringToFront();

            CheckBox c = new CheckBox();
            checkBoxes.Add(c);
            c.Checked = saveObject.Days[currentTime.Day - 1].Tasks[i - 1].Checked;
            c.Location = new Point(10, 0);
            c.Size = new Size(30, 30);

            c.Width = 20;
            c.Name = saveObject.Days[currentTime.Day - 1].Tasks[i-1].Id.ToString();
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
            button.Name = saveObject.Days[currentTime.Day - 1].Tasks[i-1].Id.ToString();
            button.Click += button_Click;
            button.Parent = panel;
            button.BringToFront();
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

        private void taskInput_TextChanged(object sender, EventArgs e)
        {

        }

    }
}