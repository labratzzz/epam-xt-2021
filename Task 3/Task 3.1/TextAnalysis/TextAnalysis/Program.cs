namespace TextAnalysis
{
    using System;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        // Constants
        private const string FileCommand = "file=";

        private const string ExitCommand = "exit";

        // Fields
        private static char[] charsToTrim = { ' ', '\'', '"', '/', '\\', ':', '*', '?', '>', '<', '|' };

        // Entry point
        public static void Main()
        {
            Console.WriteLine("Task 3.1.2 - Text Analysis");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("To begin analysis type a few words in console or specify path to file.");
                Console.WriteLine(@"To specify file type 'file=C:\path\to\your\file.txt'");
                Console.WriteLine("To exit type 'exit'");

                string input = Console.ReadLine();
                string text = input;

                if (input.StartsWith(ExitCommand) && input.EndsWith(ExitCommand))
                {
                    break;
                }

                if (input.StartsWith(FileCommand))
                {
                    string path = input.Replace(FileCommand, string.Empty).Trim(charsToTrim);
                    try
                    {
                        text = File.ReadAllText(path);
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("File was not found.");
                        continue;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occurred.");
                        continue;
                    }
                }

                var words = text.GetWords();
                if (words.Count() == 0)
                {
                    Console.WriteLine("No words was found");
                    continue;
                }

                var analysis = words.GetAnalysis();

                Console.WriteLine("Most Common Words:");
                foreach (var pair in analysis)
                {
                    Console.WriteLine("'{0}' - {1} occ.", pair.Key, pair.Value);
                }
            }
        }
    }
}
