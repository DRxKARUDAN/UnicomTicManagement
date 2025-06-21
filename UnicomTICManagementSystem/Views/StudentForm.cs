using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Views
{
    public partial class StudentForm : Form
    {
        private readonly StudentController _studentController;
        private readonly CourseController _courseController;
        private readonly string _role;
        private readonly string _username;
        private Student _selectedStudent;

        public StudentForm(string role, string username)
        {
            InitializeComponent();
            _studentController = new StudentController();
            _courseController = new CourseController();
            _role = role;
            _username = username;
            ConfigureForm();
            LoadStudentDetails();
            LoadStudents();
        }

        private void ConfigureForm()
        {
            if (_role != "Admin")
            {
                cmbStudentName.Enabled = false;
                cmbCourse.Enabled = false;
                btnAddStudent.Visible = false;
                btnEditStudent.Visible = false;
                btnDeleteStudent.Visible = false;
            }

            var courses = _courseController.GetCoursesAsync().Result;
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
        }

        private void LoadStudentDetails()
        {
            if (_role == "Student")
            {
                var student = _studentController.GetStudentByUsernameAsync(_username).Result;
                if (student != null)
                {
                    cmbStudentName.Text = student.Name;
                    cmbCourse.SelectedValue = student.CourseID;
                }
            }
        }

        private async Task LoadStudents()
        {
            var studentUsers = await _studentController.GetUsersByRoleAsync("Student");
            lstStudents.DataSource = null;

            var enrolledStudents = await _studentController.GetStudentsAsync();
            lstStudents.DataSource = enrolledStudents;
            lstStudents.DisplayMember = "Name";
            lstStudents.ValueMember = "StudentID";

            cmbStudentName.DataSource = null;
            cmbStudentName.DataSource = studentUsers;
            cmbStudentName.DisplayMember = null;
            cmbStudentName.ValueMember = null;
        }

        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbStudentName.Text.Trim()))
            {
                MessageBox.Show("Student name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingStudent = (await _studentController.GetStudentsAsync())
                .FirstOrDefault(s => s.Name == cmbStudentName.Text.Trim());
            if (existingStudent != null)
            {
                MessageBox.Show("This student is already enrolled.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                Name = cmbStudentName.Text.Trim(),
                CourseID = (int)cmbCourse.SelectedValue
            };
            await _studentController.AddStudentAsync(student);
            await LoadStudents();
            cmbStudentName.Text = "";
        }

        private async void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (_selectedStudent != null)
            {
                if (string.IsNullOrEmpty(cmbStudentName.Text.Trim()))
                {
                    MessageBox.Show("Student name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbCourse.SelectedValue == null)
                {
                    MessageBox.Show("Please select a course.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _selectedStudent.Name = cmbStudentName.Text.Trim();
                _selectedStudent.CourseID = (int)cmbCourse.SelectedValue;
                await _studentController.UpdateStudentAsync(_selectedStudent);
                await LoadStudents();
                cmbStudentName.Text = "";
                _selectedStudent = null;
            }
            else
            {
                MessageBox.Show("Please select a student to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (_selectedStudent != null)
            {
                await _studentController.DeleteStudentAsync(_selectedStudent);
                await LoadStudents();
                cmbStudentName.Text = "";
                _selectedStudent = null;
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedStudent = lstStudents.SelectedItem as Student;
            if (_selectedStudent != null)
            {
                cmbStudentName.Text = _selectedStudent.Name;
                cmbCourse.SelectedValue = _selectedStudent.CourseID;
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
        }

        // Hover Effects — Add
        private void btnAddStudent_MouseEnter(object sender, EventArgs e)
        {
            btnAddStudent.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
        }

        private void btnAddStudent_MouseLeave(object sender, EventArgs e)
        {
            btnAddStudent.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
        }

        // Hover Effects — Edit
        private void btnEditStudent_MouseEnter(object sender, EventArgs e)
        {
            btnEditStudent.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
        }

        private void btnEditStudent_MouseLeave(object sender, EventArgs e)
        {
            btnEditStudent.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
        }

        // Hover Effects — Delete
        private void btnDeleteStudent_MouseEnter(object sender, EventArgs e)
        {
            btnDeleteStudent.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
        }

        private void btnDeleteStudent_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteStudent.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
        }
    }
}
