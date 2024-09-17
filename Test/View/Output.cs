﻿using System;
using Test.Model;
using Test.Controller;


namespace Test.View
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
            SubjectHandler subList = new SubjectHandler();
            StudentHandler stu = new StudentHandler();
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

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    subList.DisplaySubjectList();
                    subList.RegisterSubject();
                    break;
                case 5:
                case 6:
                    Console.WriteLine("Nhap id mon hoc de tim kiem: ");
                    string id = Console.ReadLine();
                    SubjectHandler.GetSubjectNameById(id);
                    break;
                case 7:
                    break;
                case 8:
                    stu.PrintStudentList();
                    break;

                case 9:
                    logger.ChangePass(user);
                    break;

            }
        }
    }
}
