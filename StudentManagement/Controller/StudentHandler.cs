using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudentManagement.Model;

namespace StudentManagement.Controller
{
    internal class StudentHandler
    {
        private const string filePath = @"D:\StudentManagement\Project-Game2\StudentManagement\Controller\Student_Information.txt";
        // List to store the students
        private List<Student> students = new List<Student>();
        private Manage manage = new Manage();

        // Constructor to initialize the student repository
        public void StudentList()
        {
            // Read students from file
            //ReadStudentsFromFile();
        }

        // Method to search for a student by roll number
        public string getRollNum()
        {
            Console.WriteLine("Enter roll number");
            string? rollNumber = Console.ReadLine();
            // If rollNumber is not null or empty, return it, otherwise return a default value
            return rollNumber ?? "Error/ Can not find student have rool number" + rollNumber;
        }


        public Student? SearchStudentByRollNumber(string rollNumber)
        {
            students = manage.ReadFromFile();
            return students.FirstOrDefault(student => student.RollNumber.Equals(rollNumber, StringComparison.OrdinalIgnoreCase));
        }



        public void FilterBySubjectId(string subjectId)
        {
            //ReadStudentsFromFile();
            students = manage.ReadFromFile();
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
                    Console.WriteLine($"Subjects: {string.Join("; ", student.Subject)}");
                    Console.WriteLine("-----------------------------------");
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine(); 
            }
            else
            {
                Console.WriteLine($"No students found for subject ID: {subjectId}");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }

        // Method to add a new student to the repository
        // Method to print student list
        public void PrintStudentList()
        {
            //Console.WriteLine("trc khi read");
            //ReadStudentsFromFile();
            //Console.WriteLine("read co hdong");
            //foreach (Student student in students)
            //{
            //    Console.WriteLine($"Name: {student.Name}");
            //    Console.WriteLine($"Roll Number: {student.RollNumber}");
            //    Console.WriteLine($"Age: {student.Age}");
            //    Console.WriteLine($"Sex: {student.Sex}");
            //    Console.WriteLine($"Date of Birth: {student.DateOfBirth}");
            //    Console.WriteLine($"Address: {student.Address}");
            //    Console.WriteLine($"Subjects: {string.Join(", ", student.Subject)}");
            //    Console.WriteLine();
            //}
            students = manage.ReadFromFile();
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
            Console.WriteLine("Enter enter to continue");
            Console.ReadLine();
        }

        // Method to get all students
        //public List<Student> GetAllStudents()
        //{
        //    return students;
        //}

        // Method to write students to file
        //public void ReadStudentsFromFile()
        //{

        //    using (StreamReader reader = new StreamReader(filePath))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            Student student = new Student();

        //            student.Name = reader.ReadLine().Replace("Name: ", "");
        //            student.RollNumber = reader.ReadLine().Replace("Roll Number: ", "");
        //            student.Age = int.Parse(reader.ReadLine().Replace("Age: ", ""));
        //            student.Sex = reader.ReadLine().Replace("Sex: ", "");
        //            student.DateOfBirth = reader.ReadLine().Replace("Date of Birth: ", "");
        //            student.Address = reader.ReadLine().Replace("Address: ", "");
        //            student.Subject = reader.ReadLine().Replace("Subjects: ", "").Split(',').Select(s => s.Trim()).ToList();


        //            reader.ReadLine();

        //            this.students.Add(student);
        //        }
        //        Console.WriteLine(students.Count);
        //    }
        //}
        //public void WriteStudentsToFile(List<Student> students)
        //{
        //    using (StreamWriter writer = new StreamWriter(filePath))
        //    {
        //        File.Create(@"D:\StudentManagement\Project-Game2\StudentManagement\Controller\Student_Information.txt").Close();
        //        foreach (Student student in students)
        //        {
        //            writer.WriteLine($"Name: {student.Name}");
        // Method to read students from file
        //public void ReadStudentsFromFile()
        //{
        //    if (File.Exists(filePath))
        //    {
        //        string[] lines = File.ReadAllLines(filePath);
        //        //for (int i = 0; i < lines.Length; i += 7)
        //        //{
        //        //    string name = lines[i].Split(':')[1].Trim();
        //        //    string rollNumber = lines[i + 1].Split(':')[1].Trim();
        //        //    int age = int.Parse(lines[i + 2].Split(':')[1].Trim());
        //        //    string sex = lines[i + 3].Split(':')[1].Trim();
        //        //    string dateOfBirth = lines[i + 4].Split(':')[1].Trim();
        //        //    string address = lines[i + 5].Split(':')[1].Trim();
        //        //    List<string> subjects = lines[i + 6].Split(':').Skip(1).Select(s => s.Trim()).ToList();

        //        //    Student student = new Student(name, rollNumber, age, sex, dateOfBirth, address, subjects);
        //        //    students.Add(student);
        //        //}
        //        for (int i = 0; i < lines.Length; i++)
        //        {
        //            string name = lines[i].Split(':')[1].Trim();
        //            string rollNumber = lines[i + 1].Split(':')[1].Trim();
        //            int age = int.Parse(lines[i + 2].Split(':')[1].Trim());
        //            string sex = lines[i + 3].Split(':')[1].Trim();
        //            string dateOfBirth = lines[i + 4].Split(':')[1].Trim();
        //            string address = lines[i + 5].Split(':')[1].Trim();
        //            List<string> subjects = lines[i + 6].Split(':').Skip(1).Select(s => s.Trim()).ToList();
        //            i++;
        //            Student student = new Student(name, rollNumber, age, sex, dateOfBirth, address, subjects);
        //            students.Add(student);
        //            if(i > lines.Length)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}

        //            writer.WriteLine($"Roll Number: {student.RollNumber}");
        //            writer.WriteLine($"Age: {student.Age}");
        //            writer.WriteLine($"Sex: {student.Sex}");
        //            writer.WriteLine($"Date of Birth: {student.DateOfBirth}");
        //            writer.WriteLine($"Address: {student.Address}");
        //            writer.WriteLine($"Subjects: {string.Join(", ", student.Subject)}");
        //            writer.WriteLine();
        //        }
        //    }
        //}
    }
}