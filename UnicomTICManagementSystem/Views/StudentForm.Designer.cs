namespace UnicomTICManagementSystem.Views
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox lstStudents;
        private System.Windows.Forms.ComboBox cmbStudentName;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.Button btnDeleteStudent;

        private System.Windows.Forms.Panel panelStudents;

        private readonly System.Drawing.Color panelBackColor = System.Drawing.Color.FromArgb(245, 245, 245);
        private readonly System.Drawing.Color btnBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
        private readonly System.Drawing.Color btnForeColor = System.Drawing.Color.White;
        private readonly System.Drawing.Color btnHoverColor = System.Drawing.Color.FromArgb(25, 118, 210);

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstStudents = new System.Windows.Forms.ListBox();
            this.cmbStudentName = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnEditStudent = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.panelStudents = new System.Windows.Forms.Panel();

            this.SuspendLayout();

            // Fonts
            var sectionFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            var labelFont = new System.Drawing.Font("Segoe UI", 9.5F);
            var buttonFont = new System.Drawing.Font("Segoe UI", 9F);

            int panelWidth = 660;
            int panelHeight = 320;
            int padding = 15;

            // panelStudents
            this.panelStudents.BackColor = panelBackColor;
            this.panelStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStudents.Location = new System.Drawing.Point(15, 15);
            this.panelStudents.Size = new System.Drawing.Size(panelWidth, panelHeight);
            this.panelStudents.Padding = new System.Windows.Forms.Padding(padding);

            // lstStudents
            this.lstStudents.Font = labelFont;
            this.lstStudents.Location = new System.Drawing.Point(padding, padding + 5);
            this.lstStudents.Size = new System.Drawing.Size(320, 270);
            this.lstStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstStudents.SelectedIndexChanged += new System.EventHandler(this.lstStudents_SelectedIndexChanged);

            // lblStudentName
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = sectionFont;
            this.lblStudentName.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblStudentName.Location = new System.Drawing.Point(350, padding);
            this.lblStudentName.Text = "Student Name";

            // cmbStudentName
            this.cmbStudentName.Font = labelFont;
            this.cmbStudentName.Location = new System.Drawing.Point(350, padding + 30);
            this.cmbStudentName.Size = new System.Drawing.Size(290, 28);
            this.cmbStudentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudentName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // lblCourse
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = sectionFont;
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCourse.Location = new System.Drawing.Point(350, padding + 70);
            this.lblCourse.Text = "Course";

            // cmbCourse
            this.cmbCourse.Font = labelFont;
            this.cmbCourse.Location = new System.Drawing.Point(350, padding + 100);
            this.cmbCourse.Size = new System.Drawing.Size(290, 28);
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // Buttons
            int btnWidth = 100;
            int btnHeight = 36;
            int btnSpacing = 12;
            int btnTop = panelHeight - btnHeight - padding - 10; // bottom aligned inside panel

            // btnAddStudent
            this.btnAddStudent.Font = buttonFont;
            this.btnAddStudent.BackColor = btnBackColor;
            this.btnAddStudent.ForeColor = btnForeColor;
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.FlatAppearance.BorderSize = 0;
            this.btnAddStudent.Location = new System.Drawing.Point(350, btnTop);
            this.btnAddStudent.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnAddStudent.Text = "Add";
            this.btnAddStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            this.btnAddStudent.MouseEnter += new System.EventHandler(this.btnAddStudent_MouseEnter);
            this.btnAddStudent.MouseLeave += new System.EventHandler(this.btnAddStudent_MouseLeave);

            // btnEditStudent
            this.btnEditStudent.Font = buttonFont;
            this.btnEditStudent.BackColor = btnBackColor;
            this.btnEditStudent.ForeColor = btnForeColor;
            this.btnEditStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditStudent.FlatAppearance.BorderSize = 0;
            this.btnEditStudent.Location = new System.Drawing.Point(350 + btnWidth + btnSpacing, btnTop);
            this.btnEditStudent.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnEditStudent.Text = "Edit";
            this.btnEditStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditStudent.UseVisualStyleBackColor = false;
            this.btnEditStudent.Click += new System.EventHandler(this.btnEditStudent_Click);
            this.btnEditStudent.MouseEnter += new System.EventHandler(this.btnEditStudent_MouseEnter);
            this.btnEditStudent.MouseLeave += new System.EventHandler(this.btnEditStudent_MouseLeave);

            // btnDeleteStudent
            this.btnDeleteStudent.Font = buttonFont;
            this.btnDeleteStudent.BackColor = btnBackColor;
            this.btnDeleteStudent.ForeColor = btnForeColor;
            this.btnDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteStudent.FlatAppearance.BorderSize = 0;
            this.btnDeleteStudent.Location = new System.Drawing.Point(350 + 2 * (btnWidth + btnSpacing), btnTop);
            this.btnDeleteStudent.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnDeleteStudent.Text = "Delete";
            this.btnDeleteStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteStudent.UseVisualStyleBackColor = false;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            this.btnDeleteStudent.MouseEnter += new System.EventHandler(this.btnDeleteStudent_MouseEnter);
            this.btnDeleteStudent.MouseLeave += new System.EventHandler(this.btnDeleteStudent_MouseLeave);

            // Add controls to panelStudents
            this.panelStudents.Controls.Add(this.lstStudents);
            this.panelStudents.Controls.Add(this.lblStudentName);
            this.panelStudents.Controls.Add(this.cmbStudentName);
            this.panelStudents.Controls.Add(this.lblCourse);
            this.panelStudents.Controls.Add(this.cmbCourse);
            this.panelStudents.Controls.Add(this.btnAddStudent);
            this.panelStudents.Controls.Add(this.btnEditStudent);
            this.panelStudents.Controls.Add(this.btnDeleteStudent);

            // StudentForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(panelWidth + 30, panelHeight + 30);
            this.Controls.Add(this.panelStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StudentForm";
            this.Text = "Student Management";
            this.Load += new System.EventHandler(this.StudentForm_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
