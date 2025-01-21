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

using static System.Net.Mime.MediaTypeNames;

namespace LuchininAlexey.DemoHospital.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddMedicalHistoryWindow.xaml
    /// </summary>
    public partial class AddMedicalHistoryWindow : Window
    {
        List<MedicalHistory> _medicalHistories = App.context.MedicalHistories.ToList();
        int? historyId;
        MedicalHistory _medicalHistory;
        public AddMedicalHistoryWindow(int? currentPatientHistoryId)
        {
            InitializeComponent();

            historyId = currentPatientHistoryId;
            _medicalHistory = _medicalHistories.FirstOrDefault(history => history.Id == historyId);
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            string category = (MedicalHistoryComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            if (category == "Аллергия")
            {
                _medicalHistory.Allergies = HistoryTxb.Text;
            }
            else if (category == "Хронические заболевания")
            {
                _medicalHistory.ChronicIllnesses = HistoryTxb.Text;
            }
            else if (category == "Предыдущие операции")
            {
                _medicalHistory.PreviousSurgeries = HistoryTxb.Text;
            }
            else if (category == "История болезней")
            {
                _medicalHistory.ChronicIllnesses = HistoryTxb.Text;
            }
            else if (category == "Привычки")
            {
                _medicalHistory.Habits = HistoryTxb.Text;
            }
            else if (category == "Вакцинации")
            {
                _medicalHistory.Vaccinations = HistoryTxb.Text;
            }
            App.context.SaveChanges(); 
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MedicalHistoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string category = (MedicalHistoryComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            if (category == "Аллергия")
            {
                HistoryTxb.Text = _medicalHistory.Allergies;
            }
            else if(category == "Хронические заболевания")
            {
                HistoryTxb.Text = _medicalHistory.ChronicIllnesses;
            }
            else if (category == "Предыдущие операции")
            {
                HistoryTxb.Text = _medicalHistory.PreviousSurgeries;
            }
            else if (category == "История болезней")
            {
                HistoryTxb.Text = _medicalHistory.ChronicIllnesses;
            }
            else if (category == "Привычки")
            {
                HistoryTxb.Text = _medicalHistory.Habits;
            }
            else if (category == "Вакцинации")
            {
                HistoryTxb.Text = _medicalHistory.Vaccinations;
            }
        }
    }
}
