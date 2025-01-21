using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class InsurancePolicy
    {
        public InsurancePolicy()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string? Number { get; set; }
        public DateTime? OverDate { get; set; }
        public string? InsuranceCompany { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
