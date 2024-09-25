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
                Console.WriteLine("Invalid input");
                return 0;
            }
        }

        public int Menu(User user)
        {
            Console.Clear();
            StudentHandler stu = new StudentHandler();
            SubjectHandler subList = new SubjectHandler(stu);
            Logger logger = new Logger();
            Program program = new Program();
            Manage manage = new Manage();   
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
            Console.WriteLine("0 : Exit");
            int choice = 1;
            //Console.Write("Enter your choice : ");
            //choice = int.Parse(Console.ReadLine());
            do
            {
                try
                {
                    Console.Write("Enter your choice : ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            manage.Add();
                            break;
                        case 2:
                            Console.Write("Enter roll number : ");
                            string? rollUpdate = Console.ReadLine();
                            if(rollUpdate != null)
                            {
                                manage.Update(rollUpdate);
                            }
                            break;
                        case 3:
                            Console.Write("Enter roll number : ");
                            string? rollDelete = Console.ReadLine();
                            if (rollDelete != null)
                            {
                                manage.Delete(rollDelete);
                            }
                            break;
                        case 4:
                            subList.DisplaySubjectList();
                            subList.RegisterSubject();
                            break;
                        case 5:
                            string rollNum = stu.getRollNum();
                            Student? st = stu.SearchStudentByRollNumber(rollNum);
                            if(st != null)
                            {
                                Console.WriteLine(st.Name);
                                Console.WriteLine(st.RollNumber);
                                Console.WriteLine(st.Age);
                                Console.WriteLine(st.Sex);
                                Console.WriteLine(st.DateOfBirth);
                                Console.WriteLine(st.Address);
                                Console.Write("Subjects : ");
                                foreach(string tmp in st.Subject)
                                {
                                    Console.Write(tmp + " ");
                                }
                                Console.ReadLine(); 
                            } else Console.WriteLine("Error");
                            break;
                        case 6:
                            SubjectHandler.PrintSubjectById();
                            break;
                        case 7:
                            Console.WriteLine("Enter Subject to filter and display students: ");
                            string? subjectId = Console.ReadLine();
                            stu.FilterBySubjectId(subjectId);
                            break;
                        case 8:
                            stu.PrintStudentList();
                            break;
                        case 9:
                            logger.ChangePass(user);
                            break;
                        case 0:
                            return -1;
                    }
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (choice != 0);
            return -1;
        }
    }
}
