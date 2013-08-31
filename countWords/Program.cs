using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Count Words in a String - Counts the number of individual words in a string. For added complexity read these strings in from a text file and generate a summary.
 * Erste Version: 31.08.2013
 */

namespace countWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "This is my test sentence.";
            //Console.WriteLine("'{0}' without punctuation: '{1}'", sentence, sentence.removePunctuation());
            Console.WriteLine("'{0}' consists of {1} words.", sentence, sentence.wordCount());
            Console.WriteLine("'{0}' consists of the following {1} words:", sentence, sentence.wordCount());
            foreach (String str in sentence.wordList())
            {
                Console.WriteLine("- {0}", str);
            }
            Console.ReadKey();
        }
    }

    static class Extension
    {
        // character to seperate words
        static char[] sep = {' '};

        // punctuation characters
        static char[] punc = { '-', '.', ',' };

        // return the number of words in the string
        public static int wordCount(this string str)
        {
            return str.Split(sep).Count();
        }

        // return a list of words in the string
        public static List<string> wordList(this string str)
        {
            return str.Split(sep).ToList();
        }

        /*
         * Remove all punctuation to get a cleaner display
         * Not working right now
        public static string removePunctuation(this string str)
        {
            string strCopy = "";
            foreach (char c in str)
            {
                strCopy += c;
            }
            List<int> punctuationIndexes = new List<int>();
            for (int i = 0; i < strCopy.Length; i++)
            {
                if (punc.Contains(str[i]))
                {
                    if (i == str.Length - 1)
                    {
                        punctuationIndexes.Add(i);
                    }
                    else if (str[i + 1].Equals(" "))
                    {
                        punctuationIndexes.Add(i);
                    }
                    else
                    {
                        char tmp = str.ElementAt(i);
                        tmp = ' ';
                    }
                }
            }
            int removed = 0;
            foreach (int i in punctuationIndexes)
            {
                str.Remove(i - removed, 1);
                removed++;
            }
            return str;
        }
         */
    }
}
