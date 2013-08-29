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
}
