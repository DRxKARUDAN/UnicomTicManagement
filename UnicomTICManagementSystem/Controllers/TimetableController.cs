using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class TimetableController
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();

        public async Task<List<Timetable>> GetTimetablesAsync()
        {
            return await _dbManager.GetTimetablesAsync() ?? new List<Timetable>();
        }

        public async Task AddTimetableAsync(Timetable timetable)
        {
            await _dbManager.AddTimetableAsync(timetable);
        }

        public async Task UpdateTimetableAsync(Timetable timetable)
        {
            await _dbManager.UpdateTimetableAsync(timetable);
        }

        public async Task DeleteTimetableAsync(int timetableId)
        {
            await _dbManager.DeleteTimetableAsync(timetableId);
        }
    }
}