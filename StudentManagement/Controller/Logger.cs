using System;
using StudentManagement.Model;
using StudentManagement.View;
using System.IO;
using System.Xml.Linq;
using System.Data;

namespace StudentManagement.Controller
{
    internal class Logger
    {
       public Logger() { }
       private Dictionary<string, string> listUser = new Dictionary<string, string>();
       private Output output = new Output();
        public int Log(int choice, User user)
        {
            if (choice == 1)
            {
                ReadFromFile();
                Console.Write("Enter your userName : ");
                string? userName = Console.ReadLine();
                Console.Write("Enter your password : ");
                string? pass = Console.ReadLine();
                if (userName != null && pass != null)
                {
                    if (listUser.ContainsKey(userName))
                    {
                        Console.WriteLine("The user name already exitst");
                        return 0;
                    }
                    else if(userName.Length > 8)
                    {
                        user.UserName = userName;
                        user.Password = pass;
                        if(user.UserName != null && user.Password != string.Empty)
                        {
                            listUser.Add(user.UserName, user.Password);
                            WriteToFile(listUser);
                        } else
                        {
                            return 0;
                        }
                        return 1;
                    } else
                    {
                        Console.WriteLine("The length of user name is short!");
                        return 0;
                    }
                }
            }
            else if (choice == 2)
            {
                Console.Write("Enter your userName : ");
                string? userName = Console.ReadLine();
                Console.Write("Enter your password : ");
                string? pass = Console.ReadLine();
                if (userName != null && pass != null)
                {
                    ReadFromFile();
                    if (listUser.ContainsKey(userName) == true)
                    {
                        if (listUser[userName] == pass)
                        {
                            user.UserName = userName;
                            user.Password = pass;
                            return 1;
                        }
                        else
                        {
                            Console.WriteLine("Error with your password!");
                            return 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error with your user name or password");
                        return 0;
                    }
                }
                return 0;
            }
            else Console.WriteLine("Invalid input");
            return 0;
        }

        public void WriteToFile(Dictionary<string, string> listUser)
        {
            string filePath = @"D:\StudentManagement\Project-Game2\StudentManagement\Controller\UserPasssword.txt";
            try
            {
                File.Create(@"D:\Final_project\Project-Game2\StudentManagement\Controller\UserPasssword.txt").Close();
                // Sử dụng StreamWriter để ghi dữ liệu vào file
                using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' để ghi thêm vào file nếu đã tồn tại
                {
                    // Ghi dữ liệu vào file
                    foreach (var user in listUser)
                    {
                        if(user.Key != null)
                        {
                            writer.WriteLine(user.Key + " : " + user.Value);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        public int ReadFromFile()
        {
            string filePath = @"D:\StudentManagement\Project-Game2\StudentManagement\Controller\UserPasssword.txt";
            try
            {

                if (File.Exists(filePath))
                {

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] lines = line.Split(" : ");
                            if(lines.Length == 2)
                            {
                                string key = lines[0].Trim();
                                string value = lines[1].Trim();
                                this.listUser.Add(key, value);
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
            ReadFromFile();
            string? newPass = string.Empty;
            do
            {
                Console.Write("Enter new password : ");
                newPass = Console.ReadLine();
            } while (user.checkPass(newPass) == 0);

            string filePath = @"D:\StudentManagement\Project-Game2\StudentManagement\Controller\UserPasssword.txt";
            if (File.Exists(filePath))
            {
                if (newPass != null)
                {
                    listUser[user.UserName] = newPass;
                }
                WriteToFile(this.listUser);
            }
            else
            {
                Console.WriteLine("File không tồn tại.");
            }
        }

    }

}
