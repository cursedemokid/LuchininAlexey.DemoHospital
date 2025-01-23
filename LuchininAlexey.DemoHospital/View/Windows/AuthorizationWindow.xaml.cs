using LuchininAlexey.DemoHospital.AppData;
using LuchininAlexey.DemoHospital.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LuchininAlexey.DemoHospital.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        List<Doctor> _doctors = App.context.Doctors.ToList();
        int windowId;
        public AuthorizationWindow(int id)
        {
            InitializeComponent();

            windowId = id;
        }


        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (windowId == 0)
            {
                Doctor doctor = _doctors.FirstOrDefault(doctor => doctor.Password == PasswordTbx.Text && doctor.Login == LoginTbx.Text);
                if (doctor == null)
                {
                    Feedback.Error("Учетная запись не найдена");
                }
                else
                {
                    DoctorAdminWindow doctorAdminWindow = new DoctorAdminWindow();
                    doctorAdminWindow.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                Doctor doctor = _doctors.FirstOrDefault(doctor => doctor.Password == PasswordTbx.Text && doctor.Login == LoginTbx.Text);
                if (doctor == null)
                {
                    Feedback.Error("Учетная запись не найдена");
                }
                else
                {
                    ScheduleWindow scheduleWindow = new ScheduleWindow(doctor.Id);
                    scheduleWindow.ShowDialog();
                    this.Close();
            }
        }
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {

    }
}
}
