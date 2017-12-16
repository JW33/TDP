using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDocumentParser
{
    public class DocumentParser
    {
        public int VowelCount { get; set; }
        public int ConsonantCount { get; set; }
        public int LetterCount { get; set; }
        public int WordCount { get; set; }
        public int PalindromeCount { get; set; }
        public int PunctuationCount { get; set; }
        public int DigitCount { get; set; }


        public void LoopThroughAllMethods(List<string> FileLines)
        {
            foreach (string s in FileLines)
            {
                GetVowelCount(s);
                GetConsonantCount(s);
                GetLetterCount();
                GetWordCount(s);
                GetPalindromeCount(s);
                GetPunctuationCount(s);
                GetDigitCount(s);
            }
        }

        public void readInFile(string Filename, List<string> FileLines)
        {
            using (StreamReader r = new StreamReader(Filename))
            {
                string Line;

                while ((Line = r.ReadLine()) != null)
                {
                    FileLines.Add(Line);
                }
            }
        }

        private void GetVowelCount(string s)
        {
            int loopCounter;
            for (loopCounter = 0; loopCounter < s.Length; loopCounter++)
            {
                switch (s[loopCounter])
                {
                    case 'a':
                    case 'A':
                    case 'e':
                    case 'E':
                    case 'i':
                    case 'I':
                    case 'o':
                    case 'O':
                    case 'u':
                    case 'U':
                        VowelCount++;
                        break;
                }
            }
        }

        private void GetConsonantCount(string s)
        {
            const string CONSONANTS = "qwrtypsdfghjklzxcvbnmQWRTYPSDFGHJKLZXCVBNM";

            for (int i = 0; i < s.Length; i++)
            {
                for (int x = 0; x < CONSONANTS.Length; x++)
                {
                    if (s[i] == CONSONANTS[x])
                    {
                        ConsonantCount++;
                    }
                }
            }
        }

        private void GetLetterCount()
        {
            //_letterCount = _vowelCount + _consonantCount;
            LetterCount = VowelCount + ConsonantCount;
        }

        private void GetWordCount(string s)
        {
            const string NUMBERS = "1234567890";
            const string PUNCTUATION = "~`!@#$%^&*()_-/+=[]{}|;:'\",.<>?";

            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length >= 1)
            {
                for (int x = 0; x < words.Length; x++)
                {
                    for(int y = 0; y < PUNCTUATION.Length; y++)
                    {
                        for( int z = 0; z < NUMBERS.Length; z++)
                        {
                            if (words[x] != PUNCTUATION[y].ToString() && words[x] != NUMBERS[z].ToString() && words[x] != " ")
                            {
                                WordCount += words.Length;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void GetPalindromeCount(string s)
        {
            ArrayList newArray = new ArrayList();

            for (int x = s.Length - 1; x >= 0; x--)
            {
                newArray.Add(s[x].ToString());
            }

            StringBuilder sString = new StringBuilder();
            foreach (string i in newArray)
            {
                sString.Append(i);
            }

            if (sString.ToString().Equals(s) && s != "" && s != "{" && s != "}")
            {
                PalindromeCount++;
            }
        }

        private void GetPunctuationCount(string s)
        {
            const string PUNCTUATION = "~`!@#$%^&*()_-/+=[]{}|;:'\",.<>?";

            for (int x = 0; x < s.Length; x++)
            {
                for (int y = 0; y < PUNCTUATION.Length; y++)
                {
                    if ((s[x] == PUNCTUATION[y]) && (s[x] != ' '))
                    {
                        PunctuationCount++;
                    }
                }
            }
        }

        private void GetDigitCount(string s)
        {
            const string DIGITS = "0123456789";

            for (int x = 0; x < s.Length; x++)
            {
                for (int y = 0; y < DIGITS.Length; y++)
                {
                    if (s[x] == DIGITS[y])
                    {
                        DigitCount++;
                    }
                }
            }
        }

        public void GetCounts(ref int vowelCount, ref int consonantCount, ref int letterCount, ref int wordCount, ref int palindromeCount, ref int punctuationCount, ref int digitCount)
        {
            vowelCount = VowelCount;
            consonantCount = ConsonantCount;
            letterCount = LetterCount;
            wordCount = WordCount;
            palindromeCount = PalindromeCount;
            punctuationCount = PunctuationCount;
            digitCount = DigitCount;
        }
    }
}
