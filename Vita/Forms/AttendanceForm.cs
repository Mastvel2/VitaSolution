using Vita.Infrastructure.Repositories;
using Vita.Infrastructure;
using Vita.Domain.Entities;
using Vita.Domain.Repositories;
using System.Windows.Forms;

namespace Vita.Forms
{
    public partial class AttendanceForm : Form
    {
        private BindingSource attendanceBindingSource;
        private readonly AttendanceRepository attendanceRepository;
        private readonly AppDbContext context;
        private PatientForm patientForm;
        private Guid patientID;
        public AttendanceForm(Guid patientID, PatientForm patientForm,AppDbContext context)
        {
            InitializeComponent();
            this.patientForm = patientForm;
            this.context = context;
            this.attendanceRepository = new AttendanceRepository(context);
            this.patientID = patientID;

            // Инициализация источника данных для посещений пациента
            this.attendanceBindingSource = new BindingSource();
            this.AttendanceGridView.DataSource = this.attendanceBindingSource;

            // Загрузка данных посещений пациента
            LoadPatientAttendances(patientID);
        }
        private void CustomizeDataGridViewColumns()
        {
            // Устанавливаем новые названия столбцов
            AttendanceGridView.Columns["IDA"].HeaderText = "ID";
            AttendanceGridView.Columns["diagnosis"].HeaderText = "Диагноз";
            AttendanceGridView.Columns["attendanceDate"].HeaderText = "Дата посещения";
            AttendanceGridView.Columns["IDP"].HeaderText = "ID пациента";
        }

        private void LoadPatientAttendances(Guid patientId)
        {
            // Получение список посещений для конкретного пациента
            List<Attendance> patientAttendances = attendanceRepository.GetAttendancesByPatientId(patientId);

            // Установка данных для BindingSource
            attendanceBindingSource.DataSource = patientAttendances;

            // Обновление DataGridView
            AttendanceGridView.Refresh();
            // Вызываем метод для изменения названий столбцов
            CustomizeDataGridViewColumns();
        }

        private void AttendanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            patientForm.Show();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Получение данных из TextBox
            string diagnosis = DiagnosisTextBox.Text;
            DateTime attendanceDate = DateTimePicker.Value;

            // Создание экземпляра Attendance
            Attendance newAttendance = new Attendance(Guid.NewGuid(), attendanceDate, diagnosis, patientID);

            // Добавление пациента в базу данных
            attendanceRepository.Add(newAttendance, context);

            // Сохранение изменений в базе данных
            context.SaveChanges();
            // Обновляем данные в DataGridView
            LoadPatientAttendances(patientID);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            {
                if (AttendanceGridView.SelectedRows.Count > 0)
                {
                    // Получаем ID пациента из выделенной строки
                    Guid attendanceId = (Guid)AttendanceGridView.SelectedRows[0].Cells["IDA"].Value;

                    // Вызываем метод удаления из репозитория
                    attendanceRepository.Delete(attendanceId);
                    // Сохранение изменений в базе данных
                    context.SaveChanges();
                    // Обновляем данные в DataGridView
                    LoadPatientAttendances(patientID);
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchTextBox.Text;

            // Выполняем поиск и обновляем DataGridView
            List<Attendance> searchResults = attendanceRepository.SearchAttendances(searchTerm);

            // Устанавливаем данные для BindingSource
            attendanceBindingSource.DataSource = searchResults;

            // Обновляем данные в DataGridView
            AttendanceGridView.Refresh();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //Сбрасываем значение поля
            SearchTextBox.Text = string.Empty;
            // Получаем все посещения и обновляем DataGridView
            List<Attendance> allAttendances = attendanceRepository.GetAttendancesByPatientId(patientID);
            attendanceBindingSource.DataSource = allAttendances;

            // Обновляем данные в DataGridView
            AttendanceGridView.Refresh();
        }

        private void AscendingSortButton_Click(object sender, EventArgs e)
        {
            // Получаем посещения в возрастающем порядке по диагнозу
            List<Attendance> patientsAscending = attendanceRepository.GetAttendancesSortedByDiagnosis(true,patientID);
            // Устанавливаем данные для BindingSource
            attendanceBindingSource.DataSource = patientsAscending;
            // Обновляем данные в DataGridView
            AttendanceGridView.Refresh();
        }

        private void DescendingSortButton_Click(object sender, EventArgs e)
        {
            // Получаем посещения в возрастающем порядке по диагнозу
            List<Attendance> patientsAscending = attendanceRepository.GetAttendancesSortedByDiagnosis(false, patientID);
            // Устанавливаем данные для BindingSource
            attendanceBindingSource.DataSource = patientsAscending;
            // Обновляем данные в DataGridView
            AttendanceGridView.Refresh();
        }
    }
}
