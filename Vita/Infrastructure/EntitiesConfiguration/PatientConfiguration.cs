using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vita.Domain.Entities;

namespace Vita.Infrastructure.EntitiesConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            // Устанавливаем первичный ключ для сущности Patient
            builder.HasKey(p => p.IDP);

            // Устанавливаем имя схемы и таблицы
            builder.ToTable("Patient", "public");

            builder.Property(p => p.IDP)
                .HasColumnName("IDP");

            builder.Property(p => p.surname)
                .HasColumnName("surname");

            builder.Property(p => p.name)
                .HasColumnName("name");

            builder.Property(p => p.patronymic)
                .HasColumnName("patronymyc");

            builder.Property(p => p.birthday)
            .HasColumnName("birthday");

            builder.Property(p => p.phone)
            .HasColumnName("phone");
        }
    }
}
