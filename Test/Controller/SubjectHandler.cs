using System;
using Test.Model;
using Test.View;

namespace Test.Controller
{
    internal class SubjectHandler
    {
        //danh sach mon hoc
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

        // dang ky on hoc
        public void RegisterSubject()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Ban co muon dang ky mon hoc?");
                Console.WriteLine("1. Co");
                Console.WriteLine("2. Khong");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Hay nhap ma mon hoc: ");
                        string? id = Console.ReadLine();
                        string subjectName = SubjectHandler.GetSubjectNameById(id);
                        if (!string.IsNullOrEmpty(subjectName))
                        {
                            if (!subjects.ContainsKey(subjectName))
                            {
                                subjects.Add(subjectName, id);
                                Console.WriteLine($"{subjectName} da dang ky thanh cong.");
                            }
                            else
                            {
                                Console.WriteLine($"{subjectName} da duoc dang ky, khong the dang ky lai.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Subject ID.");
                        }
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Co loi xay ra với hanh dong duoc chon, hay nhap lai");
                        break;
                }
            } while (choice < 1 || choice > 2);
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

        // Method to get subject name by ID
        public static string GetSubjectNameById(string subjectId)
        {
            if (subjects.ContainsKey(subjectId))
            {
                return subjects[subjectId];
            }
            return string.Empty;
        }
    }
}