using Vita.Domain.Entities;
using Vita.Infrastructure;

namespace Vita.Domain.Repositories
{
    public interface IPatientRepository
    {
        public void Add(Patient patient, AppDbContext context);
        public void Delete(Guid patientId);
        public List<Patient> GetAllPatients();
        public List<Patient> GetPatientsSortedByLastName(bool ascending);
        public List<Patient> SearchPatients(string searchField, string searchTerm);
        public Patient GetPatientById(Guid patientId);
    }
}
