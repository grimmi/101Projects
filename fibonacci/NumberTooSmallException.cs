using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fibonacci
{
    class NumberTooSmallException : Exception
    {
        public NumberTooSmallException()
        {
            this.Data.Add("numberMessage", "Enter a number greater than 2!");
        }
    }

    class NumberTooBigException : Exception
    {
        public NumberTooBigException()
        {
            this.Data.Add("numberMessage", "Enter a number smaller than 47!");
        }
    }
}
