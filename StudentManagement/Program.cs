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
                if (x == 1)
                {
                    Console.Clear();
                    do
                    {
                        output.Menu(user);
                    } while (x == 1);
                    check = 0;
                }
            } while (check == 1);
        }

    }
}