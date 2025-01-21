using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class MedicalCard
    {
        public MedicalCard()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public DateTime? IssueDate { get; set; }
        public byte[]? Qr { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
