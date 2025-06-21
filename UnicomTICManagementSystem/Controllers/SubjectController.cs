using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class SubjectController
    {
        private readonly DatabaseManager _databaseManager;

        public SubjectController()
        {
            _databaseManager = new DatabaseManager();
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            await _databaseManager.AddSubjectAsync(subject);
        }

        public async Task<List<Subject>> GetSubjectsAsync()
        {
            return await _databaseManager.GetSubjectsAsync();
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            await _databaseManager.UpdateSubjectAsync(subject);
        }

        public async Task DeleteSubjectAsync(int subjectID)
        {
            await _databaseManager.DeleteSubjectAsync(subjectID);
        }
    }
}