using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudentManagement.Model;

namespace StudentManagement.Controller
{
    internal class StudentHandler
    {
        private const string filePath = @"D:\Final_project\Test\Test\Controller\Student_Information.txt";
        // List to store the students
        private List<Student> students = new List<Student>();

        // Constructor to initialize the student repository
        public void StudentList()
        {
            // Read students from file
            ReadStudentsFromFile();
        }

        // Method to read students from file
        private void ReadStudentsFromFile()
        {

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 7)
                {
                    string name = lines[i].Split(':')[1].Trim();
                    string rollNumber = lines[i + 1].Split(':')[1].Trim();
                    int age = int.Parse(lines[i + 2].Split(':')[1].Trim());
                    string sex = lines[i + 3].Split(':')[1].Trim();
                    string dateOfBirth = lines[i + 4].Split(':')[1].Trim();
                    string address = lines[i + 5].Split(':')[1].Trim();
                    List<string> subjects = lines[i + 6].Split(':').Skip(1).Select(s => s.Trim()).ToList();

                    Student student = new Student(name, rollNumber, age, sex, dateOfBirth, address, subjects);
                    students.Add(student);
                }
            }
        }

        // Method to search for a student by roll number
        public string getRollNum()
        {
            Console.WriteLine("Hay Nhap MSSV");
            string? rollNumber = Console.ReadLine();
            // If rollNumber is not null or empty, return it, otherwise return a default value
            return rollNumber ?? "Khong co MSSV dc nhap vao hoac ERROR";
        }


        public Student? SearchStudentByRollNumber(string rollNumber)
        {
            return students.FirstOrDefault(student => student.RollNumber.Equals(rollNumber, StringComparison.OrdinalIgnoreCase));
        }


        // Method to add a new student to the repository
        public void AddStudent(Student student)
        {
            students.Add(student);
            WriteStudentsToFile();
        }

        // Method to get all students
        public List<Student> GetAllStudents()
        {
            return students;
        }

        // Method to write students to file
        private void WriteStudentsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Student student in students)
                {
                    writer.WriteLine($"Name: {student.Name}");
                    writer.WriteLine($"Roll Number: {student.RollNumber}");
                    writer.WriteLine($"Age: {student.Age}");
                    writer.WriteLine($"Sex: {student.Sex}");
                    writer.WriteLine($"Date of Birth: {student.DateOfBirth}");
                    writer.WriteLine($"Address: {student.Address}");
                    writer.WriteLine($"Subjects: {string.Join(", ", student.Subject)}");
                    writer.WriteLine();
                }
            }
        }

        // Method to print student list
        public void PrintStudentList()
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Roll Number: {student.RollNumber}");
                Console.WriteLine($"Age: {student.Age}");
                Console.WriteLine($"Sex: {student.Sex}");
                Console.WriteLine($"Date of Birth: {student.DateOfBirth}");
                Console.WriteLine($"Address: {student.Address}");
                Console.WriteLine($"Subjects: {string.Join(", ", student.Subject)}");
                Console.WriteLine();
            }
        }
        public void FilterBySubjectId(string subjectId)
        {
            ReadStudentsFromFile();
            List<Student> filteredStudents = students.Where(student => student.Subject.Contains(subjectId)).ToList();
            if (filteredStudents.Count > 0)
            {
                Console.WriteLine($"Students enrolled in subject {subjectId}:");
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine($"Name: {student.Name}");
                    Console.WriteLine($"Roll Number: {student.RollNumber}");
                    Console.WriteLine($"Age: {student.Age}");
                    Console.WriteLine($"Sex: {student.Sex}");
                    Console.WriteLine($"Date of Birth: {student.DateOfBirth}");
                    Console.WriteLine($"Address: {student.Address}");
                    Console.WriteLine($"Subjects: {string.Join(", ", student.Subject)}");
                    Console.WriteLine("-----------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"No students found for subject ID: {subjectId}");
            }
        }

    }
}