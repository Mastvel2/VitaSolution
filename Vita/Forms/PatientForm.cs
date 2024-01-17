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
            this.context = new AppDbContext(); // ������������� context
            this.patientRepository = new PatientRepository(context);
            this.patientBindingSource = new BindingSource();
            this.PatientGridView.DataSource = this.patientBindingSource;
            PatientFormLoad(patientRepository);
        }

        private void PatientFormLoad(PatientRepository patientRepository)
        {
            List<Patient> patients = patientRepository.GetAllPatients();

            // ������������� ������ ��� BindingSource
            patientBindingSource.DataSource = patients;

            // ��������� DataGridView
            PatientGridView.Refresh();
            // �������� ����� ��� ��������� �������� ��������
            CustomizeDataGridViewColumns();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // ��������� ������ �� TextBox
            string surname = SurnameTextBox.Text;
            string name = NameTextBox.Text;
            string patronymic = PatronymicTextBox.Text;
            DateTime birthday = DateTimePicker.Value;
            string phone = PhoneTextBox.Text;

            // �������� ���������� Patient
            Patient newPatient = new Patient(Guid.NewGuid(), surname, name, patronymic, birthday, phone);

            // ���������� �������� � ���� ������
            patientRepository.Add(newPatient, context); 

            // ���������� ��������� � ���� ������
            context.SaveChanges();
            // ��������� ������ � DataGridView
            PatientFormLoad(patientRepository);
        }
        private void CustomizeDataGridViewColumns()
        {
            // ������������� ����� �������� ��������
            PatientGridView.Columns["IDP"].HeaderText = "ID";
            PatientGridView.Columns["surname"].HeaderText = "�������";
            PatientGridView.Columns["name"].HeaderText = "���";
            PatientGridView.Columns["patronymic"].HeaderText = "��������";
            PatientGridView.Columns["birthday"].HeaderText = "���� ��������";
            PatientGridView.Columns["phone"].HeaderText = "�������";
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (PatientGridView.SelectedRows.Count > 0)
            {
                // �������� ID �������� �� ���������� ������
                Guid patientId = (Guid)PatientGridView.SelectedRows[0].Cells["IDP"].Value;

                // �������� ����� �������� �� �����������
                patientRepository.Delete(patientId);

                // ��������� ������ � DataGridView
                PatientFormLoad(patientRepository);
            }
        }

        private void ascending_button_Click(object sender, EventArgs e)
        {
            // �������� ��������� � ������������ ������� �� �������
            List<Patient> patientsAscending = patientRepository.GetPatientsSortedByLastName(true);
            // ������������� ������ ��� BindingSource
            patientBindingSource.DataSource = patientsAscending;
            // ��������� ������ � DataGridView
            PatientGridView.Refresh();
        }

        private void descending_button_Click(object sender, EventArgs e)
        {
            // �������� ��������� � ��������� ������� �� �������
            List<Patient> patientsDescending = patientRepository.GetPatientsSortedByLastName(false);
            // ������������� ������ ��� BindingSource
            patientBindingSource.DataSource = patientsDescending;
            // ��������� ������ � DataGridView
            PatientGridView.Refresh();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string searchField = comboBoxSearch.SelectedItem?.ToString() ?? throw new InvalidOperationException("�������� ���� ��� ������"); ;
            string searchTerm = textBoxSearch.Text;

            // ��������� ����� � �������� DataGridView
            List<Patient> searchResults = patientRepository.SearchPatients(searchField, searchTerm);

            // ������������� ������ ��� BindingSource
            patientBindingSource.DataSource = searchResults;

            // ��������� ������ � DataGridView
            PatientGridView.Refresh();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            //���������� �������� �����
            comboBoxSearch.Text = string.Empty;
            textBoxSearch.Text = string.Empty;
            // �������� ��� ��������� � �������� DataGridView
            List<Patient> allPatients = patientRepository.GetAllPatients();
            patientBindingSource.DataSource = allPatients;

            // ��������� ������ � DataGridView
            PatientGridView.Refresh();
        }

        private void OpenAttendanceForm(Guid patientId)
        {
            // ������ ��������� ����� ��������� � �������� IDP ��������
            AttendanceForm attendanceForm = new AttendanceForm(patientId, this, context);

            // ��������� ����� ���������
            attendanceForm.Show();
            // ������� ����� ���������
            this.Hide();
        }

        private void PatientGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < PatientGridView.Rows.Count)
            {
                DataGridViewRow selectedRow = PatientGridView.Rows[e.RowIndex];

                // ��������� IDP ���������� ��������
                if (selectedRow.Cells["IDP"].Value is Guid patientId)
                {
                    // ��������� ����� ���������, ��������� IDP ��������
                    OpenAttendanceForm(patientId);
                }
            }
        }

        private void XMLAllButton_Click(object sender, EventArgs e)
        {
            // ��������� ������ ���� ���������
            List<Patient> allPatients = patientRepository.GetAllPatients();

            // �������������� ��������� � ������� PatientXML
            List<PatientXML> patientsXMLList = new List<PatientXML>();
            foreach (var patient in allPatients)
            {
                patientsXMLList.Add(new PatientXML(patient, context));
            }

            // ���������� ������ ��������� � XML ����
            string filePath = Path.Combine(Application.StartupPath, "XML/patients.xml");
            XmlExporter.SavePatientsToXml(patientsXMLList, filePath);
            MessageBox.Show("������ ��������� ������� �������� � XML ����.");
        }

        private void XMLButton_Click(object sender, EventArgs e)
        {
            // ��������, ���� �� ���������� ������ � DataGridView
            if (PatientGridView.SelectedRows.Count > 0)
            {
                // ��������� ������ � ���������� ��������
                DataGridViewRow selectedRow = PatientGridView.SelectedRows[0];
                Guid patientId = (Guid)selectedRow.Cells["IDP"].Value;
                Patient selectedPatient = patientRepository.GetPatientById(patientId);

                // �������������� ������� �������� � ������ PatientXML
                PatientXML selectedPatientXML = new PatientXML(selectedPatient, context);

                // ���������� �������� � XML ���� � ������ "���.xml"
                string filePath = Path.Combine(Application.StartupPath, $"XML/{selectedPatient.surname} {selectedPatient.name} {selectedPatient.patronymic}.xml");
                XmlExporter.SavePatientToXml(selectedPatientXML, filePath);
                MessageBox.Show($"������� {selectedPatient.surname} {selectedPatient.name} {selectedPatient.patronymic} ������� �������� � XML ����.");
            }
            else
            {
                MessageBox.Show("�������� �������� ��� ��������.");
            }
        }
    }
}
