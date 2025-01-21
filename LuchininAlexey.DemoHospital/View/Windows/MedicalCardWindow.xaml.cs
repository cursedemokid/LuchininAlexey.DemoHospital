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
    /// Логика взаимодействия для MedicalCardWindow.xaml
    /// </summary>
    public partial class MedicalCardWindow : Window
    {
        List<MedicalCard> _medicalCards = App.context.MedicalCards.ToList();
        public MedicalCardWindow(int? currentPatientCardId)
        {
            InitializeComponent();

            MedicalCardLV.ItemsSource = _medicalCards.Where(card => card.Id == currentPatientCardId);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
