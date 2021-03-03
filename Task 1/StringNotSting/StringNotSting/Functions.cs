using System;
using System.Text;

namespace StringNotSting
{
    class Functions
    {
        //Average number of words is not rounding
        public static double AverageLettersInWords(string line)
        {
            int wordsCount = 0, lettersCount = 0;
            bool countingLettersNow = true;
            foreach (char ch in line)
            {
                if (Char.IsLetterOrDigit(ch))
                {
                    lettersCount++;
                    if (!countingLettersNow)
                    {
                        wordsCount++;
                        countingLettersNow = true;
                    }
                }
                else if (countingLettersNow) countingLettersNow = false;
            }
            
            if (lettersCount > 0) wordsCount++;
            else return 0;

            return (double)lettersCount / wordsCount;
        }

        public static string DoubleLetters(string lineA, string lineB)
        {
            StringBuilder lineABuilder = new StringBuilder(lineA);
            StringBuilder lineBBuilder = new StringBuilder(lineB);
            while (lineBBuilder.Length > 0)
            {
                lineABuilder.Replace(lineBBuilder[0].ToString(), lineBBuilder[0].ToString() + lineBBuilder[0]);
                lineBBuilder.Replace(lineBBuilder[0].ToString(), "");
            }
            return lineABuilder.ToString();
        }

        public static int CountLowerWords(string line)
        {
            if (String.IsNullOrEmpty(line)) throw new ArgumentException("The value must be sting with at least one character");

            int lowerCount = Char.IsLower(line[0]) ? 1 : 0;
            bool runningOnLettersNow = true;
            foreach (char ch in line)
            {
                if (Char.IsLetter(ch))
                {
                    if (!runningOnLettersNow)
                    {
                        if (Char.IsLower(ch)) lowerCount++;
                        runningOnLettersNow = true;
                    }
                }
                else if (runningOnLettersNow) runningOnLettersNow = false;
            }

            return lowerCount;
        }

        public static string FirstLetterOfSentenceToUpper(string line)
        {
            StringBuilder output = new StringBuilder();
            bool capitalizeNext = true;

            foreach (var ch in line)
            {
                if (capitalizeNext && char.IsLetter(ch))
                {
                    output.Append(char.ToUpper(ch));
                    capitalizeNext = false;
                    continue;
                }

                if (IsSentenceSeparator(ch)) capitalizeNext = true;

                output.Append(ch);
            }

            return output.ToString();
        }

        public static bool IsSentenceSeparator(char ch)
        {
            foreach (char separator in SentenceSeparators) if (separator == ch) return true;
            return false;
        }

        public static char[] SentenceSeparators = { '.', '?', '!' };
    }
}
