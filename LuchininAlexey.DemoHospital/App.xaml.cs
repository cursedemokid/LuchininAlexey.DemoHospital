using LuchininAlexey.DemoHospital.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LuchininAlexey.DemoHospital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LuchininAlexeyDemoHospitalContext context = new LuchininAlexeyDemoHospitalContext();
        public static string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string configPath = Path.Combine(projectPath.Remove(projectPath.Length - 26), "AppData", "Users.json");
    }
}
