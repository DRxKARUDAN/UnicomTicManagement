namespace UnicomTICManagementSystem.Views
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Button btnMarkAttendance;
        private System.Windows.Forms.Button btnUpdateAttendance;
        private System.Windows.Forms.Button btnDeleteAttendance;
        private System.Windows.Forms.DataGridView dataGridViewAttendance;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            comboBoxStudent = new ComboBox();
            comboBoxSubject = new ComboBox();
            comboBoxStatus = new ComboBox();
            dateTimePickerDate = new DateTimePicker();
            btnMarkAttendance = new Button();
            btnUpdateAttendance = new Button();
            btnDeleteAttendance = new Button();
            dataGridViewAttendance = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 30);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(236, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Attendance";
            // 
            // comboBoxStudent
            // 
            comboBoxStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStudent.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxStudent.Location = new Point(30, 70);
            comboBoxStudent.Name = "comboBoxStudent";
            comboBoxStudent.Size = new Size(220, 31);
            comboBoxStudent.TabIndex = 1;
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSubject.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxSubject.Location = new Point(270, 70);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(220, 31);
            comboBoxSubject.TabIndex = 2;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxStatus.Location = new Point(680, 70);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(150, 31);
            comboBoxStatus.TabIndex = 4;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(510, 70);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(150, 30);
            dateTimePickerDate.TabIndex = 3;
            // 
            // btnMarkAttendance
            // 
            btnMarkAttendance.BackColor = Color.FromArgb(0, 120, 215);
            btnMarkAttendance.FlatAppearance.BorderSize = 0;
            btnMarkAttendance.FlatStyle = FlatStyle.Flat;
            btnMarkAttendance.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnMarkAttendance.ForeColor = Color.White;
            btnMarkAttendance.Location = new Point(850, 70);
            btnMarkAttendance.Name = "btnMarkAttendance";
            btnMarkAttendance.Size = new Size(120, 32);
            btnMarkAttendance.TabIndex = 5;
            btnMarkAttendance.Text = "Mark";
            btnMarkAttendance.UseVisualStyleBackColor = false;
            btnMarkAttendance.Click += btnMarkAttendance_Click;
            // 
            // btnUpdateAttendance
            // 
            btnUpdateAttendance.BackColor = Color.FromArgb(0, 120, 215);
            btnUpdateAttendance.FlatAppearance.BorderSize = 0;
            btnUpdateAttendance.FlatStyle = FlatStyle.Flat;
            btnUpdateAttendance.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdateAttendance.ForeColor = Color.White;
            btnUpdateAttendance.Location = new Point(30, 115);
            btnUpdateAttendance.Name = "btnUpdateAttendance";
            btnUpdateAttendance.Size = new Size(120, 32);
            btnUpdateAttendance.TabIndex = 6;
            btnUpdateAttendance.Text = "Update";
            btnUpdateAttendance.UseVisualStyleBackColor = false;
            btnUpdateAttendance.Click += btnUpdateAttendance_Click;
            // 
            // btnDeleteAttendance
            // 
            btnDeleteAttendance.BackColor = Color.FromArgb(232, 17, 35);
            btnDeleteAttendance.FlatAppearance.BorderSize = 0;
            btnDeleteAttendance.FlatStyle = FlatStyle.Flat;
            btnDeleteAttendance.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteAttendance.ForeColor = Color.White;
            btnDeleteAttendance.Location = new Point(160, 115);
            btnDeleteAttendance.Name = "btnDeleteAttendance";
            btnDeleteAttendance.Size = new Size(120, 32);
            btnDeleteAttendance.TabIndex = 7;
            btnDeleteAttendance.Text = "Delete";
            btnDeleteAttendance.UseVisualStyleBackColor = false;
            btnDeleteAttendance.Click += btnDeleteAttendance_Click;
            // 
            // dataGridViewAttendance
            // 
            dataGridViewAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAttendance.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewAttendance.Location = new Point(30, 170);
            dataGridViewAttendance.Name = "dataGridViewAttendance";
            dataGridViewAttendance.RowHeadersWidth = 51;
            dataGridViewAttendance.Size = new Size(940, 480);
            dataGridViewAttendance.TabIndex = 0;
            // 
            // AttendanceForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1000, 700);
            Controls.Add(lblTitle);
            Controls.Add(comboBoxStudent);
            Controls.Add(comboBoxSubject);
            Controls.Add(dateTimePickerDate);
            Controls.Add(comboBoxStatus);
            Controls.Add(btnMarkAttendance);
            Controls.Add(btnUpdateAttendance);
            Controls.Add(btnDeleteAttendance);
            Controls.Add(dataGridViewAttendance);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "AttendanceForm";
            Text = "Attendance Management";
            Load += AttendanceForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
