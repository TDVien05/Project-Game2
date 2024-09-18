using System;
using StudentManagement.Model;
using StudentManagement.View;
using System.IO;
using System.Xml.Linq;
using System.Text.Json;
using System.Xml.Serialization;

namespace StudentManagement.Controller
{
    internal class StudentController
    {
        private List<Student> list = new List<Student>();
        public StudentController() { }

        public void WriteToFileStudent(List<Student> student)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            using (FileStream stream = new FileStream(@"D:\Final_project\Test\Test\Controller\Student_Information.txt", FileMode.Create))
            {
                for(int i = 0; i < student.Count; i++)
                {
                    serializer.Serialize(stream, student[i]);
                }
            }
        }

        public void ReadFromFileStudent()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            using (FileStream stream = new FileStream(@"D:\Final_project\Test\Test\Controller\Student_Information.txt", FileMode.Open))
            {
                Student obj = (Student)serializer.Deserialize(stream);
            }

        }

        public void Add()
        {
            Student student = new Student();
            Console.Write("Enter student name : ");
            string? name = Console.ReadLine();
            if (name != null) student.Name = name;
            Console.Write("Enter student rollNumber : ");
            string? rollNumber = Console.ReadLine();
            if (rollNumber != null) student.RollNumber = rollNumber;
            Console.Write("Enter student age : ");
            student.Age = Console.Read();
            Console.ReadLine();
            Console.Write("Enter student sex : ");
            string? sex = Console.ReadLine();
            if (sex != null) student.Sex = sex;
            Console.Write("Enter date of student : ");
            string? dateOfBirth = Console.ReadLine();
            if (dateOfBirth != null) student.DateOfBirth = dateOfBirth;
            Console.Write("Enter student's address : ");
            string? address = Console.ReadLine();
            if (address != null) student.Address = address;
            int check = 1;
            do
            {
                Console.Write("Enter student's course : ");
                string? course = Console.ReadLine();
                if (course != null)
                {
                    student.Subject.Add(course);
                }
                Console.Write("exit 1(No)/ 0(Yes) : ");
                check = Console.Read();
            } while (check == 1);
            list.Add(student);
            WriteToFileStudent(this.list);
        }

        public void edit_infor(List<Student> student)
        {
            Console.Write("Enter roll number : ");
            string? rollNum = Console.ReadLine();
            for(int i = 0; i < student.Count; i++)
            {
                if (student[i].RollNumber == rollNum)
                {
                    Console.Write("Enter student name : ");
                    string? name = Console.ReadLine();
                    if (name != null) student[i].Name = name;
                    Console.Write("Enter student rollNumber : ");
                    string? rollNumber = Console.ReadLine();
                    if (rollNumber != null) student[i].RollNumber = rollNumber;
                    Console.Write("Enter student age : ");
                    student[i].Age = Console.Read();
                    Console.ReadLine();
                    Console.Write("Enter student sex : ");
                    string? sex = Console.ReadLine();
                    if (sex != null) student[i].Sex = sex;
                    Console.Write("Enter date of student : ");
                    string? dateOfBirth = Console.ReadLine();
                    if (dateOfBirth != null) student[i].DateOfBirth = dateOfBirth;
                    Console.Write("Enter student's address : ");
                    string? address = Console.ReadLine();
                    if (address != null) student[i].Address = address;
                }
            }
            WriteToFileStudent(student);
        }
    }
}
