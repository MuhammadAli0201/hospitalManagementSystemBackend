﻿using HospitalManagementSystemBackend.DAL.Config;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.DAL
{
    public class HMSDbContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientDoctorScript> PatientScript { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<PatientDoctorScriptMedicine> PatientScriptMedicine { get; set; }
        public DbSet<PatientDoctorToken> PatientToken { get; set; }
        public HMSDbContext(DbContextOptions<HMSDbContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PatientConfig());
            modelBuilder.ApplyConfiguration(new DoctorConfig());
            modelBuilder.ApplyConfiguration(new GenderConfig());
            modelBuilder.ApplyConfiguration(new PatientDoctorScriptConfig());
            modelBuilder.ApplyConfiguration(new MedicineConfig());
            modelBuilder.ApplyConfiguration(new PatientDoctorScriptMedicineConfig());
            modelBuilder.ApplyConfiguration(new PatientDoctorTokenConfig());
        }

    }
}
