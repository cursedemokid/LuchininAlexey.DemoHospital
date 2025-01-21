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
    /// Логика взаимодействия для HospitalizationWindow.xaml
    /// </summary>
    public partial class HospitalizationWindow : Window
    {
        List<Hospitalization> _hospitalizations = App.context.Hospitalizations.ToList();
        public HospitalizationWindow()
        {
            InitializeComponent();

            PatientLV.ItemsSource = _hospitalizations;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PatientIdTbx.Text))
            {
                PatientLV.ItemsSource = _hospitalizations;
            }
            else
            {
                PatientLV.ItemsSource = _hospitalizations.Where(patients => patients.Patient.Id == Convert.ToInt32(PatientIdTbx.Text));

            }

        }
        private void NewHospitalizationBtn_Click(object sender, RoutedEventArgs e)
        {
            NewHospitalizationWindow newHospitalizationWindow = new NewHospitalizationWindow();
            newHospitalizationWindow.ShowDialog();
        }

        private void CancelHospitalizationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PatientLV.SelectedItem == null)
            {
                Feedback.Error("Выберите госпитализацию");

            }
            else
            {
                Hospitalization hospitalizationChange = new Hospitalization();
                hospitalizationChange = PatientLV.SelectedItem as Hospitalization;
                hospitalizationChange.IsActive = false;
                App.context.SaveChanges();
                Feedback.Information("Госпитализация отменена");
            }
        }

    }
}
