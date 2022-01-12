using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SchoolERPSystem.Web.Areas.student.Helpers
{
    public static class Helper
    {
        private static string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "@", "#", "$", "%", "&", "*" };

        public static string GetRandomPassword(int length)
        {
            Random rnd = new Random();
            int charArrayLength = chars.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[rnd.Next(charArrayLength)]);
            }
            return sb.ToString();
        }
    }
}