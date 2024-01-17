using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vita.Domain.Entities;
using Vita.Infrastructure;


namespace Vita.App.XML_Entities
{
    
    [Serializable]
    public class PatientXML
    {
        private AppDbContext context;
        public PatientXML() { } // Добавьте пустой конструктор для сериализации

        public PatientXML(Patient patient,AppDbContext context)
        {
            this.context = context;
            IDP = patient.IDP;
            Surname = patient.surname;
            Name = patient.name;
            Patronymic = patient.patronymic;
            Birthday = patient.birthday;
            Phone = patient.phone;

            Attendances = GetAttendanceXMLList(patient.IDP);
        }

        public Guid IDP { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }

        [XmlElement("Attendances")]
        public List<AttendanceXML> Attendances { get; set; }

        private List<AttendanceXML> GetAttendanceXMLList(Guid patientId)
        {
            // Получить список посещений для данного пациента
            List<Attendance> attendances = GetAttendancesForPatient(patientId);

            // Преобразовать в список AttendanceXML
            List<AttendanceXML> attendanceXMLList = new List<AttendanceXML>();
            foreach (var attendance in attendances)
            {
                attendanceXMLList.Add(new AttendanceXML(attendance));
            }

            return attendanceXMLList;
        }

        private List<Attendance> GetAttendancesForPatient(Guid patientId)
        {
            try
            {
                // Используйте LINQ для получения посещений для данного пациента
                var attendances = context.Attendances
                    .Where(a => a.IDP == patientId)
                    .ToList();

                return attendances;
            }
            catch (Exception ex)
            {
                // Обработка исключения
                MessageBox.Show($"Error retrieving attendances for patient: {ex.Message}");
                return new List<Attendance>();
            }
        }
    }
}
