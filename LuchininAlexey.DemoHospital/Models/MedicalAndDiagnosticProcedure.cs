using System;
using System.Collections.Generic;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class MedicalAndDiagnosticProcedure
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public DateTime? ProcedureDate { get; set; }
        public string? Doctor { get; set; }
        public string? TypeOfProcedure { get; set; }
        public string? NameOfProcedure { get; set; }
        public string? ProcedureResults { get; set; }
        public string? Recommendations { get; set; }
        public decimal? Cost { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
