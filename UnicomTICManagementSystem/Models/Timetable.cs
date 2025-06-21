using System;

namespace UnicomTICManagementSystem.Models
{
    public class Timetable
    {
        public int TimetableID { get; set; }
        public int SubjectID { get; set; }
        public string TimeSlot { get; set; }
        public int RoomID { get; set; }
        public string SubjectName { get; set; } // Display property
        public string RoomName { get; set; }   // Display property
    }
}