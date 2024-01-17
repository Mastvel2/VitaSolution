using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vita.Domain.Entities;

namespace Vita.App.XML_Entities
{
    [Serializable]
    public class AttendanceXML
    {
        public AttendanceXML() { } // Добавьте пустой конструктор для сериализации

        public AttendanceXML(Attendance attendance)
        {
            IDA = attendance.IDA;
            AttendanceDate = attendance.attendanceDate;
            Diagnosis = attendance.diagnosis;
        }

        public Guid IDA { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Diagnosis { get; set; }
    }
}
