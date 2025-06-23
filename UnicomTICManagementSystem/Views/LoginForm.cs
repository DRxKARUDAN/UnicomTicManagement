using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Views
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseManager _dbManager;

        public LoginForm()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
            // Populate role dropdown (hidden by default)
            comboRole.Items.AddRange(new string[] { "Admin", "Staff", "Student", "Lecturer" });
            comboRole.SelectedIndex = 2; // Default to Student
            // Hide role controls by default (login mode)
            lblRole.Visible = false;
            comboRole.Visible = false;
            // Sync checkbox state with visibility
            chkRegisterNewUser.CheckedChanged += (s, e) =>
            {
                bool isRegisterMode = chkRegisterNewUser.Checked;
                lblRole.Visible = isRegisterMode;
                comboRole.Visible = isRegisterMode;
                // Adjust form height dynamically
                this.ClientSize = new Size(429, isRegisterMode ? 228 : 188);
                this.MinimumSize = new Size(445, 188);


            };
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error");
                return;
            }

            string role = await _dbManager.ValidateUserAsync(username, password);
            if (role != null)
            {
                MainForm mainForm = new MainForm(role, username);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error");
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (!chkRegisterNewUser.Checked)
            {
                MessageBox.Show("Please check 'Register New User' to register a new account.", "Registration Error");
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = comboRole.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please enter username, password, and select a role for registration.", "Registration Error");
                return;
            }

            // Check if username already exists
            string existingRole = await _dbManager.ValidateUserAsync(username, password);
            if (existingRole != null)
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Registration Error");
                return;
            }

            // Register new user with selected role
            bool success = await _dbManager.AddUserAsync(username, password, role);
            if (success)
            {
                MessageBox.Show("Registration successful! You can now log in.", "Registration Success");
                txtUsername.Text = "";
                txtPassword.Text = "";
                chkRegisterNewUser.Checked = false; // Return to login mode
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Registration Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Enable keyboard navigation
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
                if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
            };
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add password validation or feedback here if needed
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
