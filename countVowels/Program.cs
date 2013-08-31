using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Count Vowels - Enter a string and the program counts the number of vowels in the text. For added complexity have it report a sum of each vowel found.
 * Erste Version: 28.08.2013
 * Ich wollte hier mal ein Prädikat ausprobieren 
 * Ich muss mal gucken, ob das Einfügen in das Dictionary irgendwie eleganter geht. Ein Einzeiler wäre schön.
 */
namespace countVowels
{
    class Program
    {
        static void Main(string[] args)
        {
            // list of characters to look for
            List<char> vokale = new List<char> {'a', 'e', 'i', 'o', 'u'};
            // predicate to match a char against our vowel array
            Predicate<char> istVokal = x => vokale.Contains(x);
            // dictionary to hold our results
            SortedDictionary<char, int> vokalZahl = new SortedDictionary<char, int>();
            while (true)
            {
                Console.Write("Enter String: ");
                string inputString = Console.ReadLine();
                if (!inputString.Equals(""))
                {
                    // match our inputString (as a List<char>) against our predicate and put the results into a list
                    List<char> vokalListe = inputString.ToList<char>().Where(x => istVokal(x)).ToList();
                    // run through our list of vowels and put them into the dictionary
                    vokalListe.ForEach(x =>
                    {
                        // if the vowel is already in the dictionary, just increase the value by 1 (the value is the number of occurences in the string)
                        if (vokalZahl.ContainsKey(x))
                        {
                            vokalZahl[x]++;
                        }
                        // if it isn't already in the dictionary, add it and put the value as 1
                        else
                        {
                            vokalZahl.Add(x, 1);
                        }
                    });
                    Console.WriteLine("Sum of vowels: {0}", vokalListe.Count());
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
