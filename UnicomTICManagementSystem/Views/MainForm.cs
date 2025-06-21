using System;
using System.Drawing;
using System.Windows.Forms;

namespace UnicomTICManagementSystem.Views
{
    public partial class MainForm : Form
    {
        private readonly string _role;
        private readonly string _username;
        private Panel mainPanel;

        public MainForm(string role, string username)
        {
            InitializeComponent();
            _role = role;
            _username = username;
            ConfigureDashboard();
        }

        private void ConfigureDashboard()
        {
            this.Text = $"Unicom TIC Management System - {_role} Dashboard";
            this.Size = new Size(1200, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Sidebar panel
            Panel sidebar = new Panel
            {
                Size = new Size(200, this.ClientSize.Height),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(33, 37, 41),
                BorderStyle = BorderStyle.None,
                AutoScroll = true
            };
            this.Controls.Add(sidebar);

            // Logo
            PictureBox logoPictureBox = new PictureBox
            {
                Image = Properties.Resources.UnicomTICLogo,
                Size = new Size(180, 80),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.White
            };
            sidebar.Controls.Add(logoPictureBox);

            // Main panel
            mainPanel = new Panel
            {
                Size = new Size(this.ClientSize.Width - sidebar.Width, this.ClientSize.Height),
                Location = new Point(sidebar.Width, 0),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(mainPanel);

            // Add styled buttons
            int yOffset = 100;
            AddSidebarButton(sidebar, "My Profile", yOffset, () => LoadForm(new MyProfile(_username)));
            yOffset += 50;

            if (_role == "Admin")
            {
                AddSidebarButton(sidebar, "Manage Courses", yOffset, () => LoadForm(new CourseForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Students", yOffset, () => LoadForm(new StudentForm(_role, _username))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Timetables", yOffset, () => LoadForm(new TimetableForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Exams", yOffset, () => LoadForm(new ExamForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Marks", yOffset, () => LoadForm(new MarkForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Attendance", yOffset, () => LoadForm(new AttendanceForm(_role, _username))); yOffset += 50;
            }
            else if (_role == "Staff")
            {
                AddSidebarButton(sidebar, "View Timetable", yOffset, () => LoadForm(new TimetableForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Exams", yOffset, () => LoadForm(new ExamForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Marks", yOffset, () => LoadForm(new MarkForm(_role))); yOffset += 50;
            }
            else if (_role == "Student")
            {
                AddSidebarButton(sidebar, "View Timetable", yOffset, () => LoadForm(new TimetableForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "View My Marks", yOffset, () => LoadForm(new MarkForm(_role, _username))); yOffset += 50;
                AddSidebarButton(sidebar, "View My Details", yOffset, () => LoadForm(new StudentForm(_role, _username))); yOffset += 50;
            }
            else if (_role == "Lecturer")
            {
                AddSidebarButton(sidebar, "View Timetable", yOffset, () => LoadForm(new TimetableForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Marks", yOffset, () => LoadForm(new MarkForm(_role))); yOffset += 50;
                AddSidebarButton(sidebar, "Manage Attendance", yOffset, () => LoadForm(new AttendanceForm(_role, _username))); yOffset += 50;
            }

            LoadForm(new MyProfile(_username)); // Default page
        }

        private void AddSidebarButton(Panel sidebar, string text, int yOffset, Action clickAction)
        {
            Button button = new Button
            {
                Text = text,
                Location = new Point(10, yOffset),
                Size = new Size(180, 40),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(52, 58, 64),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;

            button.MouseEnter += (s, e) => button.BackColor = Color.FromArgb(70, 80, 90);
            button.MouseLeave += (s, e) => button.BackColor = Color.FromArgb(52, 58, 64);

            button.Click += (s, e) => clickAction();
            sidebar.Controls.Add(button);
        }

        public void LoadForm(object formObj)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);

            Form form = formObj as Form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            this.mainPanel.Tag = form;
            form.Show();
        }

        private void LogToFile(string message)
        {
            string logFilePath = "error.log";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp}: {message}\n";
            System.IO.File.AppendAllText(logFilePath, logEntry);
        }

        private void MainForm_Load(object sender, EventArgs e) { }
    }

    public class Dashboard : Form
    {
        public Dashboard()
        {
            this.Text = "Dashboard";
            this.Size = new Size(600, 500);
            this.FormBorderStyle = FormBorderStyle.None;

            Label label = new Label
            {
                Text = "Welcome to Unicom TIC Management System",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(30, 30),
                AutoSize = true
            };
            this.Controls.Add(label);
        }
    }
}
