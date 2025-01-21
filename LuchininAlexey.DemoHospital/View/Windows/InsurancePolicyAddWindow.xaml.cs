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
    /// Логика взаимодействия для InsurancePolicyAddWindow.xaml
    /// </summary>
    public partial class InsurancePolicyAddWindow : Window
    {
        public InsurancePolicyAddWindow()
        {
            InitializeComponent();

            InsurancePolicyOverDateTbx.IsReadOnly = true;
            InsurancePolicyOverDateTbx.Text = DateTime.Now.ToString();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            InsurancePolicy insurancePolicy = new InsurancePolicy
            {
                Number = InsurancePolicyNumberTbx.Text,
                OverDate = DateTime.Now,
                InsuranceCompany = InsurancePolicyCompanyTbx.Text
            };
            App.context.InsurancePolicies.Add(insurancePolicy);
            App.context.SaveChanges();



            DialogResult = true;
        }
    }
}
