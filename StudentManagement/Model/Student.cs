using System;

namespace StudentManagement.Model
{
    internal class Student
    {
        private string name = string.Empty;
        private string rollNumber = string.Empty;
        private int age = 0;
        private string sex = string.Empty;
        private string dateOfBirth = string.Empty;
        private string address = string.Empty;
        private List<string> subject = new List<string>();

        public Student() { }

        public Student(string name, string rollNumber, int age, string sex, string dateOfBirth, string address, List<string> subject)
        {
            this.name = name;
            this.rollNumber = rollNumber;
            this.age = age;
            this.sex = sex;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
            this.subject = subject;
        }
        public Student(string name, string rollNumber, int age, string sex, string dateOfBirth, string address)
        {
            this.name = name;
            this.rollNumber = rollNumber;
            this.age = age;
            this.sex = sex;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string RollNumber
        {
            get { return rollNumber; }
            set { rollNumber = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public List<string> Subject
        {
            get { return subject; }
            set { subject = value; }
        }



    }
}