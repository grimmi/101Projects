using System;

/*
 * Check if Palindrome - Checks if the string entered by the user is a palindrome. That is that it reads the same forwards as backwards like “racecar”
 * Erste Version: 29.08.2013
 */

namespace palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter a string with at least 2 characters!");
                string inputString = Console.ReadLine();
                if (inputString.Length > 2)
                {
                    bool isPalindrome = true;
                    // we look at the second half of the string and compare it to the first half - if they match, we have a palindrome
                    for (int i = inputString.Length - 1; i >= inputString.Length / 2; i--)
                    {
                        if (!(inputString[i].Equals(inputString[(inputString.Length - 1) - i])))
                        {
                            // if we find a non matching char, we break the for loop
                            isPalindrome = false;
                            break;
                        }
                    }
                    if (isPalindrome)
                    {
                        Console.WriteLine("{0} is a palindrome!", inputString);
                    }
                    else
                    {
                        Console.WriteLine("{0} is no palindrome!", inputString);
                    }
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a string longer than 2 characters!");
                }
            }
        }
    }
}
