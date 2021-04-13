using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextAnalysis
{
    public static class Program
    {
        public const string FileCommand = "file=";
        public const string ExitCommand = "exit";
        public static readonly string[] commands = { FileCommand, ExitCommand };
        public static char[] charsToTrim = { ' ', '\'', '"', '/', '\\', ':', '*', '?', '>', '<', '|' };

        public static void Main()
        {
            Console.WriteLine("Task 3.1.2 - Text Analysis");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("To begin analysis type a few word in console or specify path to file.");
                Console.WriteLine(@"To specify type 'file=C:\path\to\your\file.txt'");
                Console.WriteLine("To exit type 'exit'");

                string input = Console.ReadLine();
                string text = input;

                if (input.StartsWith(ExitCommand))
                {
                    break;
                }
                if (input.StartsWith(FileCommand))
                {
                    string path = input.Replace(FileCommand, string.Empty).Trim(charsToTrim);
                    using (StreamReader reader = new StreamReader(path, Encoding.Unicode))
                    {
                        text = reader.ReadToEnd();
                    }
                }

                var words = text.GetWords();
                var analysis = words.GetAnalysis();

                Console.WriteLine("Most Common Words:");
                foreach (var pair in analysis)
                {
                    Console.WriteLine("'{0}' - {1}", pair.Key, pair.Value);
                }
            }
        }
    }
}
