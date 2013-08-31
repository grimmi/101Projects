using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specificPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which prime number do you want to see?");
            while (true)
            {
                string inputString = Console.ReadLine();
                try
                {
                    int step = int.Parse(inputString);
                    int prime = getSpecificPrime(step);
                    Console.WriteLine("{0}. prime is: {1}", step, prime);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input! Please enter only integer numbers!");
                }
            }
        }

        public static int getSpecificPrime(int step)
        {
            int lastPrime = 1;
            for (int i = 1; i <= step; i++)
            {
                lastPrime = nextPrime(lastPrime+1);
            }
            return lastPrime;
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
