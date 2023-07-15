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
        public string GetFileText(DateTime dt)
        {

            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));

            //For the release build
            //string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory));


            Debug.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
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
            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            string _month = dt.ToString("MMMM");
            string _year = dt.ToString("yyyy");
            return path + "/Save/" + _month + _year + ".txt";
        }

    }
}
