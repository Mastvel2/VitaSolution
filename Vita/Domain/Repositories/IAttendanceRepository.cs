using Vita.Domain.Entities;
using Vita.Infrastructure;

namespace Vita.Domain.Repositories
{
    internal interface IAttendanceRepository
    {
        public List<Attendance> GetAttendancesByPatientId(Guid patientId);
        public void Add(Attendance attendance,AppDbContext context);
        public List<Attendance> GetAllAttendance();
        public void Delete(Guid attendanceId);
        public List<Attendance> GetAttendancesSortedByDiagnosis(bool ascending, Guid patientID);
        public List<Attendance> SearchAttendances(string searchField);
    }
}
