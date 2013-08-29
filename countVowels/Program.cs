using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Count Vowels - Enter a string and the program counts the number of vowels in the text. For added complexity have it report a sum of each vowel found.
 * Erste Version: 28.08.2013
 * Ich wollte hier mal ein Prädikat ausprobieren -> Zeile 18 / Zeile 26
 * Ich muss mal gucken, ob das Einfügen in das Dictionary irgendwie eleganter geht. Ein Einzeiler wäre schön.
 */
namespace countVowels
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> vokale = new List<char> {'a', 'e', 'i', 'o', 'u'};
            Predicate<char> istVokal = x => vokale.Contains(x);
            SortedDictionary<char, int> vokalZahl = new SortedDictionary<char, int>();
            while (true)
            {
                Console.Write("Enter String: ");
                string inputString = Console.ReadLine();
                if (!inputString.Equals(""))
                {
                    List<char> vokalListe = inputString.ToList<char>().Where(x => istVokal(x)).ToList();
                    vokalListe.ForEach(x =>
                    {
                        if (vokalZahl.ContainsKey(x))
                        {
                            vokalZahl[x]++;
                        }
                        else
                        {
                            vokalZahl.Add(x, 1);
                        }
                    });
                    int vokalSumme = 0;
                    foreach (KeyValuePair<char, int> kvp in vokalZahl)
                    {
                        vokalSumme += kvp.Value;
                        Console.WriteLine("{0} => {1}", kvp.Key, kvp.Value);
                    }
                    Console.WriteLine("Sum of vowels: {0}", vokalSumme);
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
