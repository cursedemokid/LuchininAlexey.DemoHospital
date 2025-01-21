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
    /// Логика взаимодействия для DoctorAdminWindow.xaml
    /// </summary>
    public partial class DoctorAdminWindow : Window
    {
        int patientId;
        int? currentPatientPolicyId;
        Patient patient = new Patient();
        List<Patient> _patients = App.context.Patients.ToList();
        public DoctorAdminWindow()
        {
            InitializeComponent();

            PatientLV.ItemsSource = _patients;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            patientId = Convert.ToInt32(ClientIdTbx.Text);
            if(_patients.FirstOrDefault(patient => patient.Id == patientId) != null)
            {
                PatientLV.ItemsSource = _patients.Where(patient => patient.Id == patientId);
            }
            else
            {
                PatientLV.ItemsSource = _patients;
            }
        }

        private void PolicyBtn_Click(object sender, RoutedEventArgs e)
        {
            patient = PatientLV.SelectedItem as Patient;
            currentPatientPolicyId = patient.InsurancePolicyId;
            InsurancePolicyWindow insurancePolicyWindow = new InsurancePolicyWindow(currentPatientPolicyId);
            insurancePolicyWindow.Show();
        }

        private void MedicalCardBtn_Click(object sender, RoutedEventArgs e)
        {
            patient = PatientLV.SelectedItem as Patient;
            int? currentPatientCardId = patient.MedicalCardId;
            MedicalCardWindow medicalCardWindow = new MedicalCardWindow(currentPatientCardId);
            medicalCardWindow.Show();

        }

        private void MedicalHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            patient = PatientLV.SelectedItem as Patient;
            int? currentPatientHistoryId = patient.MedicalHistoryId;
            MedicalHistoryWindow medicalHistoryWindow = new MedicalHistoryWindow(currentPatientHistoryId);
            medicalHistoryWindow.Show();

        }

        private void AddHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            patient = PatientLV.SelectedItem as Patient;
            int? currentPatientHistoryId = patient.MedicalHistoryId;
            AddMedicalHistoryWindow addMedicalHistoryWindow = new AddMedicalHistoryWindow(currentPatientHistoryId);
            addMedicalHistoryWindow.ShowDialog();
        }
    }
}
