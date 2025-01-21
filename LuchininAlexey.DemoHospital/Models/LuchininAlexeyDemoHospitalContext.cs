using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LuchininAlexey.DemoHospital.Models
{
    public partial class LuchininAlexeyDemoHospitalContext : DbContext
    {
        public LuchininAlexeyDemoHospitalContext()
        {
        }

        public LuchininAlexeyDemoHospitalContext(DbContextOptions<LuchininAlexeyDemoHospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmbulanceTeam> AmbulanceTeams { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Hospitalization> Hospitalizations { get; set; } = null!;
        public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; } = null!;
        public virtual DbSet<MedicalAndDiagnosticProcedure> MedicalAndDiagnosticProcedures { get; set; } = null!;
        public virtual DbSet<MedicalCard> MedicalCards { get; set; } = null!;
        public virtual DbSet<MedicalHistory> MedicalHistories { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQL;Database=Luchinin.Alexey.DemoHospital;Trusted_Connection=true");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmbulanceTeam>(entity =>
            {
                entity.ToTable("AmbulanceTeam");

                entity.Property(e => e.Driver).HasMaxLength(100);

                entity.Property(e => e.FirstDoctor).HasMaxLength(100);

                entity.Property(e => e.SecondDoctor).HasMaxLength(100);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Login).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Speciality).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);
            });

            modelBuilder.Entity<Hospitalization>(entity =>
            {
                entity.ToTable("Hospitalization");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.Diagnosis).HasMaxLength(100);

                entity.Property(e => e.Terms).HasMaxLength(100);

                entity.Property(e => e.TimeLong).HasMaxLength(100);

                entity.HasOne(d => d.AmbulanceTeam)
                    .WithMany(p => p.Hospitalizations)
                    .HasForeignKey(d => d.AmbulanceTeamId)
                    .HasConstraintName("FK_Hospitalization_AmbulanceTeam");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Hospitalizations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Hospitalization_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Hospitalizations)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Hospitalization_Patient");
            });

            modelBuilder.Entity<InsurancePolicy>(entity =>
            {
                entity.ToTable("InsurancePolicy");

                entity.Property(e => e.InsuranceCompany).HasMaxLength(100);

                entity.Property(e => e.Number).HasMaxLength(16);

                entity.Property(e => e.OverDate).HasColumnType("date");
            });

            modelBuilder.Entity<MedicalAndDiagnosticProcedure>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Doctor).HasMaxLength(100);

                entity.Property(e => e.NameOfProcedure).HasMaxLength(100);

                entity.Property(e => e.ProcedureDate).HasColumnType("date");

                entity.Property(e => e.ProcedureResults).HasMaxLength(100);

                entity.Property(e => e.Recommendations).HasMaxLength(100);

                entity.Property(e => e.TypeOfProcedure).HasMaxLength(100);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicalAndDiagnosticProcedures)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_MedicalAndDiagnosticProcedures_Patient");
            });

            modelBuilder.Entity<MedicalCard>(entity =>
            {
                entity.ToTable("MedicalCard");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.Qr)
                    .HasColumnType("image")
                    .HasColumnName("QR");
            });

            modelBuilder.Entity<MedicalHistory>(entity =>
            {
                entity.ToTable("MedicalHistory");

                entity.Property(e => e.Allergies).HasMaxLength(100);

                entity.Property(e => e.ChronicIllnesses).HasMaxLength(100);

                entity.Property(e => e.CurrentMedications).HasMaxLength(100);

                entity.Property(e => e.Habits).HasMaxLength(100);

                entity.Property(e => e.HereditaryDiseases).HasMaxLength(100);

                entity.Property(e => e.HistoryOfIlnesses).HasMaxLength(100);

                entity.Property(e => e.Nutrition).HasMaxLength(100);

                entity.Property(e => e.PhysicalActivity).HasMaxLength(100);

                entity.Property(e => e.PreviousSurgeries).HasMaxLength(100);

                entity.Property(e => e.PsychologicalState).HasMaxLength(100);

                entity.Property(e => e.Vaccinations).HasMaxLength(100);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.LastVisitDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.NextScheduledVisit).HasColumnType("date");

                entity.Property(e => e.Patonymic).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PlaceOfWork).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.HasOne(d => d.InsurancePolicy)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.InsurancePolicyId)
                    .HasConstraintName("FK_Patient_InsurancePolicy");

                entity.HasOne(d => d.MedicalCard)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.MedicalCardId)
                    .HasConstraintName("FK_Patient_MedicalCard");

                entity.HasOne(d => d.MedicalHistory)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.MedicalHistoryId)
                    .HasConstraintName("FK_Patient_MedicalHistory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
