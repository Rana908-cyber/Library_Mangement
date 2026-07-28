using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utilities
{
    public class Validation
    {
 
    public static bool IsValidString(string s)
    {
        return (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s));
    }

    public static bool IsValidId(string s)
    {
        return (s.All(d=> d>='0' && d<='9') && !string.IsNullOrEmpty(s));
    }
        public static bool IsValidYear(int year)
        {
            return  year <= DateTime.Now.Year;
        }

    }
}