using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Views
{
    public partial class AttendanceForm : Form
    {
        private readonly string _role;
        private readonly string _username;
        private readonly AttendanceController _attendanceController;
        private List<Attendance> _attendances; // Views.Attendance for UI
        private List<Student> _students;
        private List<Subject> _subjects;

        public AttendanceForm(string role, string username)
        {
            InitializeComponent();
            _role = role;
            _username = username;
            _attendanceController = new AttendanceController();
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            dataGridViewAttendance.AutoGenerateColumns = false;
            dataGridViewAttendance.Columns.Clear();
            dataGridViewAttendance.Columns.Add("AttendanceID", "ID");
            dataGridViewAttendance.Columns["AttendanceID"].DataPropertyName = "AttendanceID";
            dataGridViewAttendance.Columns.Add("StudentName", "Student");
            dataGridViewAttendance.Columns["StudentName"].DataPropertyName = "StudentName";
            dataGridViewAttendance.Columns.Add("SubjectName", "Subject");
            dataGridViewAttendance.Columns["SubjectName"].DataPropertyName = "SubjectName";
            dataGridViewAttendance.Columns.Add("Date", "Date");
            dataGridViewAttendance.Columns["Date"].DataPropertyName = "Date";
            dataGridViewAttendance.Columns.Add("Status", "Status");
            dataGridViewAttendance.Columns["Status"].DataPropertyName = "Status";
            dataGridViewAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var dbManager = new DatabaseManager();
            _students = dbManager.GetStudentsAsync().Result ?? new List<Models.Student>();
            _subjects = dbManager.GetSubjectsAsync().Result ?? new List<Models.Subject>();
            comboBoxSubject.DataSource = new BindingSource(_subjects, null);
            comboBoxSubject.DisplayMember = "SubjectName";
            comboBoxSubject.ValueMember = "SubjectID";
            comboBoxStudent.DataSource = new BindingSource(_students, null);
            comboBoxStudent.DisplayMember = "Name";
            comboBoxStudent.ValueMember = "StudentID";
            dateTimePickerDate.Format = DateTimePickerFormat.Short;

            if (_role != "Admin" && _role != "Lecturer")
            {
                comboBoxSubject.Enabled = false;
                comboBoxStudent.Enabled = false;
                dateTimePickerDate.Enabled = false;
                comboBoxStatus.Enabled = false;
                btnMarkAttendance.Enabled = false;
                btnUpdateAttendance.Enabled = false;
                btnDeleteAttendance.Enabled = false;
            }
            if (_role != "Admin")
            {
                btnDeleteAttendance.Enabled = false;
            }
        }

        private async void LoadData()
        {
            var dbManager = new DatabaseManager();
            var modelAttendances = await _attendanceController.GetAttendanceAsync() ?? new List<Models.Attendance>();
            _students = await dbManager.GetStudentsAsync() ?? new List<Models.Student>();
            _subjects = await dbManager.GetSubjectsAsync() ?? new List<Models.Subject>();

            // Map Models.Attendance to Views.Attendance
            _attendances = modelAttendances.Select(a => new Attendance
            {
                AttendanceID = a.AttendanceID,
                StudentID = a.StudentID,
                SubjectID = a.SubjectID,
                Date = a.Date,
                Status = a.Status,
                StudentName = _students.Find(s => s.StudentID == a.StudentID)?.Name ?? "Unknown",
                SubjectName = _subjects.Find(s => s.SubjectID == a.SubjectID)?.SubjectName ?? "Unknown"
            }).ToList();

            dataGridViewAttendance.DataSource = null;
            dataGridViewAttendance.DataSource = _attendances;
            if (dataGridViewAttendance.Rows.Count > 0) dataGridViewAttendance.Rows[0].Selected = true;
            else MessageBox.Show("No attendance records found.", "Debug Info");
        }

        private int GetCurrentStudentId()
        {
            var dbManager = new DatabaseManager();
            return dbManager.GetStudentIdByUsernameAsync(_username).Result;
        }

        private void LogError(string errorMessage)
        {
            string logFilePath = "error.log";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp}: {errorMessage}\n";
            File.AppendAllText(logFilePath, logEntry);
        }

        private async void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (comboBoxSubject.SelectedIndex == -1 || comboBoxStudent.SelectedIndex == -1 || dateTimePickerDate.Value == null || comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please pick a subject, student, date, and status.", "Input Error");
                LogError("Input error: Missing required fields for marking attendance.");
                return;
            }

            var studentId = (int)comboBoxStudent.SelectedValue;
            var subjectId = (int)comboBoxSubject.SelectedValue;
            var date = dateTimePickerDate.Value.Date;
            var status = comboBoxStatus.SelectedItem.ToString();

            var existingAttendance = _attendances.Find(a => a.StudentID == studentId && a.SubjectID == subjectId && a.Date.Date == date);
            if (existingAttendance != null)
            {
                existingAttendance.Status = status;
                var modelAttendance = new Models.Attendance
                {
                    AttendanceID = existingAttendance.AttendanceID,
                    StudentID = existingAttendance.StudentID,
                    SubjectID = existingAttendance.SubjectID,
                    Date = existingAttendance.Date,
                    Status = existingAttendance.Status
                };
                await _attendanceController.UpdateAttendanceAsync(modelAttendance);
                LoadData();
                MessageBox.Show($"Attendance updated to {status}!", "Success");
            }
            else
            {
                var attendance = new Attendance
                {
                    StudentID = studentId,
                    SubjectID = subjectId,
                    Date = date,
                    Status = status
                };
                var modelAttendance = new Models.Attendance
                {
                    StudentID = attendance.StudentID,
                    SubjectID = attendance.SubjectID,
                    Date = attendance.Date,
                    Status = attendance.Status
                };
                await _attendanceController.AddAttendanceAsync(modelAttendance);
                LoadData();
                MessageBox.Show($"Attendance marked as {status}!", "Success");
            }
        }

        private async void btnUpdateAttendance_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttendance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Error");
                LogError("Error: No row selected for update.");
                return;
            }
            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status to update.", "Input Error");
                LogError("Input error: No status selected for update.");
                return;
            }

            var selectedAttendance = (Attendance)dataGridViewAttendance.SelectedRows[0].DataBoundItem;
            MessageBox.Show($"Attempting to update AttendanceID {selectedAttendance.AttendanceID} to {comboBoxStatus.SelectedItem}", "Debug");
            try
            {
                var modelAttendance = new Models.Attendance
                {
                    AttendanceID = selectedAttendance.AttendanceID,
                    StudentID = selectedAttendance.StudentID,
                    SubjectID = selectedAttendance.SubjectID,
                    Date = selectedAttendance.Date,
                    Status = comboBoxStatus.SelectedItem.ToString()
                };
                await _attendanceController.UpdateAttendanceAsync(modelAttendance);
                LoadData();
                MessageBox.Show($"Attendance updated to {selectedAttendance.Status}!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}", "Error");
                LogError($"Update failed for AttendanceID {selectedAttendance.AttendanceID}: {ex.Message}");
            }
            MessageBox.Show($"Post-update check: Status = {selectedAttendance.Status}", "Debug");
        }

        private async void btnDeleteAttendance_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttendance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Error");
                LogError("Error: No row selected for delete.");
                return;
            }

            var selectedAttendance = (Attendance)dataGridViewAttendance.SelectedRows[0].DataBoundItem;
            MessageBox.Show($"Attempting to delete AttendanceID {selectedAttendance.AttendanceID}", "Debug");
            try
            {
                await _attendanceController.DeleteAttendanceAsync(selectedAttendance.AttendanceID);
                LoadData();
                MessageBox.Show("Attendance deleted!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete failed: {ex.Message}", "Error");
                LogError($"Delete failed for AttendanceID {selectedAttendance.AttendanceID}: {ex.Message}");
            }
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
    }
}