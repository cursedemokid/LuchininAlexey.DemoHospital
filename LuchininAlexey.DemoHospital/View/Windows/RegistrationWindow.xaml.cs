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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        List<InsurancePolicy> _insurancePolicies = App.context.InsurancePolicies.ToList();
        List<MedicalCard> _medicalCards = App.context.MedicalCards.ToList();
        int insuranceId;
        public RegistrationWindow()
        {
            InitializeComponent();

            MedicalCardIdTbx.IsReadOnly = true;
            MedicalCardDateIssueTbx.IsReadOnly = true;

            InsuranceAddedCheckBox.IsEnabled = false;

            MedicalCardIdTbx.Text = (_medicalCards.Max(mC => mC.Id)+1).ToString();
            MedicalCardDateIssueTbx.Text = DateTime.Now.ToString();
        }

        private void InsurancePolicyBtn_Click(object sender, RoutedEventArgs e)
        {
            InsurancePolicyAddWindow insurancePolicyAddWindow = new InsurancePolicyAddWindow();
            if (insurancePolicyAddWindow.ShowDialog() == true)
            {
                insuranceId = _insurancePolicies.Max(iP => iP.Id);
                InsuranceAddedCheckBox.IsChecked = true;
            }
        }

        private void AgreeBtn_Click(object sender, RoutedEventArgs e)
        {
            MedicalCard medicalCard = new MedicalCard
            {
                Id = Convert.ToInt32(MedicalCardIdTbx.Text),
                IssueDate = Convert.ToDateTime(MedicalCardDateIssueTbx.Text)
            };
            App.context.MedicalCards.Add(medicalCard);
            //App.context.SaveChanges();

            string gender;

            if (GenderFemaleCheckBox.IsChecked == true)
            {
                gender = "F";
            }
            else
            {
                gender = "M";
            }


                Patient newPatient = new Patient
                {
                    Name = NameTbx.Text,
                    Surname = SurnameTbx.Text,
                    Patonymic = PatonymicTbx.Text,
                    Passport = Convert.ToInt32(PassportTbx.Text),
                    DateOfBirth = Convert.ToDateTime(DateOfBirthDP.SelectedDate),
                    Gender = gender,
                    Address = AddressTbx.Text,
                    Phone = PhoneTbx.Text,
                    Email = EmailTbx.Text,
                    PlaceOfWork = PlaceOfWorkTbx.Text,
                    MedicalCardId = Convert.ToInt32(MedicalCardIdTbx.Text),
                    InsurancePolicyId = insuranceId
                };
                App.context.Patients.Add(newPatient);
                App.context.SaveChanges();

                Feedback.Information("Пользователь успешно добавлен");
            DialogResult = true;

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GenderMaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GenderFemaleCheckBox.IsEnabled = false;
        }

        private void GenderFemaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GenderMaleCheckBox.IsEnabled = false;
        }

        private void GenderFemaleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GenderMaleCheckBox.IsEnabled = true;
        }

        private void GenderMaleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GenderFemaleCheckBox.IsEnabled = true;
        }
    }
}
