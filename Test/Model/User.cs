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

        public string UserName
        {
            get { return userName; }
            set
            {
                // Chuyển đổi thành chữ thường và phân tách thành các từ
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                string? lowerUserName = textInfo.ToLower(value);

                // Chuyển đổi ký tự đầu tiên của mỗi từ thành chữ hoa
                string? normalizedUserName = textInfo.ToTitleCase(lowerUserName);
                string result = string.Join(" ", normalizedUserName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                userName = result;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 8)
                {
                    Console.WriteLine("Password is too short");
                    return;
                }
                else
                {
                    int count_alpha = 0, count_num = 0, count_spec = 0, count_Cap = 0;
                foreach(char c in value)
                {
                    if(c >= 97 && c <= 122) count_Cap++;    
                    if((c >= 65 && c <= 90) || (c >= 97 && c <= 122)) count_alpha++;
                    else if((c >= 48 && c <= 57)) count_num++;
                    else if(c == ' ')
                    {
                            Console.WriteLine("Password should not contain space");
                            return;
                    }
                    else count_spec++;
                }
                if(count_Cap != 0 && count_num != 0 && count_spec != 0 && count_alpha != 0)
                {
                    password = value;
                } 
                else
                {
                        Console.WriteLine("Password should contain at least one capital letters, one number, one alphabet");
                        return;
                }
                }
            }
        }




    }
}
