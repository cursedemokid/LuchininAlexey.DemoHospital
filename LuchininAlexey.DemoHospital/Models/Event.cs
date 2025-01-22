using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public string? EventName { get; set; }
        public DateTime? Date { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
