using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Views
{
    public partial class TimetableForm : Form
    {
        private readonly string _role;
        private readonly TimetableController _timetableController;
        private List<Timetable> _timetables; // Views.Timetable for UI
        private List<Subject> _subjects;
        private List<Room> _rooms;

        public TimetableForm(string role)
        {
            InitializeComponent();
            _role = role;
            _timetableController = new TimetableController();
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            dataGridViewTimetable.AutoGenerateColumns = false;
            dataGridViewTimetable.Columns.Clear();
            dataGridViewTimetable.Columns.Add("TimetableID", "Timetable ID");
            dataGridViewTimetable.Columns["TimetableID"].DataPropertyName = "TimetableID";
            dataGridViewTimetable.Columns.Add("SubjectName", "Subject");
            dataGridViewTimetable.Columns["SubjectName"].DataPropertyName = "SubjectName";
            dataGridViewTimetable.Columns.Add("TimeSlot", "Time Slot");
            dataGridViewTimetable.Columns["TimeSlot"].DataPropertyName = "TimeSlot";
            dataGridViewTimetable.Columns.Add("RoomName", "Room");
            dataGridViewTimetable.Columns["RoomName"].DataPropertyName = "RoomName";
            dataGridViewTimetable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var dbManager = new DatabaseManager();
            _subjects = dbManager.GetSubjectsAsync().Result ?? new List<Models.Subject>();
            _rooms = dbManager.GetRoomsAsync().Result ?? new List<Models.Room>();
            comboBoxSubject.DataSource = new BindingSource(_subjects, null);
            comboBoxSubject.DisplayMember = "SubjectName";
            comboBoxSubject.ValueMember = "SubjectID";
            comboBoxTimeSlot.Items.AddRange(new string[] { "Monday 10 AM", "Monday 12 PM", "Tuesday 10 AM", "Tuesday 2 PM", "Wednesday 10 AM" });
            comboBoxRoom.DataSource = new BindingSource(_rooms, null);
            comboBoxRoom.DisplayMember = "RoomName";
            comboBoxRoom.ValueMember = "RoomID";

            // Adjust dataGridViewTimetable size and position
            dataGridViewTimetable.Location = new System.Drawing.Point(20, 20);
            dataGridViewTimetable.Size = new System.Drawing.Size(550, 150); // Reduced height

            // Reposition combo boxes and labels below the grid with better spacing
            int baseX = 20;
            int baseY = 180; // Moved up for better layout
            Label lblSubject = new Label { Text = "Subject:", Location = new System.Drawing.Point(baseX, baseY), Size = new System.Drawing.Size(60, 20) };
            comboBoxSubject.Location = new System.Drawing.Point(baseX + 70, baseY);
            comboBoxSubject.Size = new System.Drawing.Size(150, 21);

            Label lblTimeSlot = new Label { Text = "Time Slot:", Location = new System.Drawing.Point(baseX, baseY + 40), Size = new System.Drawing.Size(60, 20) };
            comboBoxTimeSlot.Location = new System.Drawing.Point(baseX + 70, baseY + 40);
            comboBoxTimeSlot.Size = new System.Drawing.Size(150, 21);

            Label lblRoom = new Label { Text = "Room:", Location = new System.Drawing.Point(baseX, baseY + 80), Size = new System.Drawing.Size(60, 20) };
            comboBoxRoom.Location = new System.Drawing.Point(baseX + 70, baseY + 80);
            comboBoxRoom.Size = new System.Drawing.Size(150, 21);

            this.Controls.Add(lblSubject);
            this.Controls.Add(lblTimeSlot);
            this.Controls.Add(lblRoom);

            // Reposition room type filter
            comboBoxRoomType = new ComboBox
            {
                Location = new System.Drawing.Point(baseX + 230, baseY),
                Size = new System.Drawing.Size(150, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxRoomType.Items.AddRange(new string[] { "All", "Halls", "Labs" });
            comboBoxRoomType.SelectedIndex = 0;
            comboBoxRoomType.SelectedIndexChanged += ComboBoxRoomType_SelectedIndexChanged;
            this.Controls.Add(comboBoxRoomType);

            // Use existing designer buttons and assign event handlers
            btnAddTimetable.Click += btnAddTimetable_Click;
            btnEditTimetable.Click += btnEditTimetable_Click;
            btnDeleteTimetable.Click += btnDeleteTimetable_Click;

            // Set form size to accommodate all controls
            this.ClientSize = new System.Drawing.Size(600, 350);

            if (_role != "Admin")
            {
                comboBoxSubject.Enabled = false;
                comboBoxTimeSlot.Enabled = false;
                comboBoxRoom.Enabled = false;
                comboBoxRoomType.Enabled = false;
                btnAddTimetable.Enabled = false;
                btnEditTimetable.Enabled = false;
                btnDeleteTimetable.Enabled = false;
            }
        }

        private async void LoadData()
        {
            var dbManager = new DatabaseManager();
            var modelTimetables = await _timetableController.GetTimetablesAsync();
            // Only update _subjects and _rooms if they are null to avoid overwriting valid data
            if (_subjects == null) _subjects = await dbManager.GetSubjectsAsync() ?? new List<Models.Subject>();
            if (_rooms == null) _rooms = await dbManager.GetRoomsAsync() ?? new List<Models.Room>();

            // Map Models.Timetable to Views.Timetable
            _timetables = modelTimetables.Select(m => new Timetable
            {
                TimetableID = m.TimetableID,
                SubjectID = m.SubjectID,
                TimeSlot = m.TimeSlot,
                RoomID = m.RoomID,
                SubjectName = _subjects.Find(s => s.SubjectID == m.SubjectID)?.SubjectName ?? "Unknown",
                RoomName = _rooms.Find(r => r.RoomID == m.RoomID)?.RoomName ?? "Unknown"
            }).ToList();

            // Log room types for debugging
            LogError("Room Types: " + string.Join(", ", _rooms.Select(r => r.Type ?? "null")));

            ApplyRoomFilter();
        }

        private void ApplyRoomFilter()
        {
            var filterType = comboBoxRoomType.SelectedItem.ToString();
            var filteredTimetables = _timetables;
            if (filterType != "All")
            {
                filteredTimetables = _timetables.FindAll(t =>
                {
                    var room = _rooms.Find(r => r.RoomID == t.RoomID);
                    if (room == null || room.RoomName == null)
                    {
                        LogError($"Room ID {t.RoomID} has no Name or is null");
                        return false;
                    }
                    return (filterType == "Halls" && room.RoomName.ToLower().Contains("hall")) ||
                           (filterType == "Labs" && room.RoomName.ToLower().Contains("lab"));
                });
            }
            dataGridViewTimetable.DataSource = null;
            dataGridViewTimetable.DataSource = filteredTimetables;

            if (dataGridViewTimetable.Rows.Count > 0) dataGridViewTimetable.Rows[0].Selected = true;
            else LogError($"No timetables found for filter: {filterType}");
        }

        private void ComboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyRoomFilter();
        }

        private void LogError(string errorMessage)
        {
            string logFilePath = "error.log";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp}: {errorMessage}\n";
            File.AppendAllText(logFilePath, logEntry);
        }

        private async void btnAddTimetable_Click(object sender, EventArgs e)
        {
            if (_role != "Admin") return;

            if (comboBoxSubject.SelectedIndex == -1 || comboBoxTimeSlot.SelectedIndex == -1 || comboBoxRoom.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a subject, time slot, and room.", "Input Error");
                LogError("Input error: Missing required fields for adding timetable.");
                return;
            }

            var timetable = new Timetable
            {
                SubjectID = (int)comboBoxSubject.SelectedValue,
                TimeSlot = comboBoxTimeSlot.SelectedItem.ToString(),
                RoomID = (int)comboBoxRoom.SelectedValue
            };
            try
            {
                var modelTimetable = new Models.Timetable
                {
                    SubjectID = timetable.SubjectID,
                    TimeSlot = timetable.TimeSlot,
                    RoomID = timetable.RoomID
                };
                await _timetableController.AddTimetableAsync(modelTimetable);
                LoadData();
                MessageBox.Show("Timetable saved!", "Success");
                comboBoxSubject.SelectedIndex = -1;
                comboBoxTimeSlot.SelectedIndex = -1;
                comboBoxRoom.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add timetable: {ex.Message}", "Error");
                LogError($"Failed to add timetable: {ex.Message}");
            }
        }

        private async void btnEditTimetable_Click(object sender, EventArgs e)
        {
            if (_role != "Admin") return;

            if (dataGridViewTimetable.SelectedRows.Count == 0) return;

            var selectedTimetable = (Timetable)dataGridViewTimetable.SelectedRows[0].DataBoundItem;
            var modelTimetable = new Models.Timetable
            {
                TimetableID = selectedTimetable.TimetableID,
                SubjectID = (int)comboBoxSubject.SelectedValue,
                TimeSlot = comboBoxTimeSlot.SelectedItem.ToString(),
                RoomID = (int)comboBoxRoom.SelectedValue
            };
            try
            {
                await _timetableController.UpdateTimetableAsync(modelTimetable);
                LoadData();
                MessageBox.Show("Timetable updated!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update timetable: {ex.Message}", "Error");
                LogError($"Failed to update timetable ID {selectedTimetable.TimetableID}: {ex.Message}");
            }
        }

        private async void btnDeleteTimetable_Click(object sender, EventArgs e)
        {
            if (_role != "Admin") return;

            if (dataGridViewTimetable.SelectedRows.Count == 0) return;

            var selectedTimetable = (Timetable)dataGridViewTimetable.SelectedRows[0].DataBoundItem;
            try
            {
                await _timetableController.DeleteTimetableAsync(selectedTimetable.TimetableID);
                LoadData();
                MessageBox.Show("Timetable deleted!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete timetable: {ex.Message}", "Error");
                LogError($"Failed to delete timetable ID {selectedTimetable.TimetableID}: {ex.Message}");
            }
        }

        private void dataGridViewTimetable_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTimetable.SelectedRows.Count > 0)
            {
                var selectedTimetable = (Timetable)dataGridViewTimetable.SelectedRows[0].DataBoundItem;
                comboBoxSubject.SelectedValue = selectedTimetable.SubjectID;
                comboBoxTimeSlot.SelectedItem = selectedTimetable.TimeSlot;
                comboBoxRoom.SelectedValue = selectedTimetable.RoomID;
            }
            else
            {
                comboBoxSubject.SelectedIndex = -1;
                comboBoxTimeSlot.SelectedIndex = -1;
                comboBoxRoom.SelectedIndex = -1;
            }
        }

        private ComboBox comboBoxRoomType;

        private void TimetableForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Timetable
    {
        public int TimetableID { get; set; }
        public int SubjectID { get; set; }
        public string TimeSlot { get; set; }
        public int RoomID { get; set; }
        public string SubjectName { get; set; }
        public string RoomName { get; set; }
    }
}