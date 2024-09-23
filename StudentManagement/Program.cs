using System;
using StudentManagement.Model;
using StudentManagement.View;

namespace StudentManagement
{
    class Program
    {
            static void Main(string[] args)
            {
                User user = new User();
                int check = 1;
                do
                {
                    Output output = new Output();
                    int x = output.SignUp_LogIn(user);
                    if(user.Password == null && user.UserName != null)
                    {
                        Console.WriteLine("Error with your user password");
                        x = 0;
                    }
                    if (x == 1)
                    {
                    Console.Clear();
                    do
                    {
                        int y = output.Menu(user);
                        if (y == -1)
                        {
                            break;
                        }
                    } while (x == 1);
                    check = 0;
                }
                } while (check == 1);
            }

    }
}