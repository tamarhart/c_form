using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace הפרוייקט_של_תמי
{
    class legal
    {
        //בדיקת תעודת זהות 
        public static bool LegalId(string s)
        {
            int x;
            if (!int.TryParse(s, out x))
                return false;
            if (s.Length < 5 || s.Length > 9)
                return false;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]));
                if (k > 9)
                    k -= 9;
                sum += k;

            }
            return sum % 10 == 0;
        }
        public static bool IsHebrew(string word)
        {
            string pattern = @"\b[א-ת-\s ]+$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(word);

        }
        //אותיות אנגליות גדולות
        public static bool IsEnglishBig(string word)
        {
            string pattern = @"\b[A-Z\s ]+$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(word);

        }
        //אותיות אנגליות קטנות
        public static bool IsEnglishSmall(string word)
        {
            string pattern = @"\b[a-z\s ]+$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(word);
        }
        //   מספרים בלבד
        public static bool IsNumber(string num)
        {
            string pattern = @"\b[0-9-\s]+$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(num);
        }
        //עשרוני בלבד
        public static bool IsDouble(string num)
        {
            string pattern = @"\b[0-9-\s].[0-9-\s]+$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(num);
        }
    }
}
