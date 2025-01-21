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
    /// Логика взаимодействия для MedicalHistoryWindow.xaml
    /// </summary>
    public partial class MedicalHistoryWindow : Window
    {
        List<MedicalHistory> _medicalHistories = App.context.MedicalHistories.ToList();
        public MedicalHistoryWindow(int? currentPatientHistoryId)
        {
            InitializeComponent();

            MedicalHistoryLV.ItemsSource = _medicalHistories.Where(history => history.Id == currentPatientHistoryId);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
