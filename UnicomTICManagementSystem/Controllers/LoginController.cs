using System.Threading.Tasks;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class LoginController
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();

        public async Task<bool> ValidateLogin(string username, string password)
        {
            string role = await _dbManager.ValidateUserAsync(username, password);
            return role != null; // Convert string to bool based on whether role exists
        }
    }
}