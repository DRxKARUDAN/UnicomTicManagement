﻿using System;
using System.Drawing;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Views
{
    public partial class MyProfile : Form
    {
        private string _originalUsername;
        private readonly DatabaseManager _databaseManager = new DatabaseManager();
        private string _currentName;
        private string _currentPassword;

        private Label lblWelcome, lblName, lblUsername, lblPassword, lblConfirmPassword, lblRole;
        private TextBox txtName, txtUsername, txtPassword, txtConfirmPassword;
        private ComboBox cmbRole;
        private Button btnSaveChanges, btnLogout;

        public MyProfile(string username)
        {
            _originalUsername = username;
            InitializeComponent();
            LoadProfile();
        }

        private async void LoadProfile()
        {
            _currentName = _originalUsername;
            var student = await _databaseManager.GetStudentByUsernameAsync(_originalUsername);
            if (student != null)
            {
                _currentName = student.Name;
            }

            _currentPassword = "****"; // Placeholder
            string currentRole = await _databaseManager.GetUserRoleAsync(_originalUsername);

            lblWelcome.Text = $"Welcome, {_currentName}!";

            txtName.Text = _currentName;
            txtUsername.Text = _originalUsername;
            txtPassword.Text = _currentPassword;
            txtConfirmPassword.Text = "";
            cmbRole.SelectedItem = currentRole ?? "Student";
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string newName = txtName.Text.Trim();
            string newUsername = txtUsername.Text.Trim();
            string newRole = cmbRole.SelectedItem?.ToString();
            string newPassword = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newRole))
            {
                MessageBox.Show("Name, Username, and Role cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(newPassword) && newPassword != "****")
            {
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var student = await _databaseManager.GetStudentByUsernameAsync(_originalUsername);
            if (student != null)
            {
                student.Name = newName;
                await _databaseManager.UpdateStudentAsync(student);
            }

            using (var connection = new System.Data.SQLite.SQLiteConnection(_databaseManager._connectionString))
            {
                await connection.OpenAsync();
                var command = new System.Data.SQLite.SQLiteCommand(
                    "UPDATE Users SET Username = @newUsername, Role = @newRole, Password = @newPassword WHERE Username = @originalUsername", connection);
                command.Parameters.AddWithValue("@newUsername", newUsername);
                command.Parameters.AddWithValue("@newRole", newRole);
                command.Parameters.AddWithValue("@newPassword", string.IsNullOrEmpty(newPassword) || newPassword == "****" ? (object)DBNull.Value : newPassword);
                command.Parameters.AddWithValue("@originalUsername", _originalUsername);
                int rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _originalUsername = newUsername;
                    LoadProfile();
                }
                else
                {
                    MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginPage = new LoginForm();
            loginPage.Show();
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            // Form settings
            this.ClientSize = new Size(500, 400);
            this.Name = "MyProfile";
            this.Text = "My Profile";
            this.BackColor = Color.White;

            // Welcome label
            lblWelcome = new Label
            {
                Text = "Welcome, User!",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Labels
            lblName = new Label { Text = "Name:", Font = new Font("Segoe UI", 10), Location = new Point(30, 70), AutoSize = true };
            lblUsername = new Label { Text = "Username:", Font = new Font("Segoe UI", 10), Location = new Point(30, 110), AutoSize = true };
            lblPassword = new Label { Text = "Password:", Font = new Font("Segoe UI", 10), Location = new Point(30, 150), AutoSize = true };
            lblConfirmPassword = new Label { Text = "Confirm Password:", Font = new Font("Segoe UI", 10), Location = new Point(30, 190), AutoSize = true };
            lblRole = new Label { Text = "Role:", Font = new Font("Segoe UI", 10), Location = new Point(30, 230), AutoSize = true };

            // Textboxes
            txtName = new TextBox { Font = new Font("Segoe UI", 10), Location = new Point(180, 70), Size = new Size(250, 27) };
            txtUsername = new TextBox { Font = new Font("Segoe UI", 10), Location = new Point(180, 110), Size = new Size(250, 27) };
            txtPassword = new TextBox { Font = new Font("Segoe UI", 10), Location = new Point(180, 150), Size = new Size(250, 27), PasswordChar = '*' };
            txtConfirmPassword = new TextBox { Font = new Font("Segoe UI", 10), Location = new Point(180, 190), Size = new Size(250, 27), PasswordChar = '*' };

            // ComboBox
            cmbRole = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(180, 230),
                Size = new Size(250, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.AddRange(new object[] { "Admin", "Staff", "Student", "Lecturer" });

            // Buttons
            btnSaveChanges = new Button
            {
                Text = "Save Changes",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Location = new Point(180, 280),
                Size = new Size(120, 35)
            };
            btnSaveChanges.Click += btnSaveChanges_Click;

            btnLogout = new Button
            {
                Text = "Logout",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Location = new Point(310, 280),
                Size = new Size(120, 35)
            };
            btnLogout.Click += btnLogout_Click;

            // Add controls
            this.Controls.Add(lblWelcome);
            this.Controls.Add(lblName);
            this.Controls.Add(lblUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(lblConfirmPassword);
            this.Controls.Add(lblRole);
            this.Controls.Add(txtName);
            this.Controls.Add(txtUsername);
            this.Controls.Add(txtPassword);
            this.Controls.Add(txtConfirmPassword);
            this.Controls.Add(cmbRole);
            this.Controls.Add(btnSaveChanges);
            this.Controls.Add(btnLogout);

            this.Load += MyProfile_Load;
        }
    }
}
