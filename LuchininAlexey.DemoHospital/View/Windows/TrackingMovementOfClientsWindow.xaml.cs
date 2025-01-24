using LuchininAlexey.DemoHospital.AppData;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LuchininAlexey.DemoHospital.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для TrackingMovementOfClientsWindow.xaml
    /// </summary>
    public partial class TrackingMovementOfClientsWindow : Window
    {
        string response = File.ReadAllText(Person.JSON_PATH);
        List<Person> _people;
        WrapPanel _ellipses;

        public TrackingMovementOfClientsWindow()
        {
            InitializeComponent();

            _people = JsonConvert.DeserializeObject<List<Person>>(response);

            PersonLV.ItemsSource = _people;

            _ellipses = new WrapPanel() { Orientation = Orientation.Horizontal };

            DirectionCalculate();




        }

        public void DirectionCalculate()
        {
            AddWrapPanels();
            foreach (var button in ButtonsGrid.Children)
            {
                if (button is Button)
                {
                    Button btn = button as Button;
                    if (_people.FirstOrDefault(men => men.LastSecurityPointNumber == Convert.ToInt32(btn.Tag)) != null)
                    {
                        foreach (Person person in _people)
                        {
                            if (person.LastSecurityPointNumber == Convert.ToInt32(btn.Tag) && person.LastSecurityPointDirection == "in")
                            {
                                Ellipse ellipse = new Ellipse() { Height = 10.0, Width = 10.0 };
                                if (person.PersonRole == "Сотрудник")
                                {
                                    ellipse.Fill = Brushes.Blue;
                                }
                                else
                                {
                                    ellipse.Fill = Brushes.Green;
                                }

                                if (person.LastSecurityPointNumber != Convert.ToInt32(btn.Tag) - 1 && person.LastSecurityPointDirection == "in")
                                {
                                    _ellipses = new WrapPanel() { Orientation = Orientation.Horizontal };
                                }

                                _ellipses.Children.Add(ellipse);
                            }
                        }
                        btn.Content = _ellipses;
                    }
                }
            }
        }

        public void AddWrapPanels()
        {
            int count;
            foreach (var button in ButtonsGrid.Children)
            {
                _ellipses = new WrapPanel() { Orientation = Orientation.Horizontal };
                if (button is Button)
                {
                    Button btn = button as Button;
                    btn.Content = _ellipses;
                }
            }
        }

    }
}
