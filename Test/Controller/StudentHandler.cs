using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Model
{
    internal class StudentHandler
    {
        // List to store the students
        private List<Student> students = new List<Student>();

        // Constructor to initialize the student repository
        public void StudentList()
        {
            // Seed some students for demo purposes
            students.Add(new Student("John Doe", "R123", 20, "Male", "01/01/2003", "123 Main St", new List<string> { "Math", "Science" }));
            students.Add(new Student("Jane Smith", "R456", 21, "Female", "02/01/2002", "456 Oak St", new List<string> { "English", "History" }));
            students.Add(new Student("Mike Johnson", "R789", 19, "Male", "03/01/2004", "789 Pine St", new List<string> { "Physics", "Chemistry" }));
        }

        // Method to search for a student by roll number
        public Student? SearchStudentByRollNumber(string rollNumber)
        {
            return students.FirstOrDefault(student => student.RollNumber == rollNumber);
        }

        // Method to add a new student to the repository
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        // Method to get all students
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
