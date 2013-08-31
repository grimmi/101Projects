using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

/*
 * Next Prime Number - Have the program find prime numbers until the user chooses to stop asking for the next one.
 * Erste Version: 31.08.2013
 */

namespace nextPrime
{
    class Program
    {
        // a list in which already calculated prime numbers are stored
        public static List<int> primes;

        static void Main(string[] args)
        {
            // initialize the list
            primes = new List<int>();
            while (true)
            {
                // show the menu
                showMenu();
                // read the console input
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
            Console.WriteLine("5) exit");
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
                    default: Console.WriteLine("Choose between the shown options!");
                        break;
                    case 1: pressForNextPrime();
                        break;
                    case 2: showSpecificPrime();
                        break;
                    case 3: showClosestPrime();
                        break;
                    case 4: printPrimes();
                        break;
                    case 5: System.Environment.Exit(0);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Choose between the shown options!");
                Debug.WriteLine(e);
            }
        }

        public static void pressForNextPrime()
        {
            Console.WriteLine("Press any key for the next prime number or 'n' to exit");
            // to keep track of which prime number we're showing, we use a counter variable
            int numberOfPrime = 0;
            // initial value of the prime number - here put as 1 so the first invocation of nextPrime is with 2
            int lastPrime = 1;
            while (true)
            {
                if (!Console.ReadLine().Equals("n"))
                {
                    Console.WriteLine("any key to continue or 'n' to exit");
                    // one step further
                    numberOfPrime++;
                    // calculate the next bigger prime number
                    lastPrime = nextPrime(lastPrime + 1);
                    // format the number accordingly (1st, 2nd, 3rd, 4th, ...)
                    Console.WriteLine("{0} prime: {1}", stndrdth(numberOfPrime), lastPrime);
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
                    Console.WriteLine("The {0} prime is: {1}", stndrdth(specPrime), getSpecificPrime(specPrime));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input! Please enter an integer number or 'n' to return to the main program!");
                Debug.WriteLine(e);
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
                Debug.WriteLine(e);
            }
        }

        // prints out all already calculated prime numbers
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

        // formates numbers accordingly (1st, 2nd, 3rd, 4th, ...)
        private static string stndrdth(int numberOfPrime)
        {
            string primeString = numberOfPrime.ToString();
            char lastChar = primeString.Last();
            // the endings for english numbers
            string[] endings = {"st","nd","rd","th"};
            string ending = "";
            // all numbers ending on 1 get 'st' - except the eleven!
            if (lastChar.Equals('1') && numberOfPrime != 11)
            {
                ending = endings[0];
            }
            // same as with the 1 at the end, here we have to beware of the twelve
            else if (lastChar.Equals('2') && numberOfPrime != 12)
            {
                ending = endings[1];
            }
            // ... and thirteen
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

        // calculates the next bigger prime to a given number
        public static int nextPrime(int lastPrime)
        {
            // iter is just a counting variable
            int iter = lastPrime;
            // run through the numbers until we hit a prime number
            while (!isPrime(iter))
            {
                iter++;
            }
            // add the prime number to the list
            primes.Add(iter);
            return iter;
        }

        // checks if a given number is a prime
        public static bool isPrime(int x)
        {
            // 1 and 2 are trivial - yeah, 1 is no prime...
            if (x != 1 && x != 2)
            {
                // all even numbers go out right away
                if (x % 2 == 0)
                {
                    return false;
                }
                // because we only get here if the value is greater than 2, we start with 3 and proceed only with uneven numbers
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

        // calculates e.g. the 100th prime number
        public static int getSpecificPrime(int step)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // we only have to do calculations if we need a higher prime than we already calculated
            if (step > primes.Count())
            {
                Console.WriteLine("Calculated from the {0}. prime ({1})", primes.Count(), primes.Last());
                // we use the highest calculated prime number as starting point
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
                // the step is smaller than the amount of primes already calculated, so we look it up in the list
                sw.Stop();
                Console.WriteLine("With lookup, this took {0}ms", sw.ElapsedMilliseconds);
                return primes[step-1];
            }
        }

        // calculate the closest prime to a given number
        public static int primeClosestTo(int target)
        {
            int prime = 2;
            // calculate the prime that's closest to the target while being smaller
            while (nextPrime(prime + 1) < target)
            {
                prime = nextPrime(prime + 1);
            }
            // one more iteration of nextPrime gives us the closest prime to the target that's bigger
            int biggerPrime = nextPrime(prime + 1);
            // just check which difference is smaller and return that - if the difference is the same, return the smaller
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

    class closeProgramException : Exception
    {

    }
}