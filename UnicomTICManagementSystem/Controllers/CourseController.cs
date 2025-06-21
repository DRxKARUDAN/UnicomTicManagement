using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class CourseController
    {
        private readonly DatabaseManager _databaseManager;

        public CourseController()
        {
            _databaseManager = new DatabaseManager();
        }

        public async Task AddCourseAsync(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                MessageBox.Show("Course name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await _databaseManager.AddCourseAsync(course);
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _databaseManager.GetCoursesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                MessageBox.Show("Course name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await _databaseManager.UpdateCourseAsync(course);
        }

        public async Task DeleteCourseAsync(Course course)
        {
            await _databaseManager.DeleteCourseAsync(course.CourseID);
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            if (string.IsNullOrEmpty(subject.SubjectName))
            {
                MessageBox.Show("Subject name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (subject.CourseID <= 0)
            {
                MessageBox.Show("Please select a valid course.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await _databaseManager.AddSubjectAsync(subject);
        }

        public async Task<List<Subject>> GetSubjectsAsync()
        {
            return await _databaseManager.GetSubjectsAsync();
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            if (string.IsNullOrEmpty(subject.SubjectName))
            {
                MessageBox.Show("Subject name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (subject.CourseID <= 0)
            {
                MessageBox.Show("Please select a valid course.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await _databaseManager.UpdateSubjectAsync(subject);
        }

        public async Task DeleteSubjectAsync(Subject subject)
        {
            await _databaseManager.DeleteSubjectAsync(subject.SubjectID);
        }
    }
}