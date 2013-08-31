using System;
/*
 * Einfaches Programm, das einen eingegebenen String umdreht
 * Erste Version: 28.08.2013 20:18
 */ 

namespace stringReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter string: ");
                string inputString = Console.ReadLine();
                if (!inputString.Equals(""))
                {
                    // we juse an extension method to realise the reversing (fancy, yay!)
                    Console.WriteLine("Reverse String: {0}", inputString.reverseString());
                    break;
                }
                else
                {
                    Console.WriteLine("Empty String!");
                }
            }
            Console.ReadKey();
        }
    }

    static class stringExtension
    {
        // extension methods need to be public! seems clear... -.-
        public static string reverseString(this string str)
        {
            string reverse = "";
            // just run backwards through the string and return the new string
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverse += str[i];
            }
            return reverse;
        }
    }
}
