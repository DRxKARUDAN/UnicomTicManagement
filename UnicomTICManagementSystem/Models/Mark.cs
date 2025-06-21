using System;

namespace UnicomTICManagementSystem.Models
{
    public class Mark
    {
        public int MarkID { get; set; }
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int Score { get; set; }
        public string StudentName { get; set; } // Display property
        public string ExamName { get; set; }   // Display property
    }
}