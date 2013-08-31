using System;
using System.Collections.Generic;
using System.Diagnostics;

/*
 * Fibonacci Sequence - Enter a number and have the program generate the Fibonacci sequence to that number or to the Nth number.
 * Erste Version: 28.08.2013
 * Erstmal iterativ implementiert, irgendwie hänge ich gerade durch. Rekursiv kommt ein anderes mal. Ist zwar Blödsinn, aber Rekursion ist spannend.
 */

namespace fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter integer: ");
                string inputString = Console.ReadLine();
                try
                {
                    int steps = int.Parse(inputString);
                    if (steps <= 2)
                    {
                        throw new NumberTooSmallException();
                    }
                    else if (steps > 47)
                    {   // with fibonacci values for inputs larger than 47, int is too small
                        throw new NumberTooBigException();
                    }
                    fibIter(steps);
                    break;
                }
                catch (Exception n)
                {
                    Console.WriteLine("Invalid Input!");
                    if (n.GetType() == typeof(NumberTooSmallException) || n.GetType() == typeof(NumberTooBigException))
                    {
                        Console.WriteLine(n.Data["numberMessage"]);
                    }
                    else
                    {
                        Console.WriteLine("Please enter only integers bigger than 2 and smaller than 48");
                        Debug.WriteLine(n);
                    }
                }
            }
            Console.ReadKey();
        }

        private static void fibIter(int steps)
        {
            int fibSum = 0; // fibonacci-summe = f(i-1) + f(i-2)
            int f1 = 1;
            int f2 = 0;
            for (int i = 0; i < steps; i++)
            {
                fibSum = i == 0 ? 0 : i == 1 ? 1 : fibSum = f1 + f2; int tmp = f1; f1 = fibSum; f2 = tmp;
                // the one line above is equivalent to the if / else if / else construct below
                /* 
                // for 0 and 1 we return 1 as per definition
                if (i == 0)
                {
                    fibSum = 0;
                }
                else if (i == 1)
                {
                    fibSum = 1;
                }
                // the 'real' fibonacci sequence: fib(x) = fib(x-1)+fib(x-2)
                else
                {
                    fibSum = f1 + f2;
                    int tmp = f1;
                    f1 = fibSum;
                    f2 = tmp;
                 * 
                }
                 */
                Console.WriteLine("{0}", fibSum);
            }            
        }
    }

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
