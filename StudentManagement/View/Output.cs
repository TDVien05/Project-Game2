using System;
using StudentManagement.Model;
using StudentManagement.Controller;


namespace StudentManagement.View
{
    internal class Output
    {
        public Output() { }
        public int SignUp_LogIn(User user)
        {
            Logger logger = new Logger();
            Console.WriteLine("------------WELCOME------------");
            Console.WriteLine("1 : Sign up");
            Console.WriteLine("2 : Log in");
            Console.Write("Enter your choice : ");
            string? input = Console.ReadLine();    
            if (int.TryParse(input, out int choice))
            {
                return logger.Log(choice, user);
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập số.");
                return 0;
            }
        }

        public void Menu(User user)
        {
            Console.Clear();
            Logger logger = new Logger();
            StudentController studentController = new StudentController();
            Console.WriteLine("------------WELCOME------------");
            Console.WriteLine("1 : Add a student");
            Console.WriteLine("2 : Edit a student's information");
            Console.WriteLine("3 : Remove a student");
            Console.WriteLine("4 : Show the list of subject");
            Console.WriteLine("5 : Search student with roll number");
            Console.WriteLine("6 : Search subject with ID");
            Console.WriteLine("7 : Filter student with ID subject");
            Console.WriteLine("8 : Show the list of student");
            Console.WriteLine("9 : Change the password");
            Console.Write("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    studentController.Add();
                    break;
                case 2:
                    studentController.Add();
                    break;
                case 9:
                    logger.ChangePass(user);
                    break;
            }
        }
    }
}
