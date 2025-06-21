namespace UnicomTICManagementSystem.Views
{
    partial class MarkForm
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
            dataGridViewMarks = new DataGridView();
            lblScore = new Label();
            txtScore = new TextBox();
            comboBoxStudents = new ComboBox();
            comboBoxExams = new ComboBox();
            btnAddMark = new Button();
            btnEditMark = new Button();
            btnDeleteMark = new Button();

            ((System.ComponentModel.ISupportInitialize)dataGridViewMarks).BeginInit();
            SuspendLayout();

            // dataGridViewMarks
            dataGridViewMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMarks.Location = new Point(20, 20);
            dataGridViewMarks.Size = new Size(700, 250);
            dataGridViewMarks.SelectionChanged += dataGridViewMarks_SelectionChanged;

            // lblScore
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblScore.Location = new Point(20, 290);
            lblScore.Text = "Score:";

            // txtScore
            txtScore.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtScore.Location = new Point(80, 286);
            txtScore.Size = new Size(80, 25);

            // comboBoxStudents
            comboBoxStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStudents.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxStudents.Location = new Point(180, 285);
            comboBoxStudents.Size = new Size(260, 28);

            // comboBoxExams
            comboBoxExams.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxExams.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxExams.Location = new Point(450, 285);
            comboBoxExams.Size = new Size(270, 28);

            // btnAddMark
            btnAddMark.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddMark.Location = new Point(20, 330);
            btnAddMark.Size = new Size(130, 35);
            btnAddMark.Text = "Add Mark";
            btnAddMark.Click += btnAddMark_Click;

            // btnEditMark
            btnEditMark.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditMark.Location = new Point(160, 330);
            btnEditMark.Size = new Size(130, 35);
            btnEditMark.Text = "Edit Mark";
            btnEditMark.Click += btnEditMark_Click;

            // btnDeleteMark
            btnDeleteMark.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteMark.Location = new Point(300, 330);
            btnDeleteMark.Size = new Size(130, 35);
            btnDeleteMark.Text = "Delete Mark";
            btnDeleteMark.Click += btnDeleteMark_Click;

            // MarkForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 390);
            Controls.Add(dataGridViewMarks);
            Controls.Add(lblScore);
            Controls.Add(txtScore);
            Controls.Add(comboBoxStudents);
            Controls.Add(comboBoxExams);
            Controls.Add(btnAddMark);
            Controls.Add(btnEditMark);
            Controls.Add(btnDeleteMark);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MarkForm";
            Text = "Mark Management";
            Load += MarkForm_Load;

            ((System.ComponentModel.ISupportInitialize)dataGridViewMarks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMarks;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.ComboBox comboBoxStudents;
        private System.Windows.Forms.ComboBox comboBoxExams;
        private System.Windows.Forms.Button btnAddMark;
        private System.Windows.Forms.Button btnEditMark;
        private System.Windows.Forms.Button btnDeleteMark;
    }
}