namespace UnicomTICManagementSystem.Views
{
    partial class TimetableForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelContainer;

        private System.Windows.Forms.DataGridView dataGridViewTimetable;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.ComboBox comboBoxTimeSlot;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.Button btnAddTimetable;
        private System.Windows.Forms.Button btnEditTimetable;
        private System.Windows.Forms.Button btnDeleteTimetable;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblTimeSlot;
        private System.Windows.Forms.Label lblRoom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelContainer = new Panel();
            dataGridViewTimetable = new DataGridView();
            lblSubject = new Label();
            comboBoxSubject = new ComboBox();
            lblTimeSlot = new Label();
            comboBoxTimeSlot = new ComboBox();
            lblRoom = new Label();
            comboBoxRoom = new ComboBox();
            btnAddTimetable = new Button();
            btnEditTimetable = new Button();
            btnDeleteTimetable = new Button();
            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTimetable).BeginInit();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.FromArgb(245, 245, 245);
            panelContainer.BorderStyle = BorderStyle.FixedSingle;
            panelContainer.Controls.Add(dataGridViewTimetable);
            panelContainer.Controls.Add(lblSubject);
            panelContainer.Controls.Add(comboBoxSubject);
            panelContainer.Controls.Add(lblTimeSlot);
            panelContainer.Controls.Add(comboBoxTimeSlot);
            panelContainer.Controls.Add(lblRoom);
            panelContainer.Controls.Add(comboBoxRoom);
            panelContainer.Controls.Add(btnAddTimetable);
            panelContainer.Controls.Add(btnEditTimetable);
            panelContainer.Controls.Add(btnDeleteTimetable);
            panelContainer.Location = new Point(12, 12);
            panelContainer.Name = "panelContainer";
            panelContainer.Padding = new Padding(15);
            panelContainer.Size = new Size(642, 445);
            panelContainer.TabIndex = 0;
            // 
            // dataGridViewTimetable
            // 
            dataGridViewTimetable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTimetable.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTimetable.Location = new Point(15, 15);
            dataGridViewTimetable.MultiSelect = false;
            dataGridViewTimetable.Name = "dataGridViewTimetable";
            dataGridViewTimetable.RowHeadersWidth = 51;
            dataGridViewTimetable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTimetable.Size = new Size(560, 300);
            dataGridViewTimetable.TabIndex = 0;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblSubject.Location = new Point(15, 320);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(78, 25);
            lblSubject.TabIndex = 1;
            lblSubject.Text = "Subject";
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSubject.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxSubject.Location = new Point(15, 345);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(270, 29);
            comboBoxSubject.TabIndex = 2;
            // 
            // lblTimeSlot
            // 
            lblTimeSlot.AutoSize = true;
            lblTimeSlot.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimeSlot.Location = new Point(15, 385);
            lblTimeSlot.Name = "lblTimeSlot";
            lblTimeSlot.Size = new Size(95, 25);
            lblTimeSlot.TabIndex = 3;
            lblTimeSlot.Text = "Time Slot";
            // 
            // comboBoxTimeSlot
            // 
            comboBoxTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimeSlot.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxTimeSlot.Location = new Point(15, 410);
            comboBoxTimeSlot.Name = "comboBoxTimeSlot";
            comboBoxTimeSlot.Size = new Size(270, 29);
            comboBoxTimeSlot.TabIndex = 4;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblRoom.Location = new Point(300, 320);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(65, 25);
            lblRoom.TabIndex = 5;
            lblRoom.Text = "Room";
            // 
            // comboBoxRoom
            // 
            comboBoxRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRoom.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxRoom.Location = new Point(300, 345);
            comboBoxRoom.Name = "comboBoxRoom";
            comboBoxRoom.Size = new Size(270, 29);
            comboBoxRoom.TabIndex = 6;
            // 
            // btnAddTimetable
            // 
            btnAddTimetable.BackColor = Color.FromArgb(33, 150, 243);
            btnAddTimetable.FlatStyle = FlatStyle.Flat;
            btnAddTimetable.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddTimetable.ForeColor = Color.White;
            btnAddTimetable.Location = new Point(300, 385);
            btnAddTimetable.Name = "btnAddTimetable";
            btnAddTimetable.Size = new Size(100, 35);
            btnAddTimetable.TabIndex = 7;
            btnAddTimetable.Text = "Add";
            btnAddTimetable.UseVisualStyleBackColor = false;
            // 
            // btnEditTimetable
            // 
            btnEditTimetable.BackColor = Color.FromArgb(33, 150, 243);
            btnEditTimetable.FlatStyle = FlatStyle.Flat;
            btnEditTimetable.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditTimetable.ForeColor = Color.White;
            btnEditTimetable.Location = new Point(410, 385);
            btnEditTimetable.Name = "btnEditTimetable";
            btnEditTimetable.Size = new Size(100, 35);
            btnEditTimetable.TabIndex = 8;
            btnEditTimetable.Text = "Edit";
            btnEditTimetable.UseVisualStyleBackColor = false;
            // 
            // btnDeleteTimetable
            // 
            btnDeleteTimetable.BackColor = Color.FromArgb(232, 17, 35);
            btnDeleteTimetable.FlatStyle = FlatStyle.Flat;
            btnDeleteTimetable.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteTimetable.ForeColor = Color.White;
            btnDeleteTimetable.Location = new Point(520, 385);
            btnDeleteTimetable.Name = "btnDeleteTimetable";
            btnDeleteTimetable.Size = new Size(100, 35);
            btnDeleteTimetable.TabIndex = 9;
            btnDeleteTimetable.Text = "Delete";
            btnDeleteTimetable.UseVisualStyleBackColor = false;
            // 
            // TimetableForm
            // 
            ClientSize = new Size(686, 475);
            Controls.Add(panelContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TimetableForm";
            Text = "Timetable Management";
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTimetable).EndInit();
            ResumeLayout(false);
        }
    }
}
