namespace Vita.Forms
{
    partial class AttendanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AttendanceGridView = new DataGridView();
            AddButton = new Button();
            DeleteButton = new Button();
            SearchButton = new Button();
            ResetButton = new Button();
            SearchTextBox = new TextBox();
            DiagnosisTextBox = new TextBox();
            DateTimePicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            AscendingSortButton = new Button();
            DescendingSortButton = new Button();
            ((System.ComponentModel.ISupportInitialize)AttendanceGridView).BeginInit();
            SuspendLayout();
            // 
            // AttendanceGridView
            // 
            AttendanceGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AttendanceGridView.Location = new Point(69, 24);
            AttendanceGridView.Name = "AttendanceGridView";
            AttendanceGridView.Size = new Size(444, 199);
            AttendanceGridView.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(34, 363);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 1;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(140, 363);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(342, 363);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 3;
            SearchButton.Text = "Найти";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(443, 363);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(75, 23);
            ResetButton.TabIndex = 4;
            ResetButton.Text = "Сброс";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(362, 305);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(133, 23);
            SearchTextBox.TabIndex = 6;
            // 
            // DiagnosisTextBox
            // 
            DiagnosisTextBox.Location = new Point(115, 253);
            DiagnosisTextBox.Name = "DiagnosisTextBox";
            DiagnosisTextBox.Size = new Size(200, 23);
            DiagnosisTextBox.TabIndex = 7;
            // 
            // DateTimePicker
            // 
            DateTimePicker.Location = new Point(115, 302);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.Size = new Size(200, 23);
            DateTimePicker.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 256);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 9;
            label1.Text = "Диагноз";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 305);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 10;
            label2.Text = "Дата посещения";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 261);
            label3.Name = "label3";
            label3.Size = new Size(176, 15);
            label3.TabIndex = 11;
            label3.Text = "Найти посещение по диагнозу";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(610, 261);
            label4.Name = "label4";
            label4.Size = new Size(145, 15);
            label4.TabIndex = 12;
            label4.Text = "Отсортировать диагнозы";
            // 
            // AscendingSortButton
            // 
            AscendingSortButton.Location = new Point(627, 305);
            AscendingSortButton.Name = "AscendingSortButton";
            AscendingSortButton.Size = new Size(107, 23);
            AscendingSortButton.TabIndex = 13;
            AscendingSortButton.Text = "По возрастанию";
            AscendingSortButton.UseVisualStyleBackColor = true;
            AscendingSortButton.Click += AscendingSortButton_Click;
            // 
            // DescendingSortButton
            // 
            DescendingSortButton.Location = new Point(627, 363);
            DescendingSortButton.Name = "DescendingSortButton";
            DescendingSortButton.Size = new Size(107, 23);
            DescendingSortButton.TabIndex = 14;
            DescendingSortButton.Text = "По убыванию";
            DescendingSortButton.UseVisualStyleBackColor = true;
            DescendingSortButton.Click += DescendingSortButton_Click;
            // 
            // AttendanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DescendingSortButton);
            Controls.Add(AscendingSortButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DateTimePicker);
            Controls.Add(DiagnosisTextBox);
            Controls.Add(SearchTextBox);
            Controls.Add(ResetButton);
            Controls.Add(SearchButton);
            Controls.Add(DeleteButton);
            Controls.Add(AddButton);
            Controls.Add(AttendanceGridView);
            Name = "AttendanceForm";
            Text = "VitaAttendance";
            FormClosing += AttendanceForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)AttendanceGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView AttendanceGridView;
        private Button AddButton;
        private Button DeleteButton;
        private Button SearchButton;
        private Button ResetButton;
        private TextBox SearchTextBox;
        private TextBox DiagnosisTextBox;
        private DateTimePicker DateTimePicker;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button AscendingSortButton;
        private Button DescendingSortButton;
    }
}