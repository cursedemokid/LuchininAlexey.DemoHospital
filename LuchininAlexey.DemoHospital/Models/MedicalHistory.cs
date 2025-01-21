using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class MedicalHistory
    {
        public MedicalHistory()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string? Allergies { get; set; }
        public string? ChronicIllnesses { get; set; }
        public string? PreviousSurgeries { get; set; }
        public string? HistoryOfIlnesses { get; set; }
        public string? HereditaryDiseases { get; set; }
        public string? Habits { get; set; }
        public string? PhysicalActivity { get; set; }
        public string? Nutrition { get; set; }
        public string? PsychologicalState { get; set; }
        public string? Vaccinations { get; set; }
        public string? CurrentMedications { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
