using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }

        public virtual Doctor? Doctor { get; set; }
    }
}
