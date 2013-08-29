﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringReverse
{
    static class stringExtension
    {
        // extension methods müssen public sein! eigentlich logisch...
        public static string reverseString(this string str)
        {
            string reverse = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverse += str[i];
            }
            return reverse;
        }
    }
}