using System;

namespace UnicomTICManagementSystem.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } // "Present", "Absent", "Late", "Excused"
        public string StudentName { get; set; } // Added for display
        public string SubjectName { get; set; } // Added for display
    }
}