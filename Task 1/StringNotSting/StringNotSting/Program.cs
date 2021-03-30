namespace StringNotSting
{
    using System;

    public static class Program
    {
        // Entry point
        public static void Main(string[] args)
        {
            Console.WriteLine("1.2 - String not Sting");
            while (true)
            {
                Console.Write("Enter task number (0 - if you want to exit) > ");
                try
                {
                    int input = Functions.InputInt32();
                    switch (input)
                    {
                        default: 
                            Console.WriteLine("You've entered non-existent task number."); 
                            break;
                        case 0:
                            return;
                        case 1:
                            Program1();
                            break;
                        case 2:
                            Program2();
                            break;
                        case 3:
                            Program3();
                            break;
                        case 4:
                            Program4();
                            break;
                    }

                    Console.WriteLine();
                }
                catch (Exception e)
                { 
                    Console.WriteLine("An error occurred: {0}", e.Message);
                }
            }
        }

        // Methods
        public static void Program1()
        {
            Console.WriteLine("Task #1 - Averages");
            
            Console.Write("Enter string value > ");
            Console.WriteLine("Average word length = {0:n1}", Functions.AverageLettersInWords(Console.ReadLine()));
        }

        public static void Program2()
        {
            Console.WriteLine("Task #2 - Doubler");

            Console.Write("Enter string value #1 > ");
            string lineA = Console.ReadLine();
            Console.Write("Enter string value #2 > ");
            string lineB = Console.ReadLine();
            Console.WriteLine(Functions.DoubleLetters(lineA, lineB));
        }

        public static void Program3()
        {
            Console.WriteLine("Task #3 - Lowercase");

            Console.Write("Enter string value > ");
            Console.Write("Number of words starting with lowercase letter = {0}", Functions.CountLowerWords(Console.ReadLine()));
        }

        public static void Program4()
        {
            Console.WriteLine("Task #4 - Validator");

            Console.Write("Enter string value > ");
            Console.WriteLine(Functions.FirstLetterOfSentenceToUpper(Console.ReadLine()));
        }
    }
}