using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    internal class User
    {
        private string userName = string.Empty;
        private string password = string.Empty;

        public User() { }

        public string UserName
        {
            get { return userName; }
            set
            {
                //TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                //string? lowerUserName = textInfo.ToLower(value);

                //string? normalizedUserName = textInfo.ToTitleCase(lowerUserName);
                //string result = string.Join(" ", normalizedUserName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                userName = value;
                userName.Trim();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if(checkPass(value) == 1)
                {
                    password = value;
                } else
                {
                   
                    if(value.Length > 8)
                    {
                        Console.WriteLine("Password should contain Capital, letter, number, special character excep space");
                    }
                    password = string.Empty;
                }
            }
        }

        public int checkPass(string password)
        {
            if (password.Length < 8)
            {
                Console.WriteLine("Password is too short");
                return 0;
            }
            else
            {
                int count_alpha = 0, count_num = 0, count_spec = 0, count_Cap = 0;
                foreach (char c in password)
                {
                    if (c >= 97 && c <= 122) count_Cap++;
                    else if ((c >= 65 && c <= 90) || (c >= 97 && c <= 122)) count_alpha++;
                    else if ((c >= 48 && c <= 57)) count_num++;
                    else if (c == ' ')
                    {
                        Console.WriteLine("Password should not contain space");
                        return 0;
                    }
                    else count_spec++;
                }
                if (count_Cap != 0 && count_num != 0 && count_spec != 0 && count_alpha != 0)
                {
                    return 1;
                }
                else if (count_Cap == 0 || count_num == 0 || count_spec == 0 || count_alpha == 0)
                {
                    return 0;
                }
            }
            return 1;
        }


    }
}
