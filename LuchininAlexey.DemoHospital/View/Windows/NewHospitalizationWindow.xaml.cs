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
    /// Логика взаимодействия для NewHospitalizationWindow.xaml
    /// </summary>
    public partial class NewHospitalizationWindow : Window
    {
        List<Doctor> _doctors = App.context.Doctors.ToList();
        public NewHospitalizationWindow()
        {
            InitializeComponent();

            DoctorsComboBox.ItemsSource = _doctors;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {


            Hospitalization newHospitalization = new Hospitalization
            {
                DoctorId = Convert.ToInt32(DoctorsComboBox.SelectedValue),
                Date = DateTime.Now,
                PatientId = Convert.ToInt32(PatientIdTbx.Text),
                Diagnosis = DiagnosisTbx.Text,
                TimeLong = TimeLongTbx.Text,
                Department = DepartmentTbx.Text,
                Terms = TermsComboBox.Text,
                IsActive = true

            };
            App.context.Hospitalizations.Add(newHospitalization);
            App.context.SaveChanges();
            Feedback.Information("Госпитализация добавлена");
        }
    }
}
