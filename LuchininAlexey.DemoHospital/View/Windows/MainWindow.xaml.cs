using LuchininAlexey.DemoHospital.View.Windows;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LuchininAlexey.DemoHospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            int windowId;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }

        private void HospitalizationBtn_Click(object sender, RoutedEventArgs e)
        {
            HospitalizationWindow hospitalizationWindow = new HospitalizationWindow();
            hospitalizationWindow.ShowDialog();
        }

        private void DoctorAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            windowId = 0;
            AuthorizationWindow authWindow = new AuthorizationWindow(windowId);
            authWindow.ShowDialog();
        }

        private void ScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            windowId = 1;
            AuthorizationWindow authWindow = new AuthorizationWindow(windowId);
            authWindow.ShowDialog();
        }
    }
}
