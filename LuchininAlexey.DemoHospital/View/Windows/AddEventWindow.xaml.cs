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
    /// Логика взаимодействия для AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        int? patientId;
        List<Patient> _patients = App.context.Patients.ToList();
        List<Doctor> _doctors = App.context.Doctors.ToList();
        List<Event> _events = App.context.Events.ToList();
        public AddEventWindow(int? id)
        {
            InitializeComponent();

            EventsLV.ItemsSource = _events;

            patientId = id;

            PatientNameTbl.Text = _patients.FirstOrDefault(patient => patient.Id == patientId).Name;
            PatientSurnameTbl.DataContext = _patients.FirstOrDefault(patient => patient.Id == patientId).Surname;

            DoctorsCmb.ItemsSource = _doctors;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime? eventDate = new DateTime();
            eventDate = EventDatePicker.SelectedDate;
            eventDate = eventDate.Value.AddHours(Convert.ToDouble(HoursTxb.Text));
            eventDate = eventDate.Value.AddMinutes(Convert.ToDouble(MinutesTxb.Text));

            Event newEvent = new Event
            {
                PatientId = patientId,
                DoctorId = Convert.ToInt32(DoctorsCmb.SelectedValue),
                EventName = EventNameTxb.Text,
                Date = eventDate

            };
            App.context.Events.Add(newEvent);
            App.context.SaveChanges();
            Feedback.Information("Мероприятие запланировано");

            EventsLV.ItemsSource = _events;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
