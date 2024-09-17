using System;
using Test.Model;
using Test.Controller;


namespace Test.View
{
    internal class Output
    {
        private StudentManagement studentManagement;
        public Output()
        {
            studentManagement = new StudentManagement();
        }
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
            Logger logger = new Logger();
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
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    studentManagement.Add();
                    break;
                case "2":
                    Console.Write("Enter the roll number of the student to update: ");
                    string rollNumberToUpdate = Console.ReadLine();
                    studentManagement.Update(rollNumberToUpdate);
                    break;
                case "3":
                    Console.Write("Enter the roll number of the student to delete: ");
                    string rollNumberToDelete = Console.ReadLine();
                    studentManagement.Delete(rollNumberToDelete);
                    break;
                case "4":
                    // Placeholder for showing list of subjects.
                    Console.WriteLine("Feature not implemented.");
                    break;
                case "5":
                    break;
                case "6":

                    break;
                case "7":

                    break;
                case "8":

                    break;
                case "9":
                    logger.ChangePass(user);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }
}
