using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    public class Program
    {

        public static string vowels = "aeiou";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Pig Latin Translator!");
                Console.Write("Line to translate: ");
                string input = getInput();

                Console.WriteLine();
                Console.WriteLine("Press any key to translate. . .");
                Console.Clear();
                Console.Write("Your translated line: ");
                Console.WriteLine(TranslateWords(input));
                Console.WriteLine();
                Console.Write("Continue? (y/n): ");
                if (Console.ReadLine() == "n") break;
                Console.WriteLine();
                Console.WriteLine("Restarting, press any key to continue. . .");
                Console.ReadKey();
            }
        }


        //Input
        static string getInput()
        {
            return Console.ReadLine();
        }

        //Processing
        public static string TranslateWords(string words)
        {
            string[] arrayOfWords = words.Split(' ');
            StringBuilder finalSentance = new StringBuilder();
            string finalString;
            foreach (string word in arrayOfWords)
            {
                finalSentance.Append(TranslateWord(word) + " ");
            }

            
            finalString = ((finalSentance.ToString()).ToLower()).TrimEnd();
            return CapitalizeFirstLetter(finalString);

            //return finalString;
        }

        public static string CapitalizeFirstLetter(string word)
        {
            string newString = (word[0].ToString()).ToUpper();

            newString += word.Substring(1);
            return newString;
        }
        
        public static string TranslateWord(string word)
        {
            string subStringToKeep;
            string subStringToMove;
            string translatedString = "";

            if (positionOf1stVowel(word) == -1)
            {
                Console.WriteLine("There are no vowels!!! I break.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            subStringToKeep = word.Substring(positionOf1stVowel(word));
            subStringToMove = word.Substring(0, positionOf1stVowel(word));


            translatedString += subStringToKeep;
            translatedString += subStringToMove;

            if (!(vowels.Contains(word[0])))
                translatedString += "ay";
            else translatedString += "way";


            return translatedString;
        }

        static int positionOf1stVowel(string word)
        {
            for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
            {
                if (vowels.Contains(word.ElementAt(letterIndex)))
                {
                    return letterIndex;
                }
            }
            return -1;
        }

        //Output

    }
}
