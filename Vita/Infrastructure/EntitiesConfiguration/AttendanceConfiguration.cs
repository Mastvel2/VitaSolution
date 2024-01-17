using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Vita.Domain.Entities;

namespace Vita.Infrastructure.EntitiesConfiguration
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            // Устанавливаем первичный ключ для сущности Attendance
            builder.HasKey(a => a.IDA);

            // Устанавливаем имя схемы и таблицы
            builder.ToTable("Attendance", "public");

            builder.Property(a => a.attendanceDate)
                .HasColumnName("attendanceDate");

            builder.Property(a => a.diagnosis)
                .HasColumnName("diagnosis");

            builder.Property(a => a.IDP)
                .HasColumnName("IDP");
        }
    }
}
