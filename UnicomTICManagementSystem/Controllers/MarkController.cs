using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class MarkController
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();

        public async Task<List<Mark>> GetMarksAsync()
        {
            return await _dbManager.GetMarksAsync() ?? new List<Mark>();
        }

        public async Task<List<Mark>> GetMarksByStudentIdAsync(int studentId)
        {
            return await _dbManager.GetMarksByStudentIdAsync(studentId);
        }

        public async Task AddMarkAsync(Mark mark)
        {
            await _dbManager.AddMarkAsync(mark);
        }

        public async Task UpdateMarkAsync(Mark mark)
        {
            await _dbManager.UpdateMarkAsync(mark);
        }

        public async Task DeleteMarkAsync(int markId)
        {
            await _dbManager.DeleteMarkAsync(markId);
        }
    }
}