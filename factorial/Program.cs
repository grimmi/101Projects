﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
