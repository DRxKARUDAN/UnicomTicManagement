using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class ExamController
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();

        public async Task<List<Exam>> GetExamsAsync()
        {
            return await _dbManager.GetExamsAsync() ?? new List<Exam>();
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _dbManager.GetStudentsAsync() ?? new List<Student>();
        }

        public async Task AddExamAsync(Exam exam)
        {
            await _dbManager.AddExamAsync(exam);
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            await _dbManager.UpdateExamAsync(exam);
        }

        public async Task DeleteExamAsync(int examId)
        {
            await _dbManager.DeleteExamAsync(examId);
        }
    }
}