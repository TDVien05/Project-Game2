using System;
using Test.Model;
using Test.View;
using System.IO;
using System.Xml.Linq;

namespace Test.Controller
{
    internal class Logger
    {
        private const string filePath = @"D:\Final_project\Test\Test\Controller\UserPasssword.txt";
        public Logger() { }
        private User user = new User();
        private Output output = new Output();
        public int Log(int choice, User user)
        {
            if (choice == 1)
            {
                Console.Write("Enter your userName : ");
                string? userName = Console.ReadLine();
                Console.Write("Enter your password : ");
                string? pass = Console.ReadLine();
                if (userName != null && pass != null)
                {
                    user.UserName = userName;
                    user.Password = pass;
                    if (user.UserName != null && user.Password != string.Empty)
                    {
                        WriteToFile(user);
                        return 1;
                    }
                }
                return 0;
            }
            else if (choice == 2)
            {
                Console.Write("Enter your userName : ");
                string? userName = Console.ReadLine();
                Console.Write("Enter your password : ");
                string? pass = Console.ReadLine();
                if (userName != null && pass != null)
                {
                    if ((ReadFromFile(userName, pass) == 1))
                    {
                        user.UserName = userName;
                        user.Password = pass;
                        return 1;
                    }
                    else Console.WriteLine("Error with your user name or password");

                }
                return 0;
            }
            return 0;
        }

        public void WriteToFile(User user)
        {
            try
            {
                // Sử dụng StreamWriter để ghi dữ liệu vào file
                using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' để ghi thêm vào file nếu đã tồn tại
                {
                    // Ghi dữ liệu vào file
                    writer.WriteLine(user.UserName);
                    writer.WriteLine(user.Password);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        public int ReadFromFile(string name, string pass)
        {
            try
            {

                if (File.Exists(filePath))
                {

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line == name)
                            {
                                string? line2 = reader.ReadLine();
                                if (line2 != null && line2 == pass)
                                {
                                    return 1;
                                }
                                else return 0;
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
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
            return 0;
        }

        public void ChangePass(User user)
        {
            Console.Write("Enter new password : ");
            string? newPass = Console.ReadLine();
            if (File.Exists(filePath))
            {
                try
                {
                    string check = string.Empty;
                    string[] lines = File.ReadAllLines(filePath);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if ((lines[i] == user.Password) && (newPass != null))
                        {
                            lines[i] = newPass;
                            break;
                        }
                    }
                    File.WriteAllLines(filePath, lines);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File không tồn tại.");
            }
        }

    }

}
