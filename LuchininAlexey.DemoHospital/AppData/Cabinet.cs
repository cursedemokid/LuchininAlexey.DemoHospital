using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LuchininAlexey.DemoHospital.AppData
{
    public class Cabinet : Button
    {
        public string Named { get; set; }
        public List<Person>? Persons { get; set; }

    }

}
