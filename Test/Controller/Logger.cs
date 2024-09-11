using System;
using Test.Model;
using Test.View;
using System.IO;

namespace Test.Controller
{
    internal class Logger
    {
       private User user = new User();
        public Logger() { }
        public void Log(int choice)
        { 
            if(choice == 1)
            {
                Console.Write("Enter your userName : ");
                string? userName = Console.ReadLine();
                Console.Write("Enter your password : ");
                string? pass = Console.ReadLine();
                if (userName != null && pass != null)
                {
                    user.UserName = userName;
                    user.Password = pass;
                }
                WriteToFile();
            } 
            else if(choice == 2) 
            {
                Console.Write("Enter your userName : ");
                string? userName = Console.ReadLine();
                Console.Write("Enter your password : ");
                string? pass = Console.ReadLine();
                
            }
        }

        public void WriteToFile()
        {
            string filePath = @"D:\Final_project\Test\Test\Controllert";
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

        public void ReadFromFile()
        {
            string filePath = @"D:\Final_project\Test\Test\Controllert";
            try
            {

                if (File.Exists(filePath))
                {

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
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
        }

    }

}
