using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dashboard.Models;
using Dashboard.ViewModels;
using Newtonsoft;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dashboard.Services
{

    public partial class TaskModulServices
    {
        static string _filePath = "tasks.json";
         static TaskModulServices()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dataDir = Path.Combine(baseDir, "Data");
            _filePath = Path.Combine(dataDir, "tasks.json");

            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }
        }
        public static ObservableCollection<TasksModel> LoadTaskModulS()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
                return new ObservableCollection<TasksModel>();
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<ObservableCollection<TasksModel>>(json);
            }
            catch
            {
                return new ObservableCollection<TasksModel>();
            }

        }

        public static void SaveTaskModuls(ObservableCollection<TasksModel> t)
        {
            string json = JsonSerializer.Serialize(t);
            File.WriteAllText(_filePath, json);
        }
    }
}