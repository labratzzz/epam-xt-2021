namespace TextAnalysis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TextAnalyzer
    {
        public static IEnumerable<string> GetWords(this string line, TextAnalyzerMode mode = TextAnalyzerMode.OnlyLetters, TextAnalyzerCasing casing = TextAnalyzerCasing.ToLower)
        {
            Predicate<char> isDesired;
            switch (mode)
            {
                default:
                case TextAnalyzerMode.OnlyLetters:
                    isDesired = ch => char.IsLetter(ch);
                    break;
                case TextAnalyzerMode.OnlyDigits:
                    isDesired = ch => char.IsDigit(ch);
                    break;
                case TextAnalyzerMode.LettersOrDigits:
                    isDesired = ch => char.IsLetterOrDigit(ch);
                    break;
            }
            
            List<string> words = new List<string>();
            int startIndex = 0;
            bool runningOnDesiredNow = false;

            for (int i = 0; i <= line.Length; i++)
            {
                if (i < line.Length && isDesired.Invoke(line[i]))
                {
                    if (!runningOnDesiredNow)
                    {
                        startIndex = i;
                        runningOnDesiredNow = true;
                    }
                }
                else if (runningOnDesiredNow)
                {
                    string word = line.Substring(startIndex, i - startIndex);

                    switch (casing)
                    {
                        default:
                        case TextAnalyzerCasing.Original:
                            break;
                        case TextAnalyzerCasing.ToUpper:
                            word = word.ToUpper();
                            break;
                        case TextAnalyzerCasing.ToLower:
                            word = word.ToLower();
                            break;
                    }

                    words.Add(word);

                    runningOnDesiredNow = false;
                }
                else if (i >= line.Length) 
                {
                    break;
                }
            }

            return words;
        }

        public static IDictionary<string, int> GetAnalysis(this IEnumerable<string> words)
        {
            var analysis = words.GroupBy(w => w)
                .Select(g => new { word = g.Key, quantity = g.Count() })
                .OrderByDescending(g => g.quantity)
                .ToDictionary(g => g.word, g => g.quantity);

            return analysis;
        }
    }
}