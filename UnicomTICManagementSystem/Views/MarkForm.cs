using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Views
{
    public partial class MarkForm : Form
    {
        private readonly string _role;
        private readonly string _username;
        private readonly MarkController _markController;
        private List<Mark> _marks; // Views.Mark for UI
        private List<Student> _students;
        private List<Exam> _exams;
        private Panel _buttonPanel;
        private Button btnShowTopMarks;

        public MarkForm(string role)
        {
            InitializeComponent();
            _role = role;
            _markController = new MarkController();
            InitializeUI();
            LoadData();
        }

        public MarkForm(string role, string username)
        {
            InitializeComponent();
            _role = role;
            _username = username;
            _markController = new MarkController();
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            dataGridViewMarks.AutoGenerateColumns = false;
            dataGridViewMarks.Columns.Clear();
            dataGridViewMarks.Columns.Add("MarkID", "Mark ID");
            dataGridViewMarks.Columns["MarkID"].DataPropertyName = "MarkID";
            dataGridViewMarks.Columns.Add("StudentName", "Student");
            dataGridViewMarks.Columns["StudentName"].DataPropertyName = "StudentName";
            dataGridViewMarks.Columns.Add("ExamName", "Exam");
            dataGridViewMarks.Columns["ExamName"].DataPropertyName = "ExamName";
            dataGridViewMarks.Columns.Add("Score", "Score");
            dataGridViewMarks.Columns["Score"].DataPropertyName = "Score";
            dataGridViewMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var dbManager = new DatabaseManager();
            _students = dbManager.GetStudentsAsync().Result ?? new List<Models.Student>();
            _exams = dbManager.GetExamsAsync().Result ?? new List<Models.Exam>();
            comboBoxStudents.DataSource = _students;
            comboBoxStudents.DisplayMember = "Name";
            comboBoxStudents.ValueMember = "StudentID";
            comboBoxExams.DataSource = _exams;
            comboBoxExams.DisplayMember = "ExamName";
            comboBoxExams.ValueMember = "ExamID";

            // Create and configure the panel for the button
            _buttonPanel = new Panel
            {
                Location = new System.Drawing.Point(this.ClientSize.Width - 160, this.ClientSize.Height - 40), // Right bottom corner with padding
                Size = new System.Drawing.Size(150, 30),
                BorderStyle = BorderStyle.None
            };
            btnShowTopMarks = new Button
            {
                Text = "Show Top Marks",
                Location = new System.Drawing.Point(0, 0), // Positioned at the top-left of the panel
                Size = new System.Drawing.Size(150, 23)
            };
            btnShowTopMarks.Click += BtnShowTopMarks_Click;
            _buttonPanel.Controls.Add(btnShowTopMarks);
            this.Controls.Add(_buttonPanel);

            if (_role != "Admin" && _role != "Staff" && _role != "Lecturer")
            {
                btnAddMark.Enabled = false;
                btnEditMark.Enabled = false;
                btnDeleteMark.Enabled = false;
                txtScore.Enabled = false;
                comboBoxStudents.Enabled = false;
                comboBoxExams.Enabled = false;
            }
            else if (_role == "Student" && !string.IsNullOrEmpty(_username))
            {
                var student = dbManager.GetStudentByUsernameAsync(_username).Result;
                if (student != null)
                {
                    comboBoxStudents.SelectedValue = student.StudentID;
                    comboBoxStudents.Enabled = false;
                }
            }

            if (_role != "Admin" && _role != "Staff" && _role != "Lecturer" && _role != "Student")
            {
                btnShowTopMarks.Enabled = false;
            }
        }

        private async void LoadData()
        {
            var dbManager = new DatabaseManager();
            var modelMarks = await dbManager.GetMarksAsync() ?? new List<Models.Mark>();
            _students = await dbManager.GetStudentsAsync() ?? new List<Models.Student>();
            _exams = await dbManager.GetExamsAsync() ?? new List<Models.Exam>();

            // Map Models.Mark to Views.Mark
            _marks = modelMarks.Select(m => new Mark
            {
                MarkID = m.MarkID,
                StudentID = m.StudentID,
                ExamID = m.ExamID,
                Score = m.Score,
                StudentName = _students.Find(s => s.StudentID == m.StudentID)?.Name ?? "Unknown",
                ExamName = _exams.Find(e => e.ExamID == m.ExamID)?.ExamName ?? "Unknown"
            }).ToList();

            dataGridViewMarks.DataSource = null;
            dataGridViewMarks.DataSource = _marks;
            if (dataGridViewMarks.Rows.Count > 0) dataGridViewMarks.Rows[0].Selected = true;
        }

        private void BtnShowTopMarks_Click(object sender, EventArgs e)
        {
            var topMarks = _marks.OrderByDescending(m => m.Score).Take(3).ToList();
            string message = "Top 3 Students by Marks:\n";
            foreach (var mark in topMarks)
            {
                message += $"{mark.StudentName}: {mark.Score}\n";
            }
            MessageBox.Show(message, "Top Marks");
        }

        private void LogError(string errorMessage)
        {
            string logFilePath = "error.log";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp}: {errorMessage}\n";
            File.AppendAllText(logFilePath, logEntry);
        }

        private async void btnAddMark_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtScore.Text, out int score) && comboBoxStudents.SelectedIndex != -1 && comboBoxExams.SelectedIndex != -1)
            {
                var mark = new Mark
                {
                    StudentID = (int)comboBoxStudents.SelectedValue,
                    ExamID = (int)comboBoxExams.SelectedValue,
                    Score = score
                };
                try
                {
                    var modelMark = new Models.Mark
                    {
                        StudentID = mark.StudentID,
                        ExamID = mark.ExamID,
                        Score = mark.Score
                    };
                    await _markController.AddMarkAsync(modelMark);
                    LoadData();
                    MessageBox.Show("Mark saved!", "Success");
                    txtScore.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to add mark: {ex.Message}", "Error");
                    LogError($"Failed to add mark for StudentID {mark.StudentID}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid score and select a student and exam.", "Input Error");
                LogError("Input error: Missing required fields or invalid score for adding mark.");
            }
        }

        private async void btnEditMark_Click(object sender, EventArgs e)
        {
            if (dataGridViewMarks.SelectedRows.Count > 0 && int.TryParse(txtScore.Text, out int score))
            {
                var selectedMark = (Mark)dataGridViewMarks.SelectedRows[0].DataBoundItem;
                var modelMark = new Models.Mark
                {
                    MarkID = selectedMark.MarkID,
                    StudentID = (int)comboBoxStudents.SelectedValue,
                    ExamID = (int)comboBoxExams.SelectedValue,
                    Score = score
                };
                try
                {
                    await _markController.UpdateMarkAsync(modelMark);
                    LoadData();
                    MessageBox.Show("Mark updated!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update mark: {ex.Message}", "Error");
                    LogError($"Failed to update mark ID {selectedMark.MarkID}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a mark and enter a valid score.", "Input Error");
                LogError("Input error: No mark selected or invalid score for editing mark.");
            }
        }

        private async void btnDeleteMark_Click(object sender, EventArgs e)
        {
            if (dataGridViewMarks.SelectedRows.Count > 0)
            {
                var selectedMark = (Mark)dataGridViewMarks.SelectedRows[0].DataBoundItem;
                var modelMark = new Models.Mark { MarkID = selectedMark.MarkID };
                try
                {
                    await _markController.DeleteMarkAsync(modelMark.MarkID);
                    LoadData();
                    MessageBox.Show("Mark deleted!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete mark: {ex.Message}", "Error");
                    LogError($"Failed to delete mark ID {selectedMark.MarkID}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a mark to delete.", "Input Error");
                LogError("Input error: No mark selected for deletion.");
            }
        }

        private void dataGridViewMarks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMarks.SelectedRows.Count > 0)
            {
                var selectedMark = (Mark)dataGridViewMarks.SelectedRows[0].DataBoundItem;
                txtScore.Text = selectedMark.Score.ToString();
                comboBoxStudents.SelectedValue = selectedMark.StudentID;
                comboBoxExams.SelectedValue = selectedMark.ExamID;
            }
            else
            {
                txtScore.Text = "";
                comboBoxStudents.SelectedIndex = -1;
                comboBoxExams.SelectedIndex = -1;
            }
        }

        private void MarkForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Mark
    {
        public int MarkID { get; set; }
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int Score { get; set; }
        public string StudentName { get; set; }
        public string ExamName { get; set; }
    }
}