using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Views;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Force DatabaseManager initialization
            var dbManager = new DatabaseManager();
            MessageBox.Show("Database initialized. Check unicomtic.db.", "Info");
            Application.Run(new LoginForm());
        }
    }
}