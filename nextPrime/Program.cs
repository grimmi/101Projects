using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static List<int> primes;

        static void Main(string[] args)
        {
            primes = new List<int>();
            while (true)
            {
                showMenu();
                readInput();
            }
        }

        private static void showMenu()
        {
            Console.WriteLine("Menu:\r\n----------");
            Console.WriteLine("1) continous display of prime numbers");
            Console.WriteLine("2) specific prime number");
            Console.WriteLine("3) closest prime to number");
            Console.WriteLine("4) print already calculated primes");
            Console.WriteLine("to exit, press Ctrl + C");
            Console.WriteLine("----------");
        }

        private static void readInput()
        {
            string inputString = Console.ReadLine();
            int choice = 0;
            try
            {
                choice = int.Parse(inputString);
                switch (choice)
                {
                    case 1: pressForNextPrime();
                        break;
                    case 2: showSpecificPrime();
                        break;
                    case 3: showClosestPrime();
                        break;
                    case 4: printPrimes();
                        break;
                    default: Console.WriteLine("Choose between the shown options!");
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public static void pressForNextPrime()
        {
            Console.WriteLine("Press any key for the next prime number or 'n' to exit");
            int numberOfPrime = 0;
            int lastPrime = 1;
            while (true)
            {
                if (!Console.ReadLine().Equals("n"))
                {
                    Console.WriteLine("any key to continue or 'n' to exit");
                    numberOfPrime++;
                    lastPrime = nextPrime(lastPrime + 1);
                    string numberPrime = stndrdth(numberOfPrime);
                    Console.WriteLine("{0} prime: {1}", numberPrime, lastPrime);
                }
                else
                {
                    break;
                }
            }
        }

        public static void showSpecificPrime()
        {
            Console.WriteLine("Which prime do you want to see? (press n to exit)");
            try
            {
                string spec = Console.ReadLine();
                if (!spec.ToLower().Equals("n"))
                {
                    int specPrime = int.Parse(spec);
                    Console.WriteLine("The {0}. prime is: {1}", specPrime, getSpecificPrime(specPrime));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input! Please enter an integer number or 'n' to return to the main program!");
            }
        }

        public static void showClosestPrime()
        {
            Console.WriteLine("Enter an integer to which you want the closest prime number: ");
            try
            {
                int target = int.Parse(Console.ReadLine());
                int closePrime = primeClosestTo(target);
                Console.WriteLine("The closest prime to {0} is: {1}", target, closePrime);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input! Please enter an integer number!");
            }
        }

        public static void printPrimes()
        {
            Console.WriteLine("Already calculated prime numbers:");
            int count = 1;
            foreach (int i in primes)
            {
                Console.WriteLine("{0} prime: {1}", stndrdth(count), i);
                count++;
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
            primes.Add(iter);
            return iter;
        }

        public static bool isPrime(int x)
        {
            if (x != 1 && x != 2)
            {
                if (x % 2 == 0)
                {
                    return false;
                }
                for (int i = 3; i <= Math.Sqrt(x); i += 2)
                {
                    if (x % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static int getSpecificPrime(int step)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (step > primes.Count())
            {
                Console.WriteLine("Calculated from the {0}. prime ({1})", primes.Count(), primes.Last());
                int lastPrime = primes.Last();
                for (int i = primes.Count(); i < step; i++)
                {
                    lastPrime = nextPrime(lastPrime + 1);
                }
                sw.Stop();
                Console.WriteLine("Without lookup, this took {0}ms", sw.ElapsedMilliseconds);
                return lastPrime;
            }
            else
            {
                sw.Stop();
                Console.WriteLine("With lookup, this took {0}ms", sw.ElapsedMilliseconds);
                return primes[step-1];
            }
        }

        public static int primeClosestTo(int target)
        {
            int prime = 2;
            while (nextPrime(prime + 1) < target)
            {
                prime = nextPrime(prime + 1);
            }
            int biggerPrime = nextPrime(prime + 1);
            if ((target - prime) > (biggerPrime - target))
            {
                return biggerPrime;
            }
            else
            {
                return prime;
            }
        }
    }
}
