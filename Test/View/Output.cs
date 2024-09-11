using System;


namespace Test.View
{
    internal class Output
    {
        public Output() { }
        public void Log()
        {
            Console.WriteLine("------------WELCOME------------");
            Console.WriteLine("1 : Sign up");
            Console.WriteLine("2 : Log in");
            Console.Write("Enter your choice : ");
            int choice = Console.Read();
        }
    }
}
