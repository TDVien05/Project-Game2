using System;
using Test.Model;
using Test.Controller;


namespace Test.View
{
    internal class Output
    {
        public Output() { }
        public void Log()
        {
            Logger logger = new Logger();
            Console.WriteLine("------------WELCOME------------");
            Console.WriteLine("1 : Sign up");
            Console.WriteLine("2 : Log in");
            Console.Write("Enter your choice : ");
            string? input = Console.ReadLine();    
            if (int.TryParse(input, out int choice))
            {
                logger.Log(choice);
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập số.");
            }
        }

        public void Menu()
        {
            Console.WriteLine("------------WELCOME------------");
            Console.WriteLine("1 : Add a student");
            Console.WriteLine("2 : Edit a student's information");
            Console.WriteLine("3 : Remove a student");
            Console.WriteLine("4 : Show the list of subject");
            Console.WriteLine("5 : Search student with roll number");
            Console.WriteLine("6 : Search subject with ID");
            Console.WriteLine("7 : Filter student with ID subject");
            Console.WriteLine("8 : Show the list of student");
        }
    }
}
