﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using Newtonsoft.Json;

namespace TaskManager.Classes
{
    internal class FileManagement
    {

        public string Path()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }

        public string GetFileText(DateTime dt)
        {
            string path = Path();

            try
            {
                //Create save folder
                if(!Directory.Exists(path + "/Save"))
                {
                    Directory.CreateDirectory(path + "/Save");
                }
                //Create save file for the month
                string _month = dt.ToString("MMMM");
                string _year = dt.ToString("yyyy");
                if (!File.Exists(path + "/Save/" + _month + _year + ".txt"))
                {
                    FileStream fs = new FileStream(path + "/Save/" + _month + _year + ".txt", FileMode.CreateNew);
                    fs.Close();
                    return "";
                } else
                {
                    return File.ReadAllText(path + "/Save/" + _month + _year + ".txt");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return "";
        }

        //returns the Saveobject
        public SaveObject GetSaveObject(DateTime dt)
        {
            try
            {
                SaveObject so = new SaveObject();
                string fileString = GetFileText(dt);
                if(fileString == "")
                {
                    return so;
                }
                SaveObject saveObject = JsonConvert.DeserializeObject<SaveObject>(fileString);
                return saveObject;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new SaveObject();

        }

        //Saves the SaveObject into the txt file
        public void WriteFileText(SaveObject so, DateTime dt)
        {
            string json = JsonConvert.SerializeObject(so);
            File.WriteAllText(GetSavePath(dt), json);
        }

        //returns the save path for the parsed date
        public string GetSavePath(DateTime dt)
        {
            string path = Path();
            string _month = dt.ToString("MMMM");
            string _year = dt.ToString("yyyy");
            return path + "/Save/" + _month + _year + ".txt";
        }

        public List<RepeatingTask> LoadRepeatingTask()
        {
            List<RepeatingTask> list = new List<RepeatingTask>();
            string path = Path() + "/Save/RepeatingTasks.txt";
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.CreateNew);
                fs.Close();
                return list;
            }
            else
            {
                string data = File.ReadAllText(path);
                if (data == null || data == "") {
                    return list;
                }
                RepeatingTaskList rtl = JsonConvert.DeserializeObject<RepeatingTaskList>(data);

                System.Diagnostics.Debug.WriteLine(rtl.RepeatingTasks[0].WeekDays[0].Count);
                return rtl.RepeatingTasks;
            }
        }

        public void SaveRepeatingTask(List<RepeatingTask> repeatingTask)
        {
            try
            {
                string location = Path() + "/Save/RepeatingTasks.txt";
                RepeatingTaskList rtl = new RepeatingTaskList();
                rtl.RepeatingTasks = repeatingTask;
                string json = JsonConvert.SerializeObject(rtl);
                File.WriteAllText(location, json);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


    }
}
