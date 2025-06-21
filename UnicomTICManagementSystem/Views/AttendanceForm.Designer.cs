namespace UnicomTICManagementSystem.Views
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
            dataGridViewAttendance = new DataGridView();
            comboBoxStudent = new ComboBox();
            comboBoxSubject = new ComboBox();
            dateTimePickerDate = new DateTimePicker();
            comboBoxStatus = new ComboBox();
            btnMarkAttendance = new Button();
            btnUpdateAttendance = new Button();
            btnDeleteAttendance = new Button();

            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).BeginInit();
            SuspendLayout();

            // dataGridViewAttendance
            dataGridViewAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAttendance.Location = new Point(16, 170);
            dataGridViewAttendance.Margin = new Padding(4, 5, 4, 5);
            dataGridViewAttendance.Name = "dataGridViewAttendance";
            dataGridViewAttendance.RowHeadersWidth = 51;
            dataGridViewAttendance.Size = new Size(1013, 520);
            dataGridViewAttendance.TabIndex = 0;

            // comboBoxStudent
            comboBoxStudent.FormattingEnabled = true;
            comboBoxStudent.Location = new Point(16, 18);
            comboBoxStudent.Margin = new Padding(4, 5, 4, 5);
            comboBoxStudent.Name = "comboBoxStudent";
            comboBoxStudent.Size = new Size(320, 28);
            comboBoxStudent.TabIndex = 1;

            // comboBoxSubject
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(348, 18);
            comboBoxSubject.Margin = new Padding(4, 5, 4, 5);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(320, 28);
            comboBoxSubject.TabIndex = 2;

            // dateTimePickerDate
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(680, 18);
            dateTimePickerDate.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(160, 27);
            dateTimePickerDate.TabIndex = 3;

            // comboBoxStatus
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Items.AddRange(new object[] { "Present", "Absent", "Late", "Excused" });
            comboBoxStatus.Location = new Point(848, 18);
            comboBoxStatus.Margin = new Padding(4, 5, 4, 5);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(180, 28);
            comboBoxStatus.TabIndex = 4;

            // btnMarkAttendance
            btnMarkAttendance.Location = new Point(16, 62);
            btnMarkAttendance.Margin = new Padding(4, 5, 4, 5);
            btnMarkAttendance.Name = "btnMarkAttendance";
            btnMarkAttendance.Size = new Size(180, 35);
            btnMarkAttendance.TabIndex = 5;
            btnMarkAttendance.Text = "Mark Attendance";
            btnMarkAttendance.UseVisualStyleBackColor = true;
            btnMarkAttendance.Click += btnMarkAttendance_Click;

            // btnUpdateAttendance
            btnUpdateAttendance.Location = new Point(210, 62);
            btnUpdateAttendance.Margin = new Padding(4, 5, 4, 5);
            btnUpdateAttendance.Name = "btnUpdateAttendance";
            btnUpdateAttendance.Size = new Size(180, 35);
            btnUpdateAttendance.TabIndex = 6;
            btnUpdateAttendance.Text = "Update Attendance";
            btnUpdateAttendance.UseVisualStyleBackColor = true;
            btnUpdateAttendance.Click += btnUpdateAttendance_Click;

            // btnDeleteAttendance
            btnDeleteAttendance.Location = new Point(404, 62);
            btnDeleteAttendance.Margin = new Padding(4, 5, 4, 5);
            btnDeleteAttendance.Name = "btnDeleteAttendance";
            btnDeleteAttendance.Size = new Size(180, 35);
            btnDeleteAttendance.TabIndex = 7;
            btnDeleteAttendance.Text = "Delete Attendance";
            btnDeleteAttendance.UseVisualStyleBackColor = true;
            btnDeleteAttendance.Click += btnDeleteAttendance_Click;

            // AttendanceForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 709);
            Controls.Add(btnDeleteAttendance);
            Controls.Add(btnUpdateAttendance);
            Controls.Add(btnMarkAttendance);
            Controls.Add(comboBoxStatus);
            Controls.Add(dateTimePickerDate);
            Controls.Add(comboBoxSubject);
            Controls.Add(comboBoxStudent);
            Controls.Add(dataGridViewAttendance);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AttendanceForm";
            Text = "Attendance Management";
            Load += AttendanceForm_Load;

            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAttendance;
        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Button btnMarkAttendance;
        private System.Windows.Forms.Button btnUpdateAttendance;
        private System.Windows.Forms.Button btnDeleteAttendance;
        private System.Windows.Forms.ComboBox comboBoxStatus; // New field
    }
}