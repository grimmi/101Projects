using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Next Prime Number - Have the program find prime numbers until the user chooses to stop asking for the next one.
 * Erste Version: 31.08.2013
 */

namespace nextPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastPrime = 0;
            int numberOfPrime = 0;
            Console.WriteLine("Print next prime? y / n");
            while (true)
            {
                string inputString = Console.ReadLine();
                if (inputString.Equals("n"))
                {
                    break;
                }
                else
                {
                    lastPrime = nextPrime(lastPrime + 1);
                    numberOfPrime++;
                    string numberPrime = stndrdth(numberOfPrime);
                    Console.WriteLine("{0} prime: {1}", numberPrime, lastPrime);
                    Console.WriteLine("Continue? y / n");
                }
            }
        }

        private static string stndrdth(int numberOfPrime)
        {
            string primeString = numberOfPrime.ToString();
            char lastChar = primeString.Last();
            string[] endings = {"st","nd","rd","th"};
            string ending = "";
            if (lastChar.Equals('1') && numberOfPrime != 11)
            {
                ending = endings[0];
            }
            else if (lastChar.Equals('2') && numberOfPrime != 12)
            {
                ending = endings[1];
            }
            else if (lastChar.Equals('3') && numberOfPrime != 13)
            {
                ending = endings[2];
            }
            else
            {
                ending = endings[3];
            }
            return primeString + ending;
        }

        public static int nextPrime(int lastPrime)
        {            
            int iter = lastPrime;
            while (!isPrime(iter))
            {
                iter++;
            }
            return iter;
        }

        public static bool isPrime(int x)
        {
            if (x != 1 && x != 2)
            {
                for (int i = 2; i <= Math.Sqrt(x); i++)
                {
                    if (x % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
