namespace UnicomTICManagementSystem.Views
{
    partial class ExamForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dataGridViewExams;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.Label lblExamName;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.Button btnEditExam;
        private System.Windows.Forms.Button btnDeleteExam;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();
            this.dataGridViewExams = new System.Windows.Forms.DataGridView();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.lblExamName = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.btnEditExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExams)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Name = "ExamForm";
            this.Text = "Exam Management";
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Load += new System.EventHandler(this.ExamForm_Load);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 25);
            this.lblTitle.Text = "Exam Records";

            // dataGridViewExams
            this.dataGridViewExams.Location = new System.Drawing.Point(30, 70);
            this.dataGridViewExams.Name = "dataGridViewExams";
            this.dataGridViewExams.Size = new System.Drawing.Size(320, 300);
            this.dataGridViewExams.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExams.RowHeadersWidth = 51;
            this.dataGridViewExams.SelectionChanged += new System.EventHandler(this.dataGridViewExams_SelectionChanged);

            // lblExamName
            this.lblExamName.AutoSize = true;
            this.lblExamName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblExamName.Location = new System.Drawing.Point(380, 70);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(90, 19);
            this.lblExamName.Text = "Exam Name:";

            // txtExamName
            this.txtExamName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtExamName.Location = new System.Drawing.Point(380, 95);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(320, 25);
            this.txtExamName.PlaceholderText = "Enter exam name";

            // lblSubject
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubject.Location = new System.Drawing.Point(380, 135);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(61, 19);
            this.lblSubject.Text = "Subject:";

            // comboBoxSubject
            this.comboBoxSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubject.Location = new System.Drawing.Point(380, 160);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(320, 25);

            // btnAddExam
            this.btnAddExam.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnAddExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExam.FlatAppearance.BorderSize = 0;
            this.btnAddExam.ForeColor = System.Drawing.Color.White;
            this.btnAddExam.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddExam.Location = new System.Drawing.Point(380, 210);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(90, 35);
            this.btnAddExam.Text = "Add";
            this.btnAddExam.UseVisualStyleBackColor = false;
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);

            // btnEditExam
            this.btnEditExam.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnEditExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditExam.FlatAppearance.BorderSize = 0;
            this.btnEditExam.ForeColor = System.Drawing.Color.White;
            this.btnEditExam.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditExam.Location = new System.Drawing.Point(480, 210);
            this.btnEditExam.Name = "btnEditExam";
            this.btnEditExam.Size = new System.Drawing.Size(90, 35);
            this.btnEditExam.Text = "Edit";
            this.btnEditExam.UseVisualStyleBackColor = false;
            this.btnEditExam.Click += new System.EventHandler(this.btnEditExam_Click);

            // btnDeleteExam
            this.btnDeleteExam.BackColor = System.Drawing.Color.FromArgb(232, 17, 35);
            this.btnDeleteExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteExam.FlatAppearance.BorderSize = 0;
            this.btnDeleteExam.ForeColor = System.Drawing.Color.White;
            this.btnDeleteExam.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteExam.Location = new System.Drawing.Point(580, 210);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteExam.Text = "Delete";
            this.btnDeleteExam.UseVisualStyleBackColor = false;
            this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);

            // Add Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dataGridViewExams);
            this.Controls.Add(this.lblExamName);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.btnAddExam);
            this.Controls.Add(this.btnEditExam);
            this.Controls.Add(this.btnDeleteExam);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}