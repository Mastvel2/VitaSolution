namespace Vita.Domain.Entities
{
    public class Attendance
    {
        public Attendance(Guid iDA, DateTime attendanceDate, string diagnosis,Guid IDP)
        {
            this.IDA = iDA;
            this.attendanceDate = DateTime.SpecifyKind(attendanceDate.Date, DateTimeKind.Utc);
            this.diagnosis = diagnosis;
            this.IDP = IDP;
        }

        public Guid IDA { get; set; }
        public DateTime attendanceDate { get; set; }
        public string diagnosis { get; set; }
        public Guid IDP { get; set; }
    }
}
