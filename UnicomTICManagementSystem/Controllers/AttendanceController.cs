using System.Threading.Tasks;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class AttendanceController
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();

        public async Task<List<Attendance>> GetAttendanceAsync()
        {
            return await _dbManager.GetAttendanceAsync();
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _dbManager.AddAttendanceAsync(attendance);
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            // Implement update logic (e.g., UPDATE Attendance SET Status = @Status WHERE AttendanceID = @AttendanceID)
        }

        public async Task DeleteAttendanceAsync(int attendanceId)
        {
            // Implement delete logic (e.g., DELETE FROM Attendance WHERE AttendanceID = @AttendanceID)
        }
    }
}