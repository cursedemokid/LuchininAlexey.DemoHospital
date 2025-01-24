using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchininAlexey.DemoHospital.AppData
{
    public class Person
    {
        public const string JSON_PATH = "O:\\LuchininAlexey\\LuchininAlexey.DemoHospital\\LuchininAlexey.DemoHospital\\AppData\\Users.json";
        public string PersonCode { get; set; }
        public string PersonRole { get; set; }
        public int LastSecurityPointNumber { get; set; }
        public string LastSecurityPointDirection { get; set; }
        public DateTime LastSecurityPointTime { get; set; }


    }
}
