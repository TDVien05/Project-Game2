using System;
using System.Collections.Generic;
using System.IO;
using StudentManagement.Model;

namespace StudentManagement.Controller
{
    internal class SubjectHandler
    {
        // Subject dictionary with subject ID as key and subject name as value
        private static Dictionary<string, string> subjects = new Dictionary<string, string>()
        {
            { "Ma", "Math" },
            { "Li", "Literture" },
            { "Py", "Physics" },
            { "Ce", "Chemistry" },
            { "Hi", "History" },
            { "Ge", "Geography" },
            { "En", "English" },
            { "Cs", "Comouter science" },
            { "Bi", "Biolophy" }
        };

        // Link to the student handler to get the student data
        private StudentHandler studentHandler;
        private Manage manage = new Manage();
        private List<Student> students1 = new List<Student>();   

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
                Console.WriteLine("Do you want to sign up course?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Invalid value.");
                    continue;
                }

                if (choice == 1)
                {
                    students1 = manage.ReadFromFile();
                    Console.WriteLine("Enter roll number: ");
                    string? rollNum = Console.ReadLine();
                    Student? student = studentHandler.SearchStudentByRollNumber(rollNum);
                    if (student == null)
                    {
                        Console.WriteLine("Can not find student with roll number : " + rollNum);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        return;
                    }

                    Console.WriteLine("Enter ID of course : ");
                    string? subjectId = Console.ReadLine();

                    // Validate subject ID
                    if (!subjects.ContainsKey(subjectId))
                    {
                        Console.WriteLine("Course's ID is inivalid");
                        return;
                    }

                    // Check if the subject is already registered for the student
                    if (student.Subject.Contains(subjectId))
                    {
                        Console.WriteLine($"Course {subjects[subjectId]} is signed up");
                        return;
                    }
                    //else
                    //{
                    //    student.Subject.Add(subjectId);
                    //    Console.WriteLine($"{subjects[subjectId]} is signed up sucessfully for {student.Name}.");
                    //    //WriteSubjectToStudent(rollNum);
                    //    manage.WriteToFile(this.students);
                    //}
                    student.Subject.Add(subjectId);
                    Console.WriteLine($"{subjects[subjectId]} is signed up sucessfully for {student.Name}.");
                    //WriteSubjectToStudent(rollNum);
                    manage.WriteToFile(students1);
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
        //private void WriteSubjectToStudent(string rollNum)
        //{
        //    string filePath = @"D:\StudentManagement\Project-Game2\StudentManagement\Controller\Student_Information.txt";
        //    string? roll = studentHandler.getRollNum();
        //    Student? student = studentHandler.SearchStudentByRollNumber(roll);

        //    if (student == null)
        //    {
        //        Console.WriteLine("Can not find student");
        //        return;
        //    }

        //    try
        //    {
        //        //using (StreamWriter writer = new StreamWriter(filePath, append: true))
        //        //{
        //        //    writer.WriteLine($"Roll Number: {student.RollNumber}");
        //        //    writer.WriteLine($"Subjects: {string.Join(", ", student.Subject.Select(id => subjects[id]))}");
        //        //    writer.WriteLine();
        //        //}
        //        manage.WriteToFile(students);
                
        //    }
        //    catch (IOException ex)
        //    {
        //        Console.WriteLine($"Error : {ex.Message}");
        //    }
        //}

        public static void PrintSubjectById()
        {
            Console.WriteLine("Enter course's ID : ");
            string? subjectId = Console.ReadLine();
            string subjectName = SubjectHandler.GetSubjectNameById(subjectId);
            if (!string.IsNullOrEmpty(subjectName))
            {
                Console.WriteLine($"Subject Found: {subjectName}");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine(); 
            }
            else
            {
                Console.WriteLine("No subject found with this ID.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }

    }
}
