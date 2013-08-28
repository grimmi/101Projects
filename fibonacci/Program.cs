using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    fibIter(steps);
                    break;
                }
                catch (NumberTooSmallException n)
                {
                    Console.WriteLine(n.Data["numberMessage"]);
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
                if (i == 0)
                {
                    fibSum = 0;
                }
                else if (i == 1)
                {
                    fibSum = 1;
                }
                else
                {
                    int tmp = f1;
                    fibSum = f1 + f2;
                    f1 = fibSum;
                    f2 = tmp;
                }
                Console.WriteLine("{0}", fibSum);
            }            
        }
    }
}
