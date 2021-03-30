namespace StringNotSting
{
    using System;
    using System.Text;

    public static class Functions
    {
        // Properties
        public static char[] SentenceSeparators { get; set; } = { '.', '?', '!' };

        // Methods
        public static double AverageLettersInWords(string line)
        {
            int wordsCount = 0, lettersCount = 0;

            bool countingLettersNow = true;
            foreach (char character in line)
            {
                if (char.IsLetterOrDigit(character))
                {
                    lettersCount++;
                    if (!countingLettersNow)
                    {
                        wordsCount++;
                        countingLettersNow = true;
                    }
                }
                else if (countingLettersNow)
                {
                    countingLettersNow = false;
                }
            }

            if (lettersCount > 0)
            {
                wordsCount++;
            }
            else
            {
                return 0;
            }

            // Average number of words is not rounding
            return (double)lettersCount / wordsCount;
        }

        public static string DoubleLetters(string lineA, string lineB)
        {
            StringBuilder lineABuilder = new StringBuilder(lineA);
            StringBuilder lineBBuilder = new StringBuilder(lineB);
            while (lineBBuilder.Length > 0)
            {
                lineABuilder.Replace(lineBBuilder[0].ToString(), lineBBuilder[0].ToString() + lineBBuilder[0]);
                lineBBuilder.Replace(lineBBuilder[0].ToString(), string.Empty);
            }

            return lineABuilder.ToString();
        }

        public static int CountLowerWords(string line)
        {
            if (string.IsNullOrEmpty(line)) throw new ArgumentException("The value must be sting with at least one character");

            int lowerCount = 0;
            if (char.IsLower(line[0]))
            {
                lowerCount++;
            }

            bool runningOnLettersNow = true;
            foreach (char character in line)
            {
                if (char.IsLetter(character))
                {
                    if (!runningOnLettersNow)
                    {
                        if (char.IsLower(character))
                        {
                            lowerCount++;
                        }

                        runningOnLettersNow = true;
                    }
                }
                else if (runningOnLettersNow)
                {
                    runningOnLettersNow = false;
                }
            }

            return lowerCount;
        }

        public static string FirstLetterOfSentenceToUpper(string line)
        {
            StringBuilder output = new StringBuilder();
            bool capitalizeNext = true;

            foreach (var character in line)
            {
                if (capitalizeNext && char.IsLetter(character))
                {
                    output.Append(char.ToUpper(character));
                    capitalizeNext = false;
                    continue;
                }

                if (IsSentenceSeparator(character))
                {
                    capitalizeNext = true;
                }

                output.Append(character);
            }

            return output.ToString();
        }

        public static bool IsSentenceSeparator(char character)
        {
            foreach (char separator in SentenceSeparators)
            {
                if (separator == character)
                {
                    return true;
                }
            }

            return false;
        }

        public static int InputInt32()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("You've entered not a number. Try again > ");
            }

            return result;
        }
    }
}