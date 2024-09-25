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
using StudentManagement.Controller;

namespace StudentManagement.Controller
{
    internal class Manage
    {
        private List<Student> students = new List<Student>();
        //private StudentHandler handler = new StudentHandler();

        public Manage() { }
        public void WriteToFile(List<Student> students)
        {
            string filePath = @"D:\StudentManagement\Project-Game2\StudentManagement\Controller\Student_Information.txt";
            try
            {
                File.Create(@"D:\StudentManagement\Project-Game2\StudentManagement\Controller\Student_Information.txt").Close();
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (var student in students)
                    {
                        string line = $"{student.Name} : {student.RollNumber} : {student.Age} : {student.Sex} : {student.DateOfBirth} : {student.Address} : {string.Join(";", student.Subject)} ";
                        writer.WriteLine(line); // Ghi từng dòng vào file
                        //writer.WriteLine(student.toString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        public List<Student> ReadFromFile()
        {
            string filePath = @"D:\StudentManagement\Project-Game2\StudentManagement\Controller\Student_Information.txt";
            try
            {

                if (File.Exists(filePath))
                {

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            // string[] lines = line.Split(" - ");
                            string[] parts = line.Split(" : ");
                            if (parts.Length == 7)
                            {
                                string name = parts[0].Trim();
                                string rollNumber = parts[1].Trim();
                                string age = parts[2].Trim();
                                string sex = parts[3].Trim();
                                string dateOfBirth = parts[3].Trim();
                                string address = parts[5].Trim();   
                                List<string> subject = parts[6].Split(';').Select(s => s.Trim()).ToList();

                                // Tạo đối tượng Student và thêm vào danh sách
                                Student student = new Student
                                {
                                    Name = name,
                                    RollNumber = rollNumber,
                                    Age = int.Parse(age),
                                    Sex = sex,
                                    //DateOfBirth = dateOfBirth,
                                    Address = address,
                                    Subject = subject,
                                };

                                // Thêm sinh viên vào danh sách
                                students.Add(student);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File không tồn tại.");
                }
                }
    catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return students;
        }
        public void Add()
        {
            //ReadFromFile();
            students = ReadFromFile();
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
                    if (age >= 0) // Kiểm tra tuổi không được âm
                    {
                        student.Age = age;
                        checkAge = 0; // Thoát vòng lặp
                    }
                    else
                    {
                        Console.WriteLine("Age cannot be negative. Please enter a valid age.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a valid number.");
                }
            } while (checkAge == 1);

            Console.Write("Enter the sex (male/female): ");
            string? sex;

            while (true)
            {
                sex = Console.ReadLine();

                // Kiểm tra nếu sex là "male" hoặc "female"
                if (sex?.ToLower() == "male" || sex?.ToLower() == "female")
                {
                    student.Sex = sex;  // Lưu giới tính vào đối tượng student
                    break;  // Thoát khỏi vòng lặp khi nhập đúng
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter 'male' or 'female'.");
                    Console.Write("Enter the sex (male/female): ");
                }
            }
            
            Console.Write("Enter the date of birth (dd/MM/yyyy): ");
            string? dateOfBirth;

            while (true)
            {
                dateOfBirth = Console.ReadLine();

                // Kiểm tra xem chuỗi chỉ chứa các ký tự số và dấu '/'
                if (!string.IsNullOrEmpty(dateOfBirth) && dateOfBirth.All(c => char.IsDigit(c) || c == '/'))
                {
                    try
                    {
                        // Cố gắng chuyển đổi chuỗi thành ngày tháng
                        DateTime parsedDate = DateTime.ParseExact(dateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        // Kiểm tra xem ngày nhập có lớn hơn ngày hiện tại không
                        if (parsedDate > DateTime.Now)
                        {
                            Console.WriteLine("Date of birth cannot be in the future. Please enter again.");
                        }
                        else
                        {
                            // Ngày hợp lệ, thoát vòng lặp
                            student.DateOfBirth = dateOfBirth;
                            //Console.WriteLine("Valid date of birth.");
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid date format. Please enter again (dd/MM/yyyy).");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid date using numbers and '/'.");
                }
            }

            Console.Write("Enter the address: ");
            student.Address = Console.ReadLine();

            Console.Write("Enter subjects (comma separated): ");
            string? subjectsInput = Console.ReadLine();
            student.Subject = new List<string>(subjectsInput.Split(','));

            students.Add(student);
            WriteToFile(students);
            Console.WriteLine("Press enter to continue");
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
            //ReadFromFile(string rollNumber);
            students = ReadFromFile();
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
                WriteToFile(students);
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        // Chức năng xóa sinh viên
        public void Delete(string rollNumber)
        {
            students = ReadFromFile();
            Student student = students.Find(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student removed successfully!");
                WriteToFile(students);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Student not found!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
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
