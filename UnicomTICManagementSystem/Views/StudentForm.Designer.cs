namespace UnicomTICManagementSystem.Views
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblStudents;
        private System.Windows.Forms.ListBox lstStudents;

        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.ComboBox cmbStudentName;

        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cmbCourse;

        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.Button btnDeleteStudent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblStudents = new Label();
            lstStudents = new ListBox();
            lblStudentName = new Label();
            cmbStudentName = new ComboBox();
            lblCourse = new Label();
            cmbCourse = new ComboBox();
            btnAddStudent = new Button();
            btnEditStudent = new Button();
            btnDeleteStudent = new Button();
            SuspendLayout();
            // 
            // lblStudents
            // 
            lblStudents.AutoSize = true;
            lblStudents.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblStudents.ForeColor = Color.FromArgb(30, 30, 30);
            lblStudents.Location = new Point(40, 30);
            lblStudents.Name = "lblStudents";
            lblStudents.Size = new Size(109, 32);
            lblStudents.TabIndex = 0;
            lblStudents.Text = "Students";
            // 
            // lstStudents
            // 
            lstStudents.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lstStudents.ForeColor = Color.FromArgb(30, 30, 30);
            lstStudents.ItemHeight = 23;
            lstStudents.Location = new Point(40, 65);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(290, 280);
            lstStudents.TabIndex = 1;
            lstStudents.SelectedIndexChanged += lstStudents_SelectedIndexChanged;
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblStudentName.ForeColor = Color.FromArgb(30, 30, 30);
            lblStudentName.Location = new Point(370, 65);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(143, 28);
            lblStudentName.TabIndex = 2;
            lblStudentName.Text = "Student Name";
            // 
            // cmbStudentName
            // 
            cmbStudentName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudentName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStudentName.FormattingEnabled = true;
            cmbStudentName.Location = new Point(370, 95);
            cmbStudentName.Name = "cmbStudentName";
            cmbStudentName.Size = new Size(280, 31);
            cmbStudentName.TabIndex = 3;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCourse.ForeColor = Color.FromArgb(30, 30, 30);
            lblCourse.Location = new Point(370, 140);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(75, 28);
            lblCourse.TabIndex = 4;
            lblCourse.Text = "Course";
            // 
            // cmbCourse
            // 
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(370, 170);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(280, 31);
            cmbCourse.TabIndex = 5;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.FromArgb(0, 120, 215);
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(370, 234);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(90, 35);
            btnAddStudent.TabIndex = 6;
            btnAddStudent.Text = "Add";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnEditStudent
            // 
            btnEditStudent.BackColor = Color.FromArgb(0, 120, 215);
            btnEditStudent.FlatAppearance.BorderSize = 0;
            btnEditStudent.FlatStyle = FlatStyle.Flat;
            btnEditStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditStudent.ForeColor = Color.White;
            btnEditStudent.Location = new Point(470, 234);
            btnEditStudent.Name = "btnEditStudent";
            btnEditStudent.Size = new Size(90, 35);
            btnEditStudent.TabIndex = 7;
            btnEditStudent.Text = "Edit";
            btnEditStudent.UseVisualStyleBackColor = false;
            btnEditStudent.Click += btnEditStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.BackColor = Color.FromArgb(232, 17, 35);
            btnDeleteStudent.FlatAppearance.BorderSize = 0;
            btnDeleteStudent.FlatStyle = FlatStyle.Flat;
            btnDeleteStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteStudent.ForeColor = Color.White;
            btnDeleteStudent.Location = new Point(570, 234);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(90, 35);
            btnDeleteStudent.TabIndex = 8;
            btnDeleteStudent.Text = "Delete";
            btnDeleteStudent.UseVisualStyleBackColor = false;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // StudentForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(740, 450);
            Controls.Add(lblStudents);
            Controls.Add(lstStudents);
            Controls.Add(lblStudentName);
            Controls.Add(cmbStudentName);
            Controls.Add(lblCourse);
            Controls.Add(cmbCourse);
            Controls.Add(btnAddStudent);
            Controls.Add(btnEditStudent);
            Controls.Add(btnDeleteStudent);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "StudentForm";
            Text = "Student Management";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
