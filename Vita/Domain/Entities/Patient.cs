using System.ComponentModel.DataAnnotations;

namespace Vita.Domain.Entities
{
    public class Patient
    {
        public Patient(Guid iDP, string surname, string name, string patronymic, DateTime birthday, string phone)
        {
            IDP = iDP;
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.birthday = DateTime.SpecifyKind(birthday.Date, DateTimeKind.Utc);
            this.phone = phone;
        }

        public Guid IDP { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public DateTime birthday { get; set; }
        public string phone { get; set; }
    }
}
