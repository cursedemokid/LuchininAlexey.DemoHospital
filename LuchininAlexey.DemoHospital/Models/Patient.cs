using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Events = new HashSet<Event>();
            Hospitalizations = new HashSet<Hospitalization>();
            MedicalAndDiagnosticProcedures = new HashSet<MedicalAndDiagnosticProcedure>();
        }

        public int Id { get; set; }
        public byte[]? Photo { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patonymic { get; set; }
        public int? Passport { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? PlaceOfWork { get; set; }
        public int? MedicalCardId { get; set; }
        public DateTime? LastVisitDate { get; set; }
        public DateTime? NextScheduledVisit { get; set; }
        public int? InsurancePolicyId { get; set; }
        public int? MedicalHistoryId { get; set; }

        public virtual InsurancePolicy? InsurancePolicy { get; set; }
        public virtual MedicalCard? MedicalCard { get; set; }
        public virtual MedicalHistory? MedicalHistory { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Hospitalization> Hospitalizations { get; set; }
        public virtual ICollection<MedicalAndDiagnosticProcedure> MedicalAndDiagnosticProcedures { get; set; }
    }
}
