using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Views
{
    public partial class ExamForm : Form
    {
        private readonly string _role;
        private readonly ExamController _examController;
        private List<Exam> _exams;
        private List<Subject> _subjects;

        public ExamForm(string role)
        {
            InitializeComponent();
            _role = role;
            _examController = new ExamController();
            InitializeUI();
            LoadData();
        }

        public ExamForm(string role, string username) : this(role)
        {
        }

        private void InitializeUI()
        {
            // Add labels for clarity
            lblExamName.Text = "Exam Name: (Select Exam Below)";

            // Configure DataGridView for Exams
            dataGridViewExams.AutoGenerateColumns = false;
            dataGridViewExams.Columns.Clear();
            dataGridViewExams.Columns.Add("ExamID", "Exam ID");
            dataGridViewExams.Columns["ExamID"].DataPropertyName = "ExamID";
            dataGridViewExams.Columns.Add("ExamName", "Exam Name");
            dataGridViewExams.Columns["ExamName"].DataPropertyName = "ExamName";
            dataGridViewExams.Columns.Add("SubjectID", "Subject ID");
            dataGridViewExams.Columns["SubjectID"].DataPropertyName = "SubjectID";
            dataGridViewExams.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configure ComboBox for Subjects
            comboBoxSubject.DisplayMember = "SubjectName"; // Tentative, adjust based on Subject class
            comboBoxSubject.ValueMember = "SubjectID";

            // Role-based access
            if (_role != "Admin" && _role != "Staff")
            {
                btnAddExam.Enabled = false;
                btnEditExam.Enabled = false;
                btnDeleteExam.Enabled = false;
            }
        }

        private async void LoadData()
        {
            _exams = await _examController.GetExamsAsync();
            _subjects = await GetSubjectsAsync();

            dataGridViewExams.DataSource = null;
            dataGridViewExams.DataSource = _exams;

            comboBoxSubject.DataSource = null;
            comboBoxSubject.DataSource = _subjects;
            comboBoxSubject.DisplayMember = "SubjectName"; // Tentative, adjust based on Subject class
            comboBoxSubject.ValueMember = "SubjectID";

            if (dataGridViewExams.Rows.Count > 0) dataGridViewExams.Rows[0].Selected = true;

            // Debug: Check if subjects are loaded correctly and display their properties
            if (_subjects == null || _subjects.Count == 0)
            {
                MessageBox.Show("No subjects loaded. Check the database or GetSubjectsAsync.", "Error");
            }
            else
            {
                var firstSubject = _subjects[0];
                var displayValue = firstSubject.SubjectName ?? firstSubject.ToString() ?? "No Display Value";
                MessageBox.Show($"First subject loaded: {displayValue}. Check if 'SubjectName' is correct. Please share the Subject class definition.", "Debug");
            }
        }

        private async Task<List<Subject>> GetSubjectsAsync()
        {
            var dbManager = new DatabaseManager();
            return await dbManager.GetSubjectsAsync() ?? new List<Subject>();
        }

        private async void btnAddExam_Click(object sender, EventArgs e)
        {
            if (_role != "Admin" && _role != "Staff") return;

            if (string.IsNullOrWhiteSpace(txtExamName.Text) || comboBoxSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter an exam name and select a subject.", "Input Error");
                return;
            }

            var exam = new Exam
            {
                ExamName = txtExamName.Text,
                SubjectID = (int)comboBoxSubject.SelectedValue
            };
            await _examController.AddExamAsync(exam);
            LoadData();
            txtExamName.Text = "";
            comboBoxSubject.SelectedIndex = -1;
        }

        private async void btnEditExam_Click(object sender, EventArgs e)
        {
            if (_role != "Admin" && _role != "Staff") return;

            if (dataGridViewExams.SelectedRows.Count == 0) return;

            var selectedExam = (Exam)dataGridViewExams.SelectedRows[0].DataBoundItem;
            selectedExam.ExamName = txtExamName.Text;
            selectedExam.SubjectID = (int)comboBoxSubject.SelectedValue;
            await _examController.UpdateExamAsync(selectedExam);
            LoadData();
        }

        private async void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (_role != "Admin" && _role != "Staff") return;

            if (dataGridViewExams.SelectedRows.Count == 0) return;

            var selectedExam = (Exam)dataGridViewExams.SelectedRows[0].DataBoundItem;
            await _examController.DeleteExamAsync(selectedExam.ExamID);
            LoadData();
        }

        private void dataGridViewExams_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count > 0)
            {
                var selectedExam = (Exam)dataGridViewExams.SelectedRows[0].DataBoundItem;
                txtExamName.Text = selectedExam.ExamName ?? "";
                comboBoxSubject.SelectedValue = selectedExam.SubjectID;
            }
            else
            {
                txtExamName.Text = "";
                comboBoxSubject.SelectedIndex = -1;
            }
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {

        }
    }
}