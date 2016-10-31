﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    public class Program
    {

        public static string vowels = "aeiouAEIOU";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Pig Latin Translator!");
                Console.Write("Line to translate: ");
                //super simple method to get the users input.
                string input = getInput();

                Console.WriteLine();
                Console.WriteLine("Press any key to translate. . .");
                Console.Clear();
                Console.Write("Your translated line: ");

                //method to translate the entire sentance and return with a capitalized first letter (all the rest lower)
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

            //build apon this StringBuilder for the final string.
            StringBuilder finalSentance = new StringBuilder();
            string finalString;
            foreach (string word in arrayOfWords)
            {
                finalSentance.Append(TranslateWord(word) + " ");
            }

            //since after every word is a space, we need to trim it.
            //we could lower the 
            finalString = ((finalSentance.ToString()).ToLower()).TrimEnd();
            return CapitalizeFirstLetter(finalString);

            //return finalString;
        }

        public static string CapitalizeFirstLetter(string word)
        {
            //gets the first letter and capitalizes it.
            string newString = (word[0].ToString()).ToUpper();
            
            //takes that first letter and adds the rest of the string starting at position 1 (second letter)
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
                //probably could work on this a little more.. but whatev...
                Console.Clear();
                Console.WriteLine("There are no vowels!!! I break.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            //gets the second half of the word
            subStringToKeep = word.Substring(positionOf1stVowel(word));


            //gets the first "half" of the word
            subStringToMove = word.Substring(0, positionOf1stVowel(word));


            //rearranges the halves.
            translatedString += subStringToKeep;
            translatedString += subStringToMove;


            //adds the way/ay depending on the original words first letter
            if (!(vowels.Contains(word[0])))
                translatedString += "ay";
            else translatedString += "way";


            return translatedString;
        }

        static int positionOf1stVowel(string word)
        {
            //checking each position for a vowel
            for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
            {
                if (vowels.Contains(word.ElementAt(letterIndex)))
                {
                    return letterIndex;
                }
            }
            return -1;
        }
    }
}
