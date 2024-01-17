using System.ComponentModel;
using Vita.App.XML_Entities;
using Vita.App;
using Vita.Domain.Entities;
using Vita.Forms;
using Vita.Infrastructure;
using Vita.Infrastructure.Repositories;

namespace Vita
{
    public partial class PatientForm : Form
    {
        private BindingSource patientBindingSource;
        private readonly PatientRepository patientRepository;
        private readonly AppDbContext context;
        public PatientForm()
        {
            InitializeComponent();
            this.context = new AppDbContext(); // Инициализация context
            this.patientRepository = new PatientRepository(context);
            this.patientBindingSource = new BindingSource();
            this.PatientGridView.DataSource = this.patientBindingSource;
            PatientFormLoad(patientRepository);
        }

        private void PatientFormLoad(PatientRepository patientRepository)
        {
            List<Patient> patients = patientRepository.GetAllPatients();

            // Устанавливаем данные для BindingSource
            patientBindingSource.DataSource = patients;

            // Обновляем DataGridView
            PatientGridView.Refresh();
            // Вызываем метод для изменения названий столбцов
            CustomizeDataGridViewColumns();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Получение данных из TextBox
            string surname = SurnameTextBox.Text;
            string name = NameTextBox.Text;
            string patronymic = PatronymicTextBox.Text;
            DateTime birthday = DateTimePicker.Value;
            string phone = PhoneTextBox.Text;

            // Создание экземпляра Patient
            Patient newPatient = new Patient(Guid.NewGuid(), surname, name, patronymic, birthday, phone);

            // Добавление пациента в базу данных
            patientRepository.Add(newPatient, context); 

            // Сохранение изменений в базе данных
            context.SaveChanges();
            // Обновляем данные в DataGridView
            PatientFormLoad(patientRepository);
        }
        private void CustomizeDataGridViewColumns()
        {
            // Устанавливаем новые названия столбцов
            PatientGridView.Columns["IDP"].HeaderText = "ID";
            PatientGridView.Columns["surname"].HeaderText = "Фамилия";
            PatientGridView.Columns["name"].HeaderText = "Имя";
            PatientGridView.Columns["patronymic"].HeaderText = "Отчество";
            PatientGridView.Columns["birthday"].HeaderText = "Дата рождения";
            PatientGridView.Columns["phone"].HeaderText = "Телефон";
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (PatientGridView.SelectedRows.Count > 0)
            {
                // Получаем ID пациента из выделенной строки
                Guid patientId = (Guid)PatientGridView.SelectedRows[0].Cells["IDP"].Value;

                // Вызываем метод удаления из репозитория
                patientRepository.Delete(patientId);

                // Обновляем данные в DataGridView
                PatientFormLoad(patientRepository);
            }
        }

        private void ascending_button_Click(object sender, EventArgs e)
        {
            // Получить пациентов в возрастающем порядке по фамилии
            List<Patient> patientsAscending = patientRepository.GetPatientsSortedByLastName(true);
            // Устанавливаем данные для BindingSource
            patientBindingSource.DataSource = patientsAscending;
            // Обновляем данные в DataGridView
            PatientGridView.Refresh();
        }

        private void descending_button_Click(object sender, EventArgs e)
        {
            // Получить пациентов в убывающем порядке по фамилии
            List<Patient> patientsDescending = patientRepository.GetPatientsSortedByLastName(false);
            // Устанавливаем данные для BindingSource
            patientBindingSource.DataSource = patientsDescending;
            // Обновляем данные в DataGridView
            PatientGridView.Refresh();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string searchField = comboBoxSearch.SelectedItem?.ToString() ?? throw new InvalidOperationException("Выберите поле для поиска"); ;
            string searchTerm = textBoxSearch.Text;

            // Выполните поиск и обновите DataGridView
            List<Patient> searchResults = patientRepository.SearchPatients(searchField, searchTerm);

            // Устанавливаем данные для BindingSource
            patientBindingSource.DataSource = searchResults;

            // Обновляем данные в DataGridView
            PatientGridView.Refresh();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            //Сбрасываем значения полей
            comboBoxSearch.Text = string.Empty;
            textBoxSearch.Text = string.Empty;
            // Получите все пациентов и обновите DataGridView
            List<Patient> allPatients = patientRepository.GetAllPatients();
            patientBindingSource.DataSource = allPatients;

            // Обновляем данные в DataGridView
            PatientGridView.Refresh();
        }

        private void OpenAttendanceForm(Guid patientId)
        {
            // Создаём экземпляр формы посещений и передаем IDP пациента
            AttendanceForm attendanceForm = new AttendanceForm(patientId, this, context);

            // Открываем форму посещений
            attendanceForm.Show();
            // Скрытие формы пациентов
            this.Hide();
        }

        private void PatientGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < PatientGridView.Rows.Count)
            {
                DataGridViewRow selectedRow = PatientGridView.Rows[e.RowIndex];

                // Получение IDP выбранного пациента
                if (selectedRow.Cells["IDP"].Value is Guid patientId)
                {
                    // Открываем форму посещений, передавая IDP пациента
                    OpenAttendanceForm(patientId);
                }
            }
        }

        private void XMLAllButton_Click(object sender, EventArgs e)
        {
            // Получение списка всех пациентов
            List<Patient> allPatients = patientRepository.GetAllPatients();

            // Преобразование пациентов в объекты PatientXML
            List<PatientXML> patientsXMLList = new List<PatientXML>();
            foreach (var patient in allPatients)
            {
                patientsXMLList.Add(new PatientXML(patient, context));
            }

            // Сохранение списка пациентов в XML файл
            string filePath = Path.Combine(Application.StartupPath, "XML/patients.xml");
            XmlExporter.SavePatientsToXml(patientsXMLList, filePath);
            MessageBox.Show("Список пациентов успешно выгружен в XML файл.");
        }

        private void XMLButton_Click(object sender, EventArgs e)
        {
            // Проверка, есть ли выделенная строка в DataGridView
            if (PatientGridView.SelectedRows.Count > 0)
            {
                // Получение данных о выделенном пациенте
                DataGridViewRow selectedRow = PatientGridView.SelectedRows[0];
                Guid patientId = (Guid)selectedRow.Cells["IDP"].Value;
                Patient selectedPatient = patientRepository.GetPatientById(patientId);

                // Преобразование объекта пациента в объект PatientXML
                PatientXML selectedPatientXML = new PatientXML(selectedPatient, context);

                // Сохранение пациента в XML файл с именем "ФИО.xml"
                string filePath = Path.Combine(Application.StartupPath, $"XML/{selectedPatient.surname} {selectedPatient.name} {selectedPatient.patronymic}.xml");
                XmlExporter.SavePatientToXml(selectedPatientXML, filePath);
                MessageBox.Show($"Пациент {selectedPatient.surname} {selectedPatient.name} {selectedPatient.patronymic} успешно выгружен в XML файл.");
            }
            else
            {
                MessageBox.Show("Выберите пациента для выгрузки.");
            }
        }
    }
}
