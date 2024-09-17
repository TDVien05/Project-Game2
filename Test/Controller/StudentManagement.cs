using System;
using System.Collections.Generic;
using Test.Model;

namespace Test.Controller
{
    public class StudentManagement
    {
        private List<Student> students = new List<Student>(); 

        public StudentManagement() { }

        // Chức năng thêm sinh viên
        public void Add()
        {
            Student student = new Student();

            Console.Write("Enter the student name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter the roll number: ");
            student.RollNumber = Console.ReadLine();

            Console.Write("Enter the age: ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter the sex: ");
            student.Sex = Console.ReadLine();

            Console.Write("Enter the date of birth: ");
            student.DateOfBirth = Console.ReadLine();

            Console.Write("Enter the address: ");
            student.Address = Console.ReadLine();

            Console.Write("Enter subjects (comma separated): ");
            string subjectsInput = Console.ReadLine();
            student.Subject = new List<string>(subjectsInput.Split(','));

            students.Add(student);
            Console.WriteLine("Student added successfully!");
        }

        // Chức năng sửa thông tin sinh viên
        
    public void Update(string rollNumber)
        {
            Student student = students.Find(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                Console.Write("Enter the new name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (name != null && name.Length >0)
                {
                    student.Name = name;
                }

                Console.Write("Enter the new age (leave blank to keep current): ");
                string ageInput = Console.ReadLine();
                if (ageInput != null && ageInput.Length > 0)
                {
                    student.Age = int.Parse(ageInput);
                }

                Console.Write("Enter the new sex (leave blank to keep current): ");
                string sex = Console.ReadLine();
                if (sex != null && sex.Length > 0)
                {
                    student.Sex = sex;
                }

                Console.Write("Enter the new date of birth (leave blank to keep current): ");
                string dateOfBirth = Console.ReadLine();
                if (dateOfBirth != null && dateOfBirth.Length > 0)
                {
                    student.DateOfBirth = dateOfBirth;
                }

                Console.Write("Enter the new address (leave blank to keep current): ");
                string address = Console.ReadLine();
                if (address != null && address.Length > 0)
                {
                    student.Address = address;
                }

                Console.Write("Enter the new subjects (comma separated, leave blank to keep current): ");
                string subjectsInput = Console.ReadLine();
                if (subjectsInput != null && subjectsInput.Length > 0)
                {
                    student.Subject = new List<string>(subjectsInput.Split(','));
                }

                Console.WriteLine("Student information updated successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        // Chức năng xóa sinh viên
        public void Delete(string rollNumber)
        {
            Student student = students.Find(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student removed successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        // Chức năng xem danh sách sinh viên
        public void ViewAll()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
            }
            else
            {
                Console.WriteLine("List of students:");
                foreach (var student in students)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Name: "+student.Name);
                    Console.WriteLine("Roll Number: "+ student.RollNumber);
                    Console.WriteLine("Age: "+ student.RollNumber);
                    Console.WriteLine("Sex: "+ student.Sex);
                    Console.WriteLine("Date of Birth: "+ student.DateOfBirth);
                    Console.WriteLine("Address: "+ student.Address);
                    Console.WriteLine($"Subjects: {string.Join(", ", student.Subject)}");
                    Console.WriteLine("---------------------------------");
                }
            }
        }
    }
}
