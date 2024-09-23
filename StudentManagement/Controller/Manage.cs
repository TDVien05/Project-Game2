using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace StudentManagement.Controller
{
    internal class Manage
    {
        private List<Student> students = new List<Student>();

        public Manage() { }

        // Chức năng thêm sinh viên

        public void WriteToFile(List<Student> students)
        {
            Console.WriteLine("Ghi file co hoat dong");
            string filePath = @"D:\StudentManagement\Project-Game2\StudentManagement\Controller\Student_Information.txt";
            try
            {
                File.Create(@"D:\StudentManagement\Project-Game2\StudentManagement\Controller\Student_Information.txt").Close();
                // Sử dụng StreamWriter để ghi dữ liệu vào file
                using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' để ghi thêm vào file nếu đã tồn tại
                {
                    // Ghi dữ liệu vào file
                    foreach (var student in students)
                    {
                        writer.WriteLine(student.toString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        public void Add()
        {
            bool check = true;
            int checkAge = 1;
            Student student = new Student();

            Console.Write("Enter the student name: ");
            while (check)
            {
                student.Name = Console.ReadLine();
                if (!IsAlphabetic(student.Name))
                {
                    Console.WriteLine("The entered full name is invalid. Please enter it again.");
                    check = true;
                }
                else
                {

                    // Viết hoa chữ cái đầu của mỗi từ
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    student.Name = textInfo.ToTitleCase(student.Name.ToLower());
                    check = false;
                }
            }

            Console.Write("Enter the roll number: ");
            student.RollNumber = Console.ReadLine();

            do
            {
                Console.Write("Enter the age: ");
                string? tmp = Console.ReadLine();
                int age;
                if (int.TryParse(tmp, out age))
                {
                    student.Age = age;
                    checkAge = 0;
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a valid number.");
                }
            } while (checkAge == 1);

            Console.Write("Enter the sex: ");
            student.Sex = Console.ReadLine();

            Console.Write("Enter the date of birth: ");
            student.DateOfBirth = Console.ReadLine();

            Console.Write("Enter the address: ");
            student.Address = Console.ReadLine();

            Console.Write("Enter subjects (comma separated): ");
            string? subjectsInput = Console.ReadLine();
            student.Subject = new List<string>(subjectsInput.Split(','));

            students.Add(student);
            WriteToFile(this.students);
            Console.ReadLine();
            Console.WriteLine("Student added successfully!");
        }

        // Kiểm tra chuỗi có phải là chữ cái
        static bool IsAlphabetic(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        // Chức năng sửa thông tin sinh viên
        public void Update(string rollNumber)
        {
            Student student = students.Find(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                Console.Write("Enter the new name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    if (IsAlphabetic(name))
                    {
                        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                        student.Name = textInfo.ToTitleCase(name.ToLower());
                    }
                    else
                    {
                        Console.WriteLine("Invalid name format.");
                        return;
                    }
                }

                Console.Write("Enter the new age (leave blank to keep current): ");
                string ageInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(ageInput) && int.TryParse(ageInput, out int age))
                {
                    student.Age = age;
                }

                Console.Write("Enter the new sex (leave blank to keep current): ");
                string sex = Console.ReadLine();
                if (!string.IsNullOrEmpty(sex))
                {
                    student.Sex = sex;
                }

                Console.Write("Enter the new date of birth (leave blank to keep current): ");
                string dateOfBirth = Console.ReadLine();
                if (!string.IsNullOrEmpty(dateOfBirth))
                {
                    student.DateOfBirth = dateOfBirth;
                }

                Console.Write("Enter the new address (leave blank to keep current): ");
                string address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address))
                {
                    student.Address = address;
                }

                Console.Write("Enter the new subjects (comma separated, leave blank to keep current): ");
                string subjectsInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(subjectsInput))
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
                    Console.WriteLine("Name: " + student.Name);
                    Console.WriteLine("Roll Number: " + student.RollNumber);
                    Console.WriteLine("Age: " + student.Age);
                    Console.WriteLine("Sex: " + student.Sex);
                    Console.WriteLine("Date of Birth: " + student.DateOfBirth);
                    Console.WriteLine("Address: " + student.Address);
                    Console.WriteLine($"Subjects: {string.Join(", ", student.Subject)}");
                    Console.WriteLine("---------------------------------");
                }
            }
        }
    }
}
