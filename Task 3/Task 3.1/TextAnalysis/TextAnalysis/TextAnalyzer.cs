namespace TextAnalysis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public enum TextAnalyzerCasing
    {
        ToUpper = 0,
        ToLower = 1,
        Original = 2
    }

    public enum TextAnalyzerMode
    {
        OnlyLetters = 0,
        OnlyDigits = 1,
        LettersOrDigits = 2
    }

    public static class TextAnalyzer
    {
        public static IEnumerable<string> GetWords(this string line, TextAnalyzerMode mode = TextAnalyzerMode.OnlyLetters, TextAnalyzerCasing casing = TextAnalyzerCasing.ToLower)
        {
            Predicate<char> IsDesired;
            switch (mode)
            {
                default:
                case TextAnalyzerMode.OnlyLetters:
                    IsDesired = ch => char.IsLetter(ch);
                    break;
                case TextAnalyzerMode.OnlyDigits:
                    IsDesired = ch => char.IsDigit(ch);
                    break;
                case TextAnalyzerMode.LettersOrDigits:
                    IsDesired = ch => char.IsLetterOrDigit(ch);
                    break;
            }
            
            List<string> words = new List<string>();
            int startIndex = 0;
            bool runningOnDesiredNow = false;

            for (int i = 0; i <= line.Length; i++) // TODO String.Empty returns one word
            {
                if (i < line.Length && IsDesired.Invoke(line[i]) )
                {
                    if (!runningOnDesiredNow)
                    {
                        startIndex = i;
                        runningOnDesiredNow = true;
                    }
                }
                else if (i >= line.Length || runningOnDesiredNow)
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