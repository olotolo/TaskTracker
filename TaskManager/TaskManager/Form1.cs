using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaskManager.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public string SaveText;
        public SaveObject? saveObject;
        //Used to save in which month the current changes are made.
        public DateTime currentTime = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
            FileManagement fm = new FileManagement();
            SaveText = fm.GetFileText(DateTime.Now);
            if (SaveText != "")
            {
                try
                {
                    saveObject = JsonConvert.DeserializeObject<SaveObject>(SaveText);

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

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            Classes.Task task = new Classes.Task();
            task.TaskString = taskInput.Text;
            DateTime dt = dateTimePicker1.Value.Date;

            if (saveObject != null)
            {
                while (saveObject.Days.Count < dt.Day)
                {
                    AddDays(dt);
                }
                saveObject.Days[dt.Day - 1].Tasks.Add(task);

            }

            //Save Changes to txt file.
            FileManagement fm = new FileManagement();

            if (saveObject != null)
            {
                fm.WriteFileText(saveObject, currentTime);
            }
            
        }



        private void displayText_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < labels.Count; i++)
            {
                Controls.Remove(labels[i]);
            }
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                Controls.Remove(checkBoxes[i]);
            }


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
                if(saveObject == null)
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
        public void DisplayTasks()
        {

            for (int i = 0; i < saveObject.Days[currentTime.Day - 1].Tasks.Count(); i++)
            {
                
                Label label = new Label();
                labels.Add(label);
                this.Controls.Add(label);
                label.Name = i.ToString();
                label.Text = saveObject.Days[currentTime.Day - 1].Tasks[i].TaskString;
                label.Location = new Point(40, 55 + (i * 40));
                label.Size = new Size(200, 40);

                CheckBox c = new CheckBox();
                checkBoxes.Add(c);
                c.Checked = saveObject.Days[currentTime.Day - 1].Tasks[i].Checked;
                c.Location = new Point(20, 50 +(i* 40));
                c.Width = 20;
                c.Name = i.ToString();
                this.Controls.Add(c);
                c.Click += c_Click;
            }

        }

        void c_Click(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            if (c.Checked)
            {
                
                Console.WriteLine("check");
                saveObject.Days[currentTime.Day - 1].Tasks[Convert.ToInt32(c.Name)].Checked = true;
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

        private void tasksDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}