namespace UnicomTICManagementSystem.Views
{
    partial class CourseForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCourseTitle;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Button btnEditCourse;
        private System.Windows.Forms.Button btnDeleteCourse;
        private System.Windows.Forms.ListBox lstCourses;

        private System.Windows.Forms.Label lblSubjects;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button btnEditSubject;
        private System.Windows.Forms.Button btnDeleteSubject;
        private System.Windows.Forms.ListBox lstSubjects;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblCourseTitle = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnEditCourse = new System.Windows.Forms.Button();
            this.btnDeleteCourse = new System.Windows.Forms.Button();
            this.lstCourses = new System.Windows.Forms.ListBox();

            this.lblSubjects = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.btnEditSubject = new System.Windows.Forms.Button();
            this.btnDeleteSubject = new System.Windows.Forms.Button();
            this.lstSubjects = new System.Windows.Forms.ListBox();

            // Form
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "CourseForm";
            this.Text = "Course and Subject Management";

            // lblCourseTitle
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblCourseTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblCourseTitle.Location = new System.Drawing.Point(40, 30);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(82, 25);
            this.lblCourseTitle.TabIndex = 0;
            this.lblCourseTitle.Text = "Courses";

            // txtCourseName
            this.txtCourseName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCourseName.Location = new System.Drawing.Point(40, 65);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(280, 27);
            this.txtCourseName.TabIndex = 1;
            this.txtCourseName.PlaceholderText = "Enter course name";

            // btnAddCourse
            this.btnAddCourse.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.FlatAppearance.BorderSize = 0;
            this.btnAddCourse.ForeColor = System.Drawing.Color.White;
            this.btnAddCourse.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddCourse.Location = new System.Drawing.Point(40, 105);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(90, 35);
            this.btnAddCourse.TabIndex = 2;
            this.btnAddCourse.Text = "Add";
            this.btnAddCourse.UseVisualStyleBackColor = false;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);

            // btnEditCourse
            this.btnEditCourse.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnEditCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCourse.FlatAppearance.BorderSize = 0;
            this.btnEditCourse.ForeColor = System.Drawing.Color.White;
            this.btnEditCourse.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditCourse.Location = new System.Drawing.Point(140, 105);
            this.btnEditCourse.Name = "btnEditCourse";
            this.btnEditCourse.Size = new System.Drawing.Size(90, 35);
            this.btnEditCourse.TabIndex = 3;
            this.btnEditCourse.Text = "Edit";
            this.btnEditCourse.UseVisualStyleBackColor = false;
            this.btnEditCourse.Click += new System.EventHandler(this.btnEditCourse_Click);

            // btnDeleteCourse
            this.btnDeleteCourse.BackColor = System.Drawing.Color.FromArgb(232, 17, 35);
            this.btnDeleteCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCourse.FlatAppearance.BorderSize = 0;
            this.btnDeleteCourse.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCourse.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteCourse.Location = new System.Drawing.Point(240, 105);
            this.btnDeleteCourse.Name = "btnDeleteCourse";
            this.btnDeleteCourse.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteCourse.TabIndex = 4;
            this.btnDeleteCourse.Text = "Delete";
            this.btnDeleteCourse.UseVisualStyleBackColor = false;
            this.btnDeleteCourse.Click += new System.EventHandler(this.btnDeleteCourse_Click);

            // lstCourses
            this.lstCourses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstCourses.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lstCourses.ItemHeight = 17;
            this.lstCourses.Location = new System.Drawing.Point(40, 150);
            this.lstCourses.Name = "lstCourses";
            this.lstCourses.Size = new System.Drawing.Size(290, 260);
            this.lstCourses.TabIndex = 5;
            this.lstCourses.SelectedIndexChanged += new System.EventHandler(this.lstCourses_SelectedIndexChanged);

            // lblSubjects
            this.lblSubjects.AutoSize = true;
            this.lblSubjects.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblSubjects.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblSubjects.Location = new System.Drawing.Point(400, 30);
            this.lblSubjects.Name = "lblSubjects";
            this.lblSubjects.Size = new System.Drawing.Size(85, 25);
            this.lblSubjects.TabIndex = 6;
            this.lblSubjects.Text = "Subjects";

            // txtSubjectName
            this.txtSubjectName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSubjectName.Location = new System.Drawing.Point(400, 65);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(280, 27);
            this.txtSubjectName.TabIndex = 7;
            this.txtSubjectName.PlaceholderText = "Enter subject name";

            // cmbCourse
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(400, 100);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(280, 25);
            this.cmbCourse.TabIndex = 8;

            // btnAddSubject
            this.btnAddSubject.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubject.FlatAppearance.BorderSize = 0;
            this.btnAddSubject.ForeColor = System.Drawing.Color.White;
            this.btnAddSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddSubject.Location = new System.Drawing.Point(400, 135);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(90, 35);
            this.btnAddSubject.TabIndex = 9;
            this.btnAddSubject.Text = "Add";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);

            // btnEditSubject
            this.btnEditSubject.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnEditSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSubject.FlatAppearance.BorderSize = 0;
            this.btnEditSubject.ForeColor = System.Drawing.Color.White;
            this.btnEditSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditSubject.Location = new System.Drawing.Point(500, 135);
            this.btnEditSubject.Name = "btnEditSubject";
            this.btnEditSubject.Size = new System.Drawing.Size(90, 35);
            this.btnEditSubject.TabIndex = 10;
            this.btnEditSubject.Text = "Edit";
            this.btnEditSubject.UseVisualStyleBackColor = false;
            this.btnEditSubject.Click += new System.EventHandler(this.btnEditSubject_Click);

            // btnDeleteSubject
            this.btnDeleteSubject.BackColor = System.Drawing.Color.FromArgb(232, 17, 35);
            this.btnDeleteSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSubject.FlatAppearance.BorderSize = 0;
            this.btnDeleteSubject.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteSubject.Location = new System.Drawing.Point(600, 135);
            this.btnDeleteSubject.Name = "btnDeleteSubject";
            this.btnDeleteSubject.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteSubject.TabIndex = 11;
            this.btnDeleteSubject.Text = "Delete";
            this.btnDeleteSubject.UseVisualStyleBackColor = false;
            this.btnDeleteSubject.Click += new System.EventHandler(this.btnDeleteSubject_Click);

            // lstSubjects
            this.lstSubjects.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstSubjects.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lstSubjects.ItemHeight = 17;
            this.lstSubjects.Location = new System.Drawing.Point(400, 180);
            this.lstSubjects.Name = "lstSubjects";
            this.lstSubjects.Size = new System.Drawing.Size(290, 230);
            this.lstSubjects.TabIndex = 12;
            this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);

            // Add all controls to the form
            this.Controls.Add(this.lblCourseTitle);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.btnEditCourse);
            this.Controls.Add(this.btnDeleteCourse);
            this.Controls.Add(this.lstCourses);

            this.Controls.Add(this.lblSubjects);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.btnEditSubject);
            this.Controls.Add(this.btnDeleteSubject);
            this.Controls.Add(this.lstSubjects);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
