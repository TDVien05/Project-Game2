using System;
using Test.Model;
using Test.View;

namespace Test.Controller
{
    internal class SubjectHandler
    {
        //ham de xuat mon hoc
        public String subjectList()
        {
            Console.WriteLine("------------Subject List------------");
            Console.WriteLine("Ma : Toan hoc");
            Console.WriteLine("Li : Van hoc");
            Console.WriteLine("Py : Vat ly");
            Console.WriteLine("Ce : Hoa hoc");
            Console.WriteLine("Hi : Lich su");
            Console.WriteLine("Ge : Dia ly");
            Console.WriteLine("En : Ngoai ngu");
            Console.WriteLine("Cs : Tin hoc");
            Console.WriteLine("Bi : Sinh hoc");
            //dk mon hay ko
            Console.WriteLine("Ban co muon dang ky mon hoc?");
            Console.WriteLine("1. Co");
            Console.WriteLine("1. Khong");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Hay nhap ma mon hoc: ");
                    string? id = Console.ReadLine();
                    return id;
                case "2":
                    return "Khong co mon hoc nao duoc chon";
                default:
                    return "Invalid choice";

            }
        }

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
        public void RegisterSubject(string subjectId)
        {
            string subjectName = SubjectHandler.GetSubjectNameById(subjectId);
            if (!string.IsNullOrEmpty(subjectName))
            {
                if (!subjects.ContainsKey(subjectName))
                {
                    subjects.Add(subjectName, subjectId);
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
        }
        // Method to display available subjects
        public static void DisplaySubjectList()
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