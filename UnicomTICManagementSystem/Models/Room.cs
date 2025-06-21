namespace UnicomTICManagementSystem.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string Type { get; set; } // Retained from previous fix for TimetableForm
        public string RoomType { get; set; } // Added to resolve the current error
    }
}