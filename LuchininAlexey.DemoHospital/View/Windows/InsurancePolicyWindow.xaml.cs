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
    /// Логика взаимодействия для InsurancePolicyWindow.xaml
    /// </summary>
    public partial class InsurancePolicyWindow : Window
    {
        List<Patient> _patients = App.context.Patients.ToList();
        List<InsurancePolicy> _insurancePolicies = App.context.InsurancePolicies.ToList();
        public InsurancePolicyWindow(int? currentPatientId)
        {
            InitializeComponent();

            PolicyLV.ItemsSource = _insurancePolicies.Where(insurance => insurance.Id == currentPatientId).ToList();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
