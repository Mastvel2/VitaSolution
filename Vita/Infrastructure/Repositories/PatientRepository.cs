using Vita.Domain.Repositories;
using Vita.Domain.Entities;

namespace Vita.Infrastructure.Repositories
{
    internal class PatientRepository : IPatientRepository
    {
        private AppDbContext context;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PatientRepository"/>.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public PatientRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Patient patient, AppDbContext context)
        {
            context.Patients.Add(patient);
        }

        public void Delete(Guid patientId)
        {
            // Находим пациента по ID
            var patientToDelete = context.Patients.Find(patientId);

            if (patientToDelete != null)
            {
                // Удаляем пациента из контекста данных
                context.Patients.Remove(patientToDelete);

                // Сохраняем изменения в базе данных
                context.SaveChanges();
            }
        }

        public List<Patient> GetAllPatients()
        {
            try
            {
                var patients = context.Patients.ToList();
                return patients;
            }
            catch (Exception ex)
            {
                // Вывод исключения
                MessageBox.Show($"Ошибка при поиске пациентов: {ex.Message}");
                return new List<Patient>();
            }
        }
        public List<Patient> GetPatientsSortedByLastName(bool ascending)
        {    
            // Получаем всех пациентов из базы данных
            var patients = context.Patients.ToList();

            // Сортируем пациентов по фамилии в указанном направлении
            if (ascending)
            {
                return patients.OrderBy(p => p.surname).ToList();
            }
            else
            {
                return patients.OrderByDescending(p => p.surname).ToList();
            }
        }
        public List<Patient> SearchPatients(string searchField, string searchTerm)
        {
            switch (searchField)
            {
                case "Фамилия":
                    return context.Patients.Where(p => p.surname.Contains(searchTerm)).ToList();
                case "Имя":
                    return context.Patients.Where(p => p.name.Contains(searchTerm)).ToList();
                case "Отчество":
                    return context.Patients.Where(p => p.patronymic.Contains(searchTerm)).ToList();
                case "Телефон":
                    return context.Patients.Where(p => p.phone.Contains(searchTerm)).ToList();
                default:
                    return new List<Patient>();
            }
        }
        public Patient GetPatientById(Guid patientId)
        {
            try
            {
                var patient = context.Patients
                    .FirstOrDefault(p => p.IDP == patientId);

                return patient;
            }
            catch (Exception ex)
            {
                // Обработка исключения
                MessageBox.Show($"Ошибка при поиске пациента по идентификатору: {ex.Message}");
                return null; // Возвращаем null в случае ошибки
            }
        }
    }
}
