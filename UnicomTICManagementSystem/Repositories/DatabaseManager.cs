using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Repositories
{
    public class DatabaseManager
    {
        public string _connectionString = "Data Source=unicomtic.db;Version=3;";

        public DatabaseManager()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            int retryCount = 3;
            while (retryCount > 0)
            {
                try
                {
                    using (var connection = new SQLiteConnection(_connectionString))
                    {
                        connection.Open();

                        // Users table - Users(UserID INTEGER PRIMARY KEY, Username TEXT, Password TEXT, Role TEXT) 
                        var command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Users (
                                UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Username TEXT NOT NULL,
                                Password TEXT NOT NULL,
                                Role TEXT NOT NULL
                            )", connection);
                        command.ExecuteNonQuery();

                        // Rooms table - Rooms(RoomID INTEGER PRIMARY KEY, RoomName TEXT,RoomType TEXT)
                        command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Rooms (
                                RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                                RoomName TEXT NOT NULL,
                                RoomType TEXT NOT NULL
                            )", connection);
                        command.ExecuteNonQuery();

                        // Courses table - Courses(CourseID INTEGER PRIMARY KEY, CourseName TEXT) 
                        command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Courses (
                                CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                                CourseName TEXT NOT NULL
                            )", connection);
                        command.ExecuteNonQuery();

                        // Subjects table - Subjects(SubjectID INTEGER PRIMARY KEY, SubjectName TEXT, CourseID INTEGER,FOREIGN KEY(CourseID) REFERENCES Courses) 
                        command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Subjects (
                                SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                                SubjectName TEXT NOT NULL,
                                CourseID INTEGER,
                                FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                            )", connection);
                        command.ExecuteNonQuery();

                        // Students table - Students(StudentID INTEGER PRIMARY KEY, Name TEXT, CourseID INTEGER, FOREIGNKEY(CourseID) REFERENCES Courses) 
                        command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Students (
                                StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL,
                                CourseID INTEGER,
                                FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                            )", connection);
                        command.ExecuteNonQuery();

                        // Exams table - Exams(ExamID INTEGER PRIMARY KEY, ExamName TEXT, SubjectID INTEGER, FOREIGNKEY(SubjectID) REFERENCES Subjects) 
                        command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Exams (
                                ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                                ExamName TEXT NOT NULL,
                                SubjectID INTEGER,
                                FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
                            )", connection);
                        command.ExecuteNonQuery();

                        // Marks table - Marks(MarkID INTEGER PRIMARY KEY, StudentID INTEGER, ExamID INTEGER, Score INTEGER, FOREIGN KEY(StudentID) REFERENCES Students, FOREIGN KEY(ExamID)
                        command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Marks (
                                MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                                StudentID INTEGER,
                                ExamID INTEGER,
                                Score INTEGER,
                                FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
                                FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
                            )", connection);
                        command.ExecuteNonQuery();

                        /* Timetables table - Timetables(TimetableID INTEGER PRIMARY KEY, SubjectID INTEGER, TimeSlot TEXT,
                        RoomID INTEGER, FOREIGN KEY(SubjectID) REFERENCES Subjects, FOREIGN
                        KEY(RoomID) REFERENCES Rooms) */
                        command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Timetables (
                                TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                                SubjectID INTEGER,
                                TimeSlot TEXT NOT NULL,
                                RoomID INTEGER,
                                FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
                                FOREIGN KEY(RoomID) REFERENCES Rooms(RoomID)
                            )", connection);
                        command.ExecuteNonQuery();

                        // Attendance table
                        command = new SQLiteCommand(
                            @"CREATE TABLE IF NOT EXISTS Attendance (
                                AttendanceID INTEGER PRIMARY KEY AUTOINCREMENT,
                                StudentID INTEGER NOT NULL,
                                SubjectID INTEGER NOT NULL,
                                Date TEXT NOT NULL,
                                Status TEXT NOT NULL,
                                FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
                                FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
                                UNIQUE(StudentID, SubjectID, Date)
                            )", connection);
                        command.ExecuteNonQuery();

                        // Insert sample rooms
                        command = new SQLiteCommand(
                            @"INSERT OR IGNORE INTO Rooms (RoomID, RoomName, RoomType) VALUES 
                            (1, 'Lab 1', 'Lab'),
                            (2, 'Lab 2', 'Lab'),
                            (3, 'Hall A', 'Hall'),
                            (4, 'Hall B', 'Hall')", connection);
                        command.ExecuteNonQuery();

                        // Insert sample subjects
                        command = new SQLiteCommand(
                            @"INSERT OR IGNORE INTO Subjects (SubjectID, SubjectName, CourseID) VALUES 
                            (1, 'Sql injection', 1),
                            (2, 'Programming', 1)", connection);
                        command.ExecuteNonQuery();

                        // Insert sample timetables
                        command = new SQLiteCommand(
                            @"INSERT OR IGNORE INTO Timetables (TimetableID, SubjectID, TimeSlot, RoomID) VALUES 
                            (1, 1, 'Tuesday 10 AM', 4),
                            (2, 2, 'Tuesday 2 PM', 2)", connection);
                        command.ExecuteNonQuery();

                        // Insert sample users (including Lecturer)
                        command = new SQLiteCommand(
                            @"INSERT OR IGNORE INTO Users (UserID, Username, Password, Role) VALUES 
                            (1, 'admin1', 'pass123', 'Admin'),
                            (2, 'staff1', 'pass123', 'Staff'),
                            (3, 'student1', 'pass123', 'Student'),
                            (4, 'lecturer1', 'pass123', 'Lecturer')", connection);
                        command.ExecuteNonQuery();

                        return; // Exit if successful
                    }
                }
                catch (SQLiteException ex) when (ex.Message.Contains("database is locked"))
                {
                    retryCount--;
                    if (retryCount > 0)
                    {
                        System.Threading.Thread.Sleep(1000); // Wait 1 second before retrying
                        continue;
                    }
                    MessageBox.Show($"Database initialization failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogToFile($"Database initialization failed: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database initialization failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogToFile($"Database initialization failed: {ex.Message}");
                }
            }
        }

        private void LogToFile(string message)
        {
            string logFilePath = "error.log";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp}: {message}\n";
            System.IO.File.AppendAllText(logFilePath, logEntry);
        }

        // Login logic - checking username with password
        public async Task<string> ValidateUserAsync(string username, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "SELECT Role FROM Users WHERE Username = @username AND Password = @password", connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    var role = await command.ExecuteScalarAsync();
                    return role?.ToString() ?? null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Login error for user {username}: {ex.Message}");
                return null;
            }
        }

        // Login logic - Returning respective role for a specific user
        public async Task<string> GetUserRoleAsync(string username)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "SELECT Role FROM Users WHERE Username = @username", connection);
                    command.Parameters.AddWithValue("@username", username);
                    var role = await command.ExecuteScalarAsync();
                    return role?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching role for user {username}: {ex.Message}");
                return "";
            }
        }

        //Adding User - Pushing a new user to database
        public async Task<bool> AddUserAsync(string username, string password, string role)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)", connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@role", role);
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (SQLiteException ex) when (ex.ErrorCode == 19) // SQLite CONSTRAINT error (e.g., UNIQUE constraint)
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Registration failed for {username}: Username already exists");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Registration error for {username}: {ex.Message}");
                return false;
            }
        }

        //Adding Cource - pushing a new course in to the database
        public async Task AddCourseAsync(Course course)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "INSERT INTO Courses (CourseName) VALUES (@CourseName)", connection);
                    command.Parameters.AddWithValue("@CourseName", course.CourseName);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error adding course: {ex.Message}");
            }
        }

        //Returing all courses from database
        public async Task<List<Course>> GetCoursesAsync()
        {
            var courses = new List<Course>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand("SELECT CourseID, CourseName FROM Courses", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            courses.Add(new Course
                            {
                                CourseID = reader.GetInt32(0),
                                CourseName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching courses: {ex.Message}");
            }
            return courses;
        }

        //Upating an existing course with new values from database
        public async Task UpdateCourseAsync(Course course)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "UPDATE Courses SET CourseName = @CourseName WHERE CourseID = @CourseID", connection);
                    command.Parameters.AddWithValue("@CourseName", course.CourseName);
                    command.Parameters.AddWithValue("@CourseID", course.CourseID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error updating course: {ex.Message}");
            }
        }

        //Deleting an existing Course from database
        public async Task DeleteCourseAsync(int courseID)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "DELETE FROM Courses WHERE CourseID = @CourseID", connection);
                    command.Parameters.AddWithValue("@CourseID", courseID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error deleting course: {ex.Message}");
            }
        }

        //Add a new subject to the database
        public async Task AddSubjectAsync(Subject subject)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@SubjectName, @CourseID)", connection);
                    command.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    command.Parameters.AddWithValue("@CourseID", subject.CourseID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding subject: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error adding subject: {ex.Message}");
            }
        }

        //Return all the subjects from the database
        public async Task<List<Subject>> GetSubjectsAsync()
        {
            var subjects = new List<Subject>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand("SELECT SubjectID, SubjectName, CourseID FROM Subjects", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = reader.GetInt32(0),
                                SubjectName = reader.GetString(1),
                                CourseID = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching subjects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching subjects: {ex.Message}");
            }
            return subjects;
        }

        //Update an existing subject with new values to the database
        public async Task UpdateSubjectAsync(Subject subject)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "UPDATE Subjects SET SubjectName = @SubjectName, CourseID = @CourseID WHERE SubjectID = @SubjectID", connection);
                    command.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    command.Parameters.AddWithValue("@CourseID", subject.CourseID);
                    command.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating subject: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error updating subject: {ex.Message}");
            }
        }

        //Delete a subject from database
        public async Task DeleteSubjectAsync(int subjectID)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "DELETE FROM Subjects WHERE SubjectID = @SubjectID", connection);
                    command.Parameters.AddWithValue("@SubjectID", subjectID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting subject: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error deleting subject: {ex.Message}");
            }
        }

        //Adding a new student to the database
        public async Task AddStudentAsync(Student student)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "INSERT INTO Students (Name, CourseID) VALUES (@Name, @CourseID)", connection);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@CourseID", student.CourseID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error adding student: {ex.Message}");
            }
        }

        //Return all the students from the database
        public async Task<List<Student>> GetStudentsAsync(int studentId = -1)
        {
            var students = new List<Student>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        studentId > 0 ? "SELECT StudentID, Name, CourseID FROM Students WHERE StudentID = @StudentID" :
                                        "SELECT StudentID, Name, CourseID FROM Students", connection);
                    if (studentId > 0) command.Parameters.AddWithValue("@StudentID", studentId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            students.Add(new Student
                            {
                                StudentID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CourseID = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching students: {ex.Message}");
            }
            return students;
        }

        //Return the students details by using the username
        public async Task<Student> GetStudentByUsernameAsync(string username)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        @"SELECT s.StudentID, s.Name, s.CourseID 
                          FROM Students s 
                          JOIN Users u ON s.StudentID = u.UserID 
                          WHERE u.Username = @username", connection);
                    command.Parameters.AddWithValue("@username", username);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Student
                            {
                                StudentID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CourseID = reader.GetInt32(2)
                            };
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching student details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching student details for {username}: {ex.Message}");
                return null;
            }
        }

        //Update an existing student with new values from database
        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "UPDATE Students SET Name = @Name, CourseID = @CourseID WHERE StudentID = @StudentID", connection);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@CourseID", student.CourseID);
                    command.Parameters.AddWithValue("@StudentID", student.StudentID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error updating student: {ex.Message}");
            }
        }

        //Delete an existing student from the daatabase
        public async Task DeleteStudentAsync(int studentID)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "DELETE FROM Students WHERE StudentID = @StudentID", connection);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error deleting student: {ex.Message}");
            }
        }

        //Add an new exam to the database
        public async Task AddExamAsync(Exam exam)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "INSERT INTO Exams (ExamName, SubjectID) VALUES (@ExamName, @SubjectID)", connection);
                    command.Parameters.AddWithValue("@ExamName", exam.ExamName);
                    command.Parameters.AddWithValue("@SubjectID", exam.SubjectID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error adding exam: {ex.Message}");
            }
        }

        //Return all the Exams from the database
        public async Task<List<Exam>> GetExamsAsync()
        {
            var exams = new List<Exam>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand("SELECT ExamID, ExamName, SubjectID FROM Exams", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            exams.Add(new Exam
                            {
                                ExamID = reader.GetInt32(0),
                                ExamName = reader.GetString(1),
                                SubjectID = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching exams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching exams: {ex.Message}");
            }
            return exams;
        }

        //Update an existing exam with new values from database
        public async Task UpdateExamAsync(Exam exam)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "UPDATE Exams SET ExamName = @ExamName, SubjectID = @SubjectID WHERE ExamID = @ExamID", connection);
                    command.Parameters.AddWithValue("@ExamName", exam.ExamName);
                    command.Parameters.AddWithValue("@SubjectID", exam.SubjectID);
                    command.Parameters.AddWithValue("@ExamID", exam.ExamID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error updating exam: {ex.Message}");
            }
        }

        //Delete an exam from the databaase
        public async Task DeleteExamAsync(int examID)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "DELETE FROM Exams WHERE ExamID = @ExamID", connection);
                    command.Parameters.AddWithValue("@ExamID", examID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error deleting exam: {ex.Message}");
            }
        }

        //Add a new mark to the database
        public async Task AddMarkAsync(Mark mark)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "INSERT INTO Marks (StudentID, ExamID, Score) VALUES (@StudentID, @ExamID, @Score)", connection);
                    command.Parameters.AddWithValue("@StudentID", mark.StudentID);
                    command.Parameters.AddWithValue("@ExamID", mark.ExamID);
                    command.Parameters.AddWithValue("@Score", mark.Score);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding mark: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error adding mark: {ex.Message}");
            }
        }

        //Return all the marks and details from the databasee
        public async Task<List<Mark>> GetMarksAsync()
        {
            var marks = new List<Mark>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand("SELECT MarkID, StudentID, ExamID, Score FROM Marks", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            marks.Add(new Mark
                            {
                                MarkID = reader.GetInt32(0),
                                StudentID = reader.GetInt32(1),
                                ExamID = reader.GetInt32(2),
                                Score = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching marks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching marks: {ex.Message}");
            }
            return marks;
        }

        //Return the marks of a specific student from the database
        public async Task<List<Mark>> GetMarksByStudentIdAsync(int studentId)
        {
            var marks = new List<Mark>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "SELECT MarkID, StudentID, ExamID, Score FROM Marks WHERE StudentID = @StudentID", connection);
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            marks.Add(new Mark
                            {
                                MarkID = reader.GetInt32(0),
                                StudentID = reader.GetInt32(1),
                                ExamID = reader.GetInt32(2),
                                Score = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching marks for student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching marks for student {studentId}: {ex.Message}");
            }
            return marks;
        }

        //Update an existing marks with new values from the database
        public async Task UpdateMarkAsync(Mark mark)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "UPDATE Marks SET StudentID = @StudentID, ExamID = @ExamID, Score = @Score WHERE MarkID = @MarkID", connection);
                    command.Parameters.AddWithValue("@StudentID", mark.StudentID);
                    command.Parameters.AddWithValue("@ExamID", mark.ExamID);
                    command.Parameters.AddWithValue("@Score", mark.Score);
                    command.Parameters.AddWithValue("@MarkID", mark.MarkID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating mark: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error updating mark: {ex.Message}");
            }
        }

        //Delete an existing mark from database
        public async Task DeleteMarkAsync(int markID)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "DELETE FROM Marks WHERE MarkID = @MarkID", connection);
                    command.Parameters.AddWithValue("@MarkID", markID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting mark: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error deleting mark: {ex.Message}");
            }
        }

        //Return all the timtables from the database
        public async Task<List<Timetable>> GetTimetablesAsync()
        {
            var timetables = new List<Timetable>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand("SELECT TimetableID, SubjectID, TimeSlot, RoomID FROM Timetables", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            timetables.Add(new Timetable
                            {
                                TimetableID = reader.GetInt32(0),
                                SubjectID = reader.GetInt32(1),
                                TimeSlot = reader.GetString(2),
                                RoomID = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching timetables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching timetables: {ex.Message}");
            }
            return timetables;
        }

        //Add an new time table to the database
        public async Task AddTimetableAsync(Timetable timetable)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "INSERT INTO Timetables (SubjectID, TimeSlot, RoomID) VALUES (@SubjectID, @TimeSlot, @RoomID)", connection);
                    command.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                    command.Parameters.AddWithValue("@TimeSlot", timetable.TimeSlot);
                    command.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding timetable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error adding timetable: {ex.Message}");
            }
        }

        //Update a existing timtable with new values from the database
        public async Task UpdateTimetableAsync(Timetable timetable)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "UPDATE Timetables SET SubjectID = @SubjectID, TimeSlot = @TimeSlot, RoomID = @RoomID WHERE TimetableID = @TimetableID", connection);
                    command.Parameters.AddWithValue("@TimetableID", timetable.TimetableID);
                    command.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                    command.Parameters.AddWithValue("@TimeSlot", timetable.TimeSlot);
                    command.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating timetable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error updating timetable: {ex.Message}");
            }
        }

        //Delete an existing timetabl from the database
        public async Task DeleteTimetableAsync(int timetableId)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand("DELETE FROM Timetables WHERE TimetableID = @TimetableID", connection);
                    command.Parameters.AddWithValue("@TimetableID", timetableId);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting timetable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error deleting timetable: {ex.Message}");
            }
        }

        //Return all the Rooms from the database
        public async Task<List<Room>> GetRoomsAsync()
        {
            var rooms = new List<Room>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand("SELECT RoomID, RoomName, RoomType FROM Rooms", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string roomType = reader.IsDBNull(2) ? "Unknown" : reader.GetString(2); // Handle null RoomType
                            rooms.Add(new Room
                            {
                                RoomID = reader.GetInt32(0),
                                RoomName = reader.GetString(1),
                                RoomType = roomType
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching rooms: {ex.Message}");
            }
            return rooms;
        }

        //Return all the attendences from the database
        public async Task<List<Attendance>> GetAttendanceAsync()
        {
            var attendances = new List<Attendance>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand("SELECT AttendanceID, StudentID, SubjectID, Date, Status FROM Attendance", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            attendances.Add(new Attendance
                            {
                                AttendanceID = reader.GetInt32(0),
                                StudentID = reader.GetInt32(1),
                                SubjectID = reader.GetInt32(2),
                                Date = DateTime.Parse(reader.GetString(3)),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching attendance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching attendance: {ex.Message}");
            }
            return attendances;
        }

        //Add a new attendace to the database
        public async Task AddAttendanceAsync(Attendance attendance)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "INSERT INTO Attendance (StudentID, SubjectID, Date, Status) VALUES (@StudentID, @SubjectID, @Date, @Status)", connection);
                    command.Parameters.AddWithValue("@StudentID", attendance.StudentID);
                    command.Parameters.AddWithValue("@SubjectID", attendance.SubjectID);
                    command.Parameters.AddWithValue("@Date", attendance.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Status", attendance.Status);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding attendance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error adding attendance: {ex.Message}");
            }
        }

        //Update an existing attendence with new values from the database
        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "UPDATE Attendance SET StudentID = @StudentID, SubjectID = @SubjectID, Date = @Date, Status = @Status WHERE AttendanceID = @AttendanceID", connection);
                    command.Parameters.AddWithValue("@AttendanceID", attendance.AttendanceID);
                    command.Parameters.AddWithValue("@StudentID", attendance.StudentID);
                    command.Parameters.AddWithValue("@SubjectID", attendance.SubjectID);
                    command.Parameters.AddWithValue("@Date", attendance.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Status", attendance.Status);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attendance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error updating attendance: {ex.Message}");
            }
        }

        //Delete an existing attendance from the database
        public async Task DeleteAttendanceAsync(int attendanceId)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "DELETE FROM Attendance WHERE AttendanceID = @AttendanceID", connection);
                    command.Parameters.AddWithValue("@AttendanceID", attendanceId);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting attendance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error deleting attendance: {ex.Message}");
            }
        }

        // Return a specific student from database using username                             
        public async Task<int> GetStudentIdByUsernameAsync(string username)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        @"SELECT s.StudentID 
                  FROM Students s 
                  JOIN Users u ON s.StudentID = u.UserID 
                  WHERE u.Username = @username", connection);
                    command.Parameters.AddWithValue("@username", username);
                    var result = await command.ExecuteScalarAsync();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching student ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching student ID for {username}: {ex.Message}");
                return -1;
            }
        }

        //Return all users with a specific role from the database
        public async Task<List<string>> GetUsersByRoleAsync(string role)
        {
            var users = new List<string>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SQLiteCommand(
                        "SELECT Username FROM Users WHERE Role = @role", connection);
                    command.Parameters.AddWithValue("@role", role);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            users.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching users by role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error fetching users by role {role}: {ex.Message}");
            }
            return users;
        }

        //Assign a course to a student in the database
        public async Task AssignCourseToStudentAsync(string username, int courseId)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    // First, get the UserID
                    var getUserIdCommand = new SQLiteCommand(
                        "SELECT UserID FROM Users WHERE Username = @username", connection);
                    getUserIdCommand.Parameters.AddWithValue("@username", username);
                    var userIdObj = await getUserIdCommand.ExecuteScalarAsync();
                    if (userIdObj == null) throw new Exception("User not found");

                    int userId = Convert.ToInt32(userIdObj);

                    // Check if student already exists in Students table
                    var checkStudentCommand = new SQLiteCommand(
                        "SELECT StudentID FROM Students WHERE StudentID = @userId", connection);
                    checkStudentCommand.Parameters.AddWithValue("@userId", userId);
                    var studentIdObj = await checkStudentCommand.ExecuteScalarAsync();

                    if (studentIdObj == null)
                    {
                        // Add new student with the course
                        var addStudentCommand = new SQLiteCommand(
                            "INSERT INTO Students (StudentID, Name, CourseID) VALUES (@userId, (SELECT Username FROM Users WHERE UserID = @userId), @courseId)", connection);
                        addStudentCommand.Parameters.AddWithValue("@userId", userId);
                        addStudentCommand.Parameters.AddWithValue("@courseId", courseId);
                        await addStudentCommand.ExecuteNonQueryAsync();
                    }
                    else
                    {
                        // Update existing student's course
                        var updateStudentCommand = new SQLiteCommand(
                            "UPDATE Students SET CourseID = @courseId WHERE StudentID = @userId", connection);
                        updateStudentCommand.Parameters.AddWithValue("@courseId", courseId);
                        updateStudentCommand.Parameters.AddWithValue("@userId", userId);
                        await updateStudentCommand.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning course to student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error assigning course to student {username}: {ex.Message}");
            }
        }

        public async Task<bool> UpdateUserPasswordAsync(string username, string newPassword)
        {
            try
            {
                using (var connection = new System.Data.SQLite.SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new System.Data.SQLite.SQLiteCommand(
                        "UPDATE Users SET Password = @Password WHERE Username = @Username", connection);
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Error updating password for {username}: {ex.Message}");
                return false;
            }
        }
    }
}