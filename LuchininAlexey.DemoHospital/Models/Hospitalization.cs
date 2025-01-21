using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class Hospitalization
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? AmbulanceTeamId { get; set; }
        public DateTime? Date { get; set; }
        public int? PatientId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Department { get; set; }
        public string? Terms { get; set; }
        public string? TimeLong { get; set; }
        public bool? IsActive { get; set; }

        public virtual AmbulanceTeam? AmbulanceTeam { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
