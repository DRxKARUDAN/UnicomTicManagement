using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class StudentController
    {
        private readonly DatabaseManager _databaseManager;

        public StudentController()
        {
            _databaseManager = new DatabaseManager();
        }

        public async Task AddStudentAsync(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                MessageBox.Show("Student name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (student.CourseID <= 0)
            {
                MessageBox.Show("Please select a valid course.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await _databaseManager.AddStudentAsync(student);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _databaseManager.GetStudentsAsync();
        }

        public async Task<Student> GetStudentByUsernameAsync(string username)
        {
            return await _databaseManager.GetStudentByUsernameAsync(username);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                MessageBox.Show("Student name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (student.CourseID <= 0)
            {
                MessageBox.Show("Please select a valid course.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await _databaseManager.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(Student student)
        {
            await _databaseManager.DeleteStudentAsync(student.StudentID);
        }

        public async Task<List<string>> GetUsersByRoleAsync(string role)
        {
            return await _databaseManager.GetUsersByRoleAsync(role);
        }
    }
}