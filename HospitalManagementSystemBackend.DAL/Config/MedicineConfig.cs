using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.DAL.Config
{
    internal class MedicineConfig : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired();

            builder.HasData(
                new Medicine { Id = Guid.NewGuid(), Name = "Paracetamol" },
                new Medicine { Id = Guid.NewGuid(), Name = "Ibuprofen" },
                new Medicine { Id = Guid.NewGuid(), Name = "Loratadine" },
                new Medicine { Id = Guid.NewGuid(), Name = "Omeprazole" },
                new Medicine { Id = Guid.NewGuid(), Name = "Amoxicillin" },
                new Medicine { Id = Guid.NewGuid(), Name = "Simvastatin" },
                new Medicine { Id = Guid.NewGuid(), Name = "Metformin" },
                new Medicine { Id = Guid.NewGuid(), Name = "Warfarin" },
                new Medicine { Id = Guid.NewGuid(), Name = "Albuterol" },
                new Medicine { Id = Guid.NewGuid(), Name = "Fluoxetine" },
                new Medicine { Id = Guid.NewGuid(), Name = "Morphine" },
                new Medicine { Id = Guid.NewGuid(), Name = "Hydrochlorothiazide" },
                new Medicine { Id = Guid.NewGuid(), Name = "Amlodipine" },
                new Medicine { Id = Guid.NewGuid(), Name = "Prednisone" },
                new Medicine { Id = Guid.NewGuid(), Name = "Diazepam" });
        }
    }
}
