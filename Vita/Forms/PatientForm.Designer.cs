namespace Vita
{
    partial class PatientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PatientGridView = new DataGridView();
            patientConfigurationBindingSource = new BindingSource(components);
            appDbContextBindingSource = new BindingSource(components);
            patientBindingSource = new BindingSource(components);
            SurnameTextBox = new TextBox();
            NameTextBox = new TextBox();
            PatronymicTextBox = new TextBox();
            PhoneTextBox = new TextBox();
            DateTimePicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            AddButton = new Button();
            delButton = new Button();
            ascending_button = new Button();
            descending_button = new Button();
            label6 = new Label();
            comboBoxSearch = new ComboBox();
            search_button = new Button();
            reset_button = new Button();
            textBoxSearch = new TextBox();
            label7 = new Label();
            label8 = new Label();
            XMLAllButton = new Button();
            XMLButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PatientGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)patientConfigurationBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appDbContextBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)patientBindingSource).BeginInit();
            SuspendLayout();
            // 
            // PatientGridView
            // 
            PatientGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PatientGridView.Location = new Point(12, 12);
            PatientGridView.Name = "PatientGridView";
            PatientGridView.Size = new Size(677, 280);
            PatientGridView.TabIndex = 0;
            PatientGridView.CellDoubleClick += PatientGridView_CellDoubleClick;
            // 
            // patientConfigurationBindingSource
            // 
            patientConfigurationBindingSource.DataSource = typeof(Infrastructure.EntitiesConfiguration.PatientConfiguration);
            // 
            // appDbContextBindingSource
            // 
            appDbContextBindingSource.DataSource = typeof(Infrastructure.AppDbContext);
            // 
            // patientBindingSource
            // 
            patientBindingSource.DataSource = typeof(Domain.Entities.Patient);
            // 
            // SurnameTextBox
            // 
            SurnameTextBox.Location = new Point(96, 371);
            SurnameTextBox.Name = "SurnameTextBox";
            SurnameTextBox.Size = new Size(100, 23);
            SurnameTextBox.TabIndex = 1;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(257, 371);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(100, 23);
            NameTextBox.TabIndex = 2;
            // 
            // PatronymicTextBox
            // 
            PatronymicTextBox.Location = new Point(439, 371);
            PatronymicTextBox.Name = "PatronymicTextBox";
            PatronymicTextBox.Size = new Size(100, 23);
            PatronymicTextBox.TabIndex = 3;
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(96, 430);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(155, 23);
            PhoneTextBox.TabIndex = 4;
            // 
            // DateTimePicker
            // 
            DateTimePicker.Location = new Point(375, 430);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.Size = new Size(200, 23);
            DateTimePicker.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 373);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 6;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(220, 377);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 7;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(375, 377);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 8;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 433);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 9;
            label4.Text = "Телефон";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(267, 433);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 10;
            label5.Text = "Дата рождения";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(32, 490);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(129, 23);
            AddButton.TabIndex = 11;
            AddButton.Text = "Добавить пациента";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // delButton
            // 
            delButton.Location = new Point(186, 490);
            delButton.Name = "delButton";
            delButton.Size = new Size(133, 23);
            delButton.TabIndex = 12;
            delButton.Text = "Удалить пациента";
            delButton.UseVisualStyleBackColor = true;
            delButton.Click += delButton_Click;
            // 
            // ascending_button
            // 
            ascending_button.Location = new Point(366, 490);
            ascending_button.Name = "ascending_button";
            ascending_button.Size = new Size(115, 23);
            ascending_button.TabIndex = 13;
            ascending_button.Text = "По возрастанию";
            ascending_button.UseVisualStyleBackColor = true;
            ascending_button.Click += ascending_button_Click;
            // 
            // descending_button
            // 
            descending_button.Location = new Point(366, 519);
            descending_button.Name = "descending_button";
            descending_button.Size = new Size(115, 23);
            descending_button.TabIndex = 14;
            descending_button.Text = "По убыванию";
            descending_button.UseVisualStyleBackColor = true;
            descending_button.Click += descending_button_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(366, 472);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 15;
            label6.Text = "Отсортировать по";
            // 
            // comboBoxSearch
            // 
            comboBoxSearch.FormattingEnabled = true;
            comboBoxSearch.Items.AddRange(new object[] { "Фамилия", "Имя", "Отчество", "Телефон" });
            comboBoxSearch.Location = new Point(646, 425);
            comboBoxSearch.Name = "comboBoxSearch";
            comboBoxSearch.Size = new Size(193, 23);
            comboBoxSearch.TabIndex = 16;
            // 
            // search_button
            // 
            search_button.Location = new Point(646, 472);
            search_button.Name = "search_button";
            search_button.Size = new Size(75, 23);
            search_button.TabIndex = 17;
            search_button.Text = "Искать";
            search_button.UseVisualStyleBackColor = true;
            search_button.Click += search_button_Click;
            // 
            // reset_button
            // 
            reset_button.Location = new Point(764, 472);
            reset_button.Name = "reset_button";
            reset_button.Size = new Size(75, 23);
            reset_button.TabIndex = 18;
            reset_button.Text = "Сброс";
            reset_button.UseVisualStyleBackColor = true;
            reset_button.Click += reset_button_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(646, 370);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(193, 23);
            textBoxSearch.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(646, 352);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 20;
            label7.Text = "Найти пациента";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(646, 407);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 21;
            label8.Text = "Искать по";
            // 
            // XMLAllButton
            // 
            XMLAllButton.Location = new Point(718, 66);
            XMLAllButton.Name = "XMLAllButton";
            XMLAllButton.Size = new Size(121, 50);
            XMLAllButton.TabIndex = 22;
            XMLAllButton.Text = "Загрузить всех пациентов в XML";
            XMLAllButton.UseVisualStyleBackColor = true;
            XMLAllButton.Click += XMLAllButton_Click;
            // 
            // XMLButton
            // 
            XMLButton.Location = new Point(718, 131);
            XMLButton.Name = "XMLButton";
            XMLButton.Size = new Size(121, 54);
            XMLButton.TabIndex = 23;
            XMLButton.Text = "Загрузить выбранного пациента в XML";
            XMLButton.UseVisualStyleBackColor = true;
            XMLButton.Click += XMLButton_Click;
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 580);
            Controls.Add(XMLButton);
            Controls.Add(XMLAllButton);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxSearch);
            Controls.Add(reset_button);
            Controls.Add(search_button);
            Controls.Add(comboBoxSearch);
            Controls.Add(label6);
            Controls.Add(descending_button);
            Controls.Add(ascending_button);
            Controls.Add(delButton);
            Controls.Add(AddButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DateTimePicker);
            Controls.Add(PhoneTextBox);
            Controls.Add(PatronymicTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(SurnameTextBox);
            Controls.Add(PatientGridView);
            Name = "PatientForm";
            Text = "VitaPatient";
            ((System.ComponentModel.ISupportInitialize)PatientGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)patientConfigurationBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)appDbContextBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)patientBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView PatientGridView;
        private BindingSource appDbContextBindingSource;
        private BindingSource patientConfigurationBindingSource;
        private TextBox SurnameTextBox;
        private TextBox NameTextBox;
        private TextBox PatronymicTextBox;
        private TextBox PhoneTextBox;
        private DateTimePicker DateTimePicker;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button AddButton;
        private Button delButton;
        private Button ascending_button;
        private Button descending_button;
        private Label label6;
        private ComboBox comboBoxSearch;
        private Button search_button;
        private Button reset_button;
        private TextBox textBoxSearch;
        private Label label7;
        private Label label8;
        private Button XMLAllButton;
        private Button XMLButton;
    }
}
