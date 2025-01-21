using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Hospitalizations = new HashSet<Hospitalization>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Speciality { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Hospitalization> Hospitalizations { get; set; }
    }
}
