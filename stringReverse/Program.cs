﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    string reverseString = "";
                    for (int i = inputString.Length-1; i >= 0; i--)
                    {
                        reverseString += inputString[i];
                    }
                    Console.WriteLine("Reverse String: {0}", reverseString);
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