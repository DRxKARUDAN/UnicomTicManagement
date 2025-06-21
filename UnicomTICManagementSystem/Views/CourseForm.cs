using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;
using System.Collections.Generic;

namespace UnicomTICManagementSystem.Views
{
    public partial class CourseForm : Form
    {
        private readonly CourseController _courseController;
        private readonly string _role;
        private Course _selectedCourse;
        private Subject _selectedSubject;

        public CourseForm(string role)
        {
            InitializeComponent();
            _courseController = new CourseController();
            _role = role;
            ConfigureForm();
            LoadCourses();
            LoadSubjects();
        }

        private void ConfigureForm()
        {
            // Hide admin-only controls for non-admin users
            if (_role != "Admin")
            {
                txtCourseName.Enabled = false;
                btnAddCourse.Visible = false;
                btnEditCourse.Visible = false;
                btnDeleteCourse.Visible = false;
                txtSubjectName.Enabled = false;
                cmbCourse.Enabled = false;
                btnAddSubject.Visible = false;
                btnEditSubject.Visible = false;
                btnDeleteSubject.Visible = false;
            }
        }

        private async void LoadCourses()
        {
            var courses = await _courseController.GetCoursesAsync();
            lstCourses.DataSource = null;
            lstCourses.DataSource = courses;
            lstCourses.DisplayMember = "CourseName";
            lstCourses.ValueMember = "CourseID";
            // Update ComboBox for subjects
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
        }

        private async void LoadSubjects()
        {
            var subjects = await _courseController.GetSubjectsAsync();
            lstSubjects.DataSource = null;
            lstSubjects.DataSource = subjects;
            lstSubjects.DisplayMember = "SubjectName";
            lstSubjects.ValueMember = "SubjectID";
        }

        private async void btnAddCourse_Click(object sender, EventArgs e)
        {
            var course = new Course { CourseName = txtCourseName.Text.Trim() };
            await _courseController.AddCourseAsync(course);
            LoadCourses();
            txtCourseName.Clear();
        }

        private async void btnEditCourse_Click(object sender, EventArgs e)
        {
            if (_selectedCourse != null)
            {
                _selectedCourse.CourseName = txtCourseName.Text.Trim();
                await _courseController.UpdateCourseAsync(_selectedCourse);
                LoadCourses();
                txtCourseName.Clear();
                _selectedCourse = null;
            }
            else
            {
                MessageBox.Show("Please select a course to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (_selectedCourse != null)
            {
                await _courseController.DeleteCourseAsync(_selectedCourse);
                LoadCourses();
                txtCourseName.Clear();
                _selectedCourse = null;
            }
            else
            {
                MessageBox.Show("Please select a course to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var subject = new Subject
            {
                SubjectName = txtSubjectName.Text.Trim(),
                CourseID = (int)cmbCourse.SelectedValue
            };
            await _courseController.AddSubjectAsync(subject);
            LoadSubjects();
            txtSubjectName.Clear();
        }

        private async void btnEditSubject_Click(object sender, EventArgs e)
        {
            if (_selectedSubject != null)
            {
                if (cmbCourse.SelectedValue == null)
                {
                    MessageBox.Show("Please select a course.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _selectedSubject.SubjectName = txtSubjectName.Text.Trim();
                _selectedSubject.CourseID = (int)cmbCourse.SelectedValue;
                await _courseController.UpdateSubjectAsync(_selectedSubject);
                LoadSubjects();
                txtSubjectName.Clear();
                _selectedSubject = null;
            }
            else
            {
                MessageBox.Show("Please select a subject to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (_selectedSubject != null)
            {
                await _courseController.DeleteSubjectAsync(_selectedSubject);
                LoadSubjects();
                txtSubjectName.Clear();
                _selectedSubject = null;
            }
            else
            {
                MessageBox.Show("Please select a subject to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCourse = lstCourses.SelectedItem as Course;
            if (_selectedCourse != null)
            {
                txtCourseName.Text = _selectedCourse.CourseName;
            }
        }

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSubject = lstSubjects.SelectedItem as Subject;
            if (_selectedSubject != null)
            {
                txtSubjectName.Text = _selectedSubject.SubjectName;
                cmbCourse.SelectedValue = _selectedSubject.CourseID;
            }
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}