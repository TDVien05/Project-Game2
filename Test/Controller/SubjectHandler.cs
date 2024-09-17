using System;
using System.Collections.Generic;
using System.IO;
using Test.Model;

namespace Test.Controller
{
    internal class SubjectHandler
    {
        // Subject dictionary with subject ID as key and subject name as value
        private static Dictionary<string, string> subjects = new Dictionary<string, string>()
        {
            { "Ma", "Toan hoc" },
            { "Li", "Van hoc" },
            { "Py", "Vat ly" },
            { "Ce", "Hoa hoc" },
            { "Hi", "Lich su" },
            { "Ge", "Dia ly" },
            { "En", "Ngoai ngu" },
            { "Cs", "Tin hoc" },
            { "Bi", "Sinh hoc" }
        };

        // Link to the student handler to get the student data
        private StudentHandler studentHandler;

        // Constructor to initialize student handler
        public SubjectHandler(StudentHandler studentHandler)
        {
            this.studentHandler = studentHandler;
        }

        // Register subjects for a student
        public void RegisterSubject()
        {
            int choice;
            do
            {
                Console.WriteLine("Ban co muon dang ky mon hoc?");
                Console.WriteLine("1. Co");
                Console.WriteLine("2. Khong");

                if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Lua chon khong hop le. Hay chon lai.");
                    continue;
                }

                if (choice == 1)
                {
                    Console.WriteLine("Hay nhap MSSV: ");
                    string? rollNum = Console.ReadLine();
                    Student? student = studentHandler.SearchStudentByRollNumber(rollNum);

                    if (student == null)
                    {
                        Console.WriteLine("Khong tim thay sinh vien voi MSSV da nhap.");
                        return;
                    }

                    Console.WriteLine("Hay nhap ma mon hoc: ");
                    string? subjectId = Console.ReadLine();

                    // Validate subject ID
                    if (!subjects.ContainsKey(subjectId))
                    {
                        Console.WriteLine("Ma mon hoc khong hop le.");
                        return;
                    }

                    // Check if the subject is already registered for the student
                    if (student.Subject.Contains(subjectId))
                    {
                        Console.WriteLine($"Mon hoc {subjects[subjectId]} da duoc dang ky.");
                    }
                    else
                    {
                        student.Subject.Add(subjectId);
                        Console.WriteLine($"{subjects[subjectId]} da duoc dang ky thanh cong cho sinh vien {student.Name}.");
                        WriteSubjectToStudent(rollNum);
                    }
                }
            } while (choice != 2);
        }

        // Method to display available subjects
        public void DisplaySubjectList()
        {
            Console.WriteLine("------------Subject List------------");
            foreach (var subject in subjects)
            {
                Console.WriteLine($"{subject.Key} : {subject.Value}");
            }
        }

        // Get subject name by subject ID
        public static string GetSubjectNameById(string subjectId)
        {
            return subjects.ContainsKey(subjectId) ? subjects[subjectId] : string.Empty;
        }

        // Write subject list of a student to the file
        private void WriteSubjectToStudent(string rollNum)
        {
            string filePath = @"D:\Final_project\Test\Test\Controller\Student_Information.txt";
            studentHandler.getRollNum();
            Student? student = studentHandler.SearchStudentByRollNumber(rollNum);

            if (student == null)
            {
                Console.WriteLine("Khong tim thay sinh vien.");
                return;
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine($"Roll Number: {student.RollNumber}");
                    writer.WriteLine($"Subjects: {string.Join(", ", student.Subject.Select(id => subjects[id]))}");
                    writer.WriteLine();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Co loi xay ra khi ghi vao file: {ex.Message}");
            }
        }

        public static void PrintSubjectById()
        {
            Console.WriteLine("Nhap id mon hoc de tim kiem: ");
            string? subjectId = Console.ReadLine();
            string subjectName = SubjectHandler.GetSubjectNameById(subjectId);
            if (!string.IsNullOrEmpty(subjectName))
            {
                Console.WriteLine($"Subject Found: {subjectName}");
            }
            else
            {
                Console.WriteLine("No subject found with this ID.");
            }
        }

    }
}
