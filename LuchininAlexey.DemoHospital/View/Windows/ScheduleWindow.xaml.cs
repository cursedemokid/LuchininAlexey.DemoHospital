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
    /// Логика взаимодействия для ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        List<Schedule> _schedules = App.context.Schedules.ToList();
        List<Doctor> _doctors = App.context.Doctors.ToList();
        int? doctorId;
        public ScheduleWindow(int? id)
        {
            InitializeComponent();

            doctorId = id;

            ScheduleLV.ItemsSource = _schedules;

            DoctorTbl.Text = _doctors.FirstOrDefault(doctor => doctor.Id == doctorId).Name + " " + _doctors.FirstOrDefault(doctor => doctor.Id == doctorId).Surname;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dateStart;
            DateTime? dateFinish;

            DateTime datePickerValue = ScheduleDatePicker.SelectedDate.Value;
            int year = datePickerValue.Year;
            int month = datePickerValue.Month;
            int day = datePickerValue.Day;
            if (ScheduleCmb.SelectedItem.ToString() == "Дневная смена 6:00 - 18:00")
            {
                dateStart = new DateTime(year, month, day, 6, 0, 0);

                dateFinish = new DateTime(year, month, day, 18, 0, 0);
            }
            else
            {
                dateStart = new DateTime(year, month, day, 18, 0, 0);


                dateFinish = dateStart.Value.AddDays(0.5);
            }

            Schedule newSchedule = new Schedule
            {
                DoctorId = doctorId,
                DateStart = dateStart,
                DateFinish = dateFinish,
            };
            App.context.Schedules.Add(newSchedule);
            App.context.SaveChanges();
            Feedback.Information("Запись добавлена в расписание");
            _schedules = App.context.Schedules.ToList();
            ScheduleLV.ItemsSource = _schedules;
        }
    }
}
