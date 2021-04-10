namespace WeakestLink
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        // Entry point
        public static void Main()
        {
            Console.WriteLine("Task 3.1.1 - Weakest Link");

            while (true)
            {
                Console.WriteLine();

                Console.Write("Enter number of people in circle > ");
                int circleLength = Extensions.GetInt32(Console.ReadLine, Console.WriteLine, value => value > 0);

                Console.Write("Enter the number of person that will be crossed out on every round > ");
                int nthPerson = Extensions.GetInt32(Console.ReadLine, Console.WriteLine, value => value > 0);

                Console.WriteLine();
                StartCountingGame(circleLength, nthPerson);
            }
        }

        // Methods
        public static List<int> GenerateInt32List(int length)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < length;)
            {
                list.Add(++i);
            }

            return list;
        }

        public static void StartCountingGame(int circleLength, int nthPerson)
        {
            if (circleLength <= 0) throw new ArgumentException(nameof(circleLength));
            if (nthPerson <= 0) throw new ArgumentException(nameof(nthPerson));

            int increment = nthPerson - 1;
            List<int> listOfPersons = GenerateInt32List(circleLength);
            Console.WriteLine("Generated circle of people. Starting to cross out every {0}th person.", nthPerson);
            
            int roundNumber = 1;
            int pointer = 0;
            while (listOfPersons.Count >= nthPerson)
            {
                pointer = GetNextIndex(listOfPersons.Count, pointer + increment);
                int removedPerson = listOfPersons[pointer];
                listOfPersons.RemoveAt(pointer);

                Console.WriteLine(
                    "Round {0}. Person with number {1} was crossed out. People remaining: {2}", 
                    roundNumber++,
                    removedPerson,
                    listOfPersons.Count);
            }

            Console.WriteLine("Game over. Unable to cross out more people.");         
        }

        public static int GetNextIndex(int length, int index)
        {
            if (length < 1) throw new ArgumentException(nameof(length));
            if (index < 0) throw new ArgumentException(nameof(index));

            return (index >= length) ? index - length : index;
        }
    }
}