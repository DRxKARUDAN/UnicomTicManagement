namespace UnicomTICManagementSystem.Views
{
    partial class ExamForm
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
            // 
            // dataGridViewExams
            // 
            this.dataGridViewExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExams.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewExams.Name = "dataGridViewExams";
            this.dataGridViewExams.Size = new System.Drawing.Size(260, 160);
            this.dataGridViewExams.TabIndex = 0;
            this.dataGridViewExams.SelectionChanged += new System.EventHandler(this.dataGridViewExams_SelectionChanged);
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(278, 12);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(200, 20);
            this.txtExamName.TabIndex = 1;
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(278, 38);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSubject.TabIndex = 2;
            // 
            // lblExamName
            // 
            this.lblExamName.AutoSize = true;
            this.lblExamName.Location = new System.Drawing.Point(278, -2);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(65, 13);
            this.lblExamName.TabIndex = 3;
            this.lblExamName.Text = "Exam Name:";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(278, 22);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(46, 13);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Subject:";
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(278, 65);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(75, 23);
            this.btnAddExam.TabIndex = 5;
            this.btnAddExam.Text = "Add Exam";
            this.btnAddExam.UseVisualStyleBackColor = true;
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            // 
            // btnEditExam
            // 
            this.btnEditExam.Location = new System.Drawing.Point(359, 65);
            this.btnEditExam.Name = "btnEditExam";
            this.btnEditExam.Size = new System.Drawing.Size(75, 23);
            this.btnEditExam.TabIndex = 6;
            this.btnEditExam.Text = "Edit Exam";
            this.btnEditExam.UseVisualStyleBackColor = true;
            this.btnEditExam.Click += new System.EventHandler(this.btnEditExam_Click);
            // 
            // btnDeleteExam
            // 
            this.btnDeleteExam.Location = new System.Drawing.Point(440, 65);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteExam.TabIndex = 7;
            this.btnDeleteExam.Text = "Delete Exam";
            this.btnDeleteExam.UseVisualStyleBackColor = true;
            this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);
            // 
            // ExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 190);
            this.Controls.Add(this.btnDeleteExam);
            this.Controls.Add(this.btnEditExam);
            this.Controls.Add(this.btnAddExam);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblExamName);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.dataGridViewExams);
            this.Name = "ExamForm";
            this.Text = "Exam Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewExams;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.Label lblExamName;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.Button btnEditExam;
        private System.Windows.Forms.Button btnDeleteExam;
    }
}