namespace UnicomTICManagementSystem.Views
{
    partial class MarkForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewMarks;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.ComboBox comboBoxStudents;
        private System.Windows.Forms.ComboBox comboBoxExams;
        private System.Windows.Forms.Button btnAddMark;
        private System.Windows.Forms.Button btnEditMark;
        private System.Windows.Forms.Button btnDeleteMark;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dataGridViewMarks = new System.Windows.Forms.DataGridView();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.comboBoxStudents = new System.Windows.Forms.ComboBox();
            this.comboBoxExams = new System.Windows.Forms.ComboBox();
            this.btnAddMark = new System.Windows.Forms.Button();
            this.btnEditMark = new System.Windows.Forms.Button();
            this.btnDeleteMark = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarks)).BeginInit();
            this.SuspendLayout();

            // MarkForm
            this.ClientSize = new System.Drawing.Size(780, 460);
            this.Name = "MarkForm";
            this.Text = "Mark Management";
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Load += new System.EventHandler(this.MarkForm_Load);

            // dataGridViewMarks
            this.dataGridViewMarks.Location = new System.Drawing.Point(40, 30);
            this.dataGridViewMarks.Size = new System.Drawing.Size(700, 240);
            this.dataGridViewMarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMarks.SelectionChanged += new System.EventHandler(this.dataGridViewMarks_SelectionChanged);

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(40, 290);
            this.lblScore.Text = "Score:";
            this.lblScore.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);

            // txtScore
            this.txtScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtScore.Location = new System.Drawing.Point(95, 287);
            this.txtScore.Size = new System.Drawing.Size(80, 25);

            // comboBoxStudents
            this.comboBoxStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStudents.Location = new System.Drawing.Point(200, 287);
            this.comboBoxStudents.Size = new System.Drawing.Size(240, 25);

            // comboBoxExams
            this.comboBoxExams.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxExams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExams.Location = new System.Drawing.Point(460, 287);
            this.comboBoxExams.Size = new System.Drawing.Size(280, 25);

            // btnAddMark
            this.btnAddMark.Text = "Add";
            this.btnAddMark.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddMark.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnAddMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMark.FlatAppearance.BorderSize = 0;
            this.btnAddMark.ForeColor = System.Drawing.Color.White;
            this.btnAddMark.Location = new System.Drawing.Point(40, 330);
            this.btnAddMark.Size = new System.Drawing.Size(90, 35);
            this.btnAddMark.Click += new System.EventHandler(this.btnAddMark_Click);

            // btnEditMark
            this.btnEditMark.Text = "Edit";
            this.btnEditMark.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditMark.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnEditMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMark.FlatAppearance.BorderSize = 0;
            this.btnEditMark.ForeColor = System.Drawing.Color.White;
            this.btnEditMark.Location = new System.Drawing.Point(140, 330);
            this.btnEditMark.Size = new System.Drawing.Size(90, 35);
            this.btnEditMark.Click += new System.EventHandler(this.btnEditMark_Click);

            // btnDeleteMark
            this.btnDeleteMark.Text = "Delete";
            this.btnDeleteMark.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteMark.BackColor = System.Drawing.Color.FromArgb(232, 17, 35);
            this.btnDeleteMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMark.FlatAppearance.BorderSize = 0;
            this.btnDeleteMark.ForeColor = System.Drawing.Color.White;
            this.btnDeleteMark.Location = new System.Drawing.Point(240, 330);
            this.btnDeleteMark.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteMark.Click += new System.EventHandler(this.btnDeleteMark_Click);

            // Add controls
            this.Controls.Add(this.dataGridViewMarks);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.comboBoxStudents);
            this.Controls.Add(this.comboBoxExams);
            this.Controls.Add(this.btnAddMark);
            this.Controls.Add(this.btnEditMark);
            this.Controls.Add(this.btnDeleteMark);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}