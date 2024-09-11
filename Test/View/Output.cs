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
    }
}
