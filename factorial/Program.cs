using System;
using System.Collections.Generic;
using System.Diagnostics;

/*
 * Factorial Finder - The Factorial of a positive integer, n, is defined as the product of the sequence n, n-1, n-2, ...1 and the factorial of zero, 0, is defined as being 1. Solve this using both loops and recursion. 
 * Erste Version: 29.08.2013
 */

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Integer:");
                string inputString = Console.ReadLine();
                try
                {
                    int inputNumber = int.Parse(inputString);
                    if (inputNumber > 0)
                    {
                        factIter(inputNumber);
                        Console.WriteLine("Factorial of {0} (recursively): {1}", inputNumber, factRec(inputNumber));
                    }
                    Console.ReadKey();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input!");
                    Debug.WriteLine(e);
                }
            }
        }

        private static void factIter(int inputNumber)
        {
            int fact = 1;
            for (int i = 1; i <= inputNumber; i++)
            {
                fact *= i;
            }
            Console.WriteLine("Factorial of {0}: {1}", inputNumber, fact);
        }

        private static int factRec(int inputNumber)
        {
            if (inputNumber > 0)
            {
                return inputNumber * factRec(inputNumber - 1);
            }
            else
            {
                return 1;
            }
        }
    }
}
