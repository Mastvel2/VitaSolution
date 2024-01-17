using Vita.Domain.Repositories;
using Vita.Domain.Entities;

namespace Vita.Infrastructure.Repositories
{
    internal class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext context;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AttendanceRepository"/>.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public AttendanceRepository(AppDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Attendance attendance, AppDbContext context)
        {
            context.Attendances.Add(attendance);
        }

        public void Delete(Guid attendanceId)
        {
            // Находим посещение по ID
            var attendanceToDelete = context.Attendances.Find(attendanceId);

            if (attendanceToDelete != null)
            {
                // Удаляем посещение из контекста данных
                context.Attendances.Remove(attendanceToDelete);

                // Сохраняем изменения в базе данных
                context.SaveChanges();
            }
        }

        public List<Attendance> GetAllAttendance()
        {
            try
            {
                var attendances = context.Attendances.ToList();
                return attendances;
            }
            catch (Exception ex)
            {
                // Вывод исключения
                MessageBox.Show($"Ошибка при получении данных о посещаемости: {ex.Message}");
                return new List<Attendance>();
            }
        }
        public List<Attendance> GetAttendancesByPatientId(Guid patientId)
        {
            try
            {
                var attendances = context.Attendances
                    .Where(a => a.IDP == patientId)
                    .ToList();

                return attendances;
            }
            catch (Exception ex)
            {
                // Обработка исключения
                MessageBox.Show($"Ошибка при получении данных о посещаемости: {ex.Message}");
                return new List<Attendance>();
            }
        }

        public List<Attendance> GetAttendancesSortedByDiagnosis(bool ascending, Guid patientID)
        {
            // Получаем все посещения из базы данных
            var attendance = context.Attendances.Where(a => a.IDP == patientID).ToList();

            // Сортируем посещения по диагнозу в указанном направлении
            if (ascending)
            {
                return attendance.OrderBy(p => p.diagnosis).ToList();
            }
            else
            {
                return attendance.OrderByDescending(p => p.diagnosis).ToList();
            }
        }

        public List<Attendance> SearchAttendances(string searchTerm)
        {
         return context.Attendances.Where(p => p.diagnosis.Contains(searchTerm)).ToList(); 
        }
    }
}
