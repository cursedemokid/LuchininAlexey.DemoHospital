using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class AmbulanceTeam
    {
        public AmbulanceTeam()
        {
            Hospitalizations = new HashSet<Hospitalization>();
        }

        public int Id { get; set; }
        public string? Driver { get; set; }
        public string? FirstDoctor { get; set; }
        public string? SecondDoctor { get; set; }

        public virtual ICollection<Hospitalization> Hospitalizations { get; set; }
    }
}
