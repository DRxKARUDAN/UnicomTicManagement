/*using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Views
{
    public partial class RegisterForm : Form
    {
        private readonly DatabaseManager _dbManager;
        private TextBox txtNewUsername;
        private TextBox txtNewPassword;
        private ComboBox cmbRole;
        private Button btnRegister;
        private Button btnClose;

        public RegisterForm(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Register New User";
            this.Size = new System.Drawing.Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;

            // Username Label and TextBox
            Label lblNewUsername = new Label
            {
                AutoSize = true,
                Location = new Point(20, 20),
                Text = "Username:"
            };
            txtNewUsername = new TextBox
            {
                Location = new Point(100, 15),
                Size = new Size(170, 20)
            };

            // Password Label and TextBox
            Label lblNewPassword = new Label
            {
                AutoSize = true,
                Location = new Point(20, 50),
                Text = "Password:"
            };
            txtNewPassword = new TextBox
            {
                Location = new Point(100, 45),
                Size = new Size(170, 20),
                PasswordChar = '*'
            };

            // Role Label and ComboBox
            Label lblRole = new Label
            {
                AutoSize = true,
                Location = new Point(20, 80),
                Text = "Role:"
            };
            cmbRole = new ComboBox
            {
                Location = new Point(100, 75),
                Size = new Size(170, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.AddRange(new string[] { "Admin", "Staff", "Student", "Lecturer" });

            // Register Button
            btnRegister = new Button
            {
                Text = "Register",
                Location = new Point(50, 120),
                Size = new Size(75, 30)
            };
            btnRegister.Click += BtnRegister_Click;

            // Close Button
            btnClose = new Button
            {
                Text = "Close",
                Location = new Point(150, 120),
                Size = new Size(75, 30)
            };
            btnClose.Click += (s, e) => this.Close();

            // Add controls
            this.Controls.Add(lblNewUsername);
            this.Controls.Add(txtNewUsername);
            this.Controls.Add(lblNewPassword);
            this.Controls.Add(txtNewPassword);
            this.Controls.Add(lblRole);
            this.Controls.Add(cmbRole);
            this.Controls.Add(btnRegister);
            this.Controls.Add(btnClose);
        }

        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || role == null)
            {
                MessageBox.Show("Please fill all fields.", "Registration Error");
                return;
            }

            // Hash password
            string hashedPassword = HashPassword(password);

            // Check if username already exists
            if (await _dbManager.ValidateUserAsync(username, hashedPassword) != null)
            {
                MessageBox.Show("Username already exists.", "Registration Error");
                return;
            }

            // Add user to database
            bool success = await _dbManager.AddUserAsync(username, hashedPassword, role);
            if (success)
            {
                MessageBox.Show("Registration successful! You can now log in.", "Success");
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Error");
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}*/