using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextDocumentParser
{
    class Program
    {
        static int vowelCount = 0;
        static int consonantCount = 0;
        static int letterCount = 0;
        static int wordCount = 0;
        static int palindromeCount = 0;
        static int punctuationCount = 0;
        static int digitCount = 0;

        static void Main(string[] args)
        {
            try
            {
                List<string> FileLines = new List<string>();
                const string Filename = @"C:\Users\JW33\Documents\Misc\testing.txt";
                //const string Filename = @"C:\Users\JW33\Documents\Misc\testingTDP.txt";

                DocumentParser test = new DocumentParser();

                test.readInFile(Filename, FileLines);

                test.LoopThroughAllMethods(FileLines);

                DisplayCounts(test);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DisplayCounts(DocumentParser test)
        {
            test.GetCounts(ref vowelCount, ref consonantCount, ref letterCount, ref wordCount, ref palindromeCount, ref punctuationCount, ref digitCount);

            Console.WriteLine("Number of vowels: " + vowelCount);
            Console.WriteLine();

            Console.WriteLine("Number of consonants: " + consonantCount);
            Console.WriteLine();

            Console.WriteLine("Number of letters: " + letterCount);
            Console.WriteLine();

            Console.WriteLine("Number of words: " + wordCount);
            Console.WriteLine();

            Console.WriteLine("Number of palindromes: " + palindromeCount);
            Console.WriteLine();

            Console.WriteLine("There are " + punctuationCount + " characters of punctuation");
            Console.WriteLine();

            Console.WriteLine("Number of digits: " + digitCount);
            Console.WriteLine();

            Console.WriteLine("---Program Finished---");

            Console.ReadLine();
        }
    }
}
