using System;

namespace TheMagnificientTen
{
    static class Functions
    {
        public static char Symb { get; set; } = '*';
        public static int RectangleSqaure(int a, int b)
        {
            if (a <= 0 || b <= 0) throw new ArgumentException("Given arguments must be greater than zero");
            
            return a * b;
        }

        public static int SumOfNumbers(int limit, params int[] checkup_numbers)
        {
            if (limit <= 0) throw new ArgumentException("This param must be greater than zero", "limit");
            if (checkup_numbers.Length == 0) throw new ArgumentException("At least one number must be specified", "numbers");
            foreach (int number in checkup_numbers)
            {
                if (number <= 0) throw new ArgumentException("This param must be greater than zero", "numbers");
            }

            int result = 0;
            for (int number = 0; number < limit; number++)
            {
                checked
                {
                    foreach (int checkup in checkup_numbers)
                    {
                        if (number % checkup == 0)
                        {
                            result += number;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static void DrawRightTriange(int height)
        {
            if (height <= 0) throw new ArgumentException("This param must be greater than zero", "height");

            for (int line = 0; line < height; line++)
            {
                for (int symbWrite = 0; symbWrite < line + 1; symbWrite++)
                {
                    Console.Write(Symb);
                }
                Console.WriteLine();
            }
        }

        public static void DrawIsoscelesTriangle(int height, int offset = 0)
        {
            if (height <= 0) throw new ArgumentException("This param must be greater than zero", "height");
            if (offset < 0) throw new ArgumentException("This param must be equal or greater than zero", "offset");
                
            int gainSymbPerLine = 2;
            for (int line = 0; line < height; line++)
            {
                for (int spaceWrite = 0; spaceWrite < offset + height - line - 1; spaceWrite++)
                {
                    Console.Write(' ');
                }
                for (int symbWrite = 0; symbWrite < 1 + (line * gainSymbPerLine); symbWrite++)
                {
                    Console.Write(Symb);
                }
                Console.WriteLine();
            }
        }

        public static void DrawXmasTree(int height)
        {
            if (height <= 0) throw new ArgumentException("This param must be greater than zero", "height");

            for (int level = 1; level <= height; level++)
            {
                DrawIsoscelesTriangle(level, height - level);
            }
        }

        public static int GetMaxElement(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }
            return max;
        }

        public static int GetMinElement(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }
            return min;
        }

        public static int[] Generate1DArray(int length, int min_limit, int max_limit)
        {
            Random r = new Random();
            int[] array = new int[length];
            for (int d1 = 0; d1 < length; d1++)
            {
                array[d1] = r.Next(min_limit, max_limit);
            }
            return array;
        }

        public static int[,] Generate2DArray(int dimension_1, int dimension_2, int min_limit, int max_limit)
        {
            Random r = new Random();
            int[,] array = new int[dimension_1, dimension_2];
            for (int d1 = 0; d1 < dimension_1; d1++)
            {
                for (int d2 = 0; d2 < dimension_2; d2++)
                {
                    array[d1, d2] = r.Next(min_limit, max_limit);
                }
            }
            return array;
        }

        public static int[,,] Generate3DArray(int dimension_1, int dimension_2, int dimension_3, int min_limit, int max_limit)
        {
            Random r = new Random();
            int[,,] array = new int[dimension_1, dimension_2, dimension_3];
            for (int d1 = 0; d1 < dimension_1; d1++)
            {
                for (int d2 = 0; d2 < dimension_2; d2++)
                {
                    for (int d3 = 0; d3 < dimension_3; d3++)
                    {
                        array[d1, d2, d3] = r.Next(min_limit, max_limit);
                    }
                }
            }
            return array;
        }

        public static void ShowArray(int[] array)
        {
            for (int d1 = 0; d1 < array.Length; d1++)
            {
                Console.Write("{0,2} ", array[d1]);
            }
            Console.WriteLine();
        }

        public static void ShowArray(int[,] array)
        {
            for (int d1 = 0; d1 < array.GetLength(0); d1++)
            {
                for (int d2 = 0; d2 < array.GetLength(1); d2++)
                {
                    Console.Write("{0,2} ", array[d1, d2]);
                }
                Console.WriteLine();
            }
        }

        public static void ShowArray(int[,,] array)
        {
            for (int d1 = 0; d1 < array.GetLength(0); d1++)
            {
                for (int d2 = 0; d2 < array.GetLength(1); d2++)
                {
                    for (int d3 = 0; d3 < array.GetLength(2); d3++)
                    {
                        Console.WriteLine("array[{0}, {1}, {2}] = {3,2}", d1, d2, d3, array[d1, d2, d3]);
                    }
                }
            }
        }

        public static int[] ArraySort(int[] array, bool ascending = true)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length - i; j++)
                {
                    bool check = array[j] < array[j - 1];
                    if (!ascending) check = !check;
                    if (check)
                    {
                        int swap = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = swap;
                    }
                }
            }
            return array;
        }

        public static int[,,] ClearPositive(int[,,] array)
        {
            for (int d1 = 0; d1 < array.GetLength(0); d1++)
            {
                for (int d2 = 0; d2 < array.GetLength(1); d2++)
                {
                    for (int d3 = 0; d3 < array.GetLength(2); d3++)
                    {
                        if (array[d1, d2, d3] > 0)
                        {
                            array[d1, d2, d3] = 0;
                        }
                    }
                }
            }
            return array;
        }

        public static int NonNegativeSum(int[] array)
        {
            int sum = 0;
            foreach (int element in array)
            {
                if (element >= 0)
                {
                    sum += element;
                }
            }
            return sum;
        }

        public static int EvenSum(int[,] array)
        {
            int step = 2;
            int sum = 0;
            for (int d1 = 0; d1 < array.GetLength(0); d1++)
            {
                int start = (d1 % 2 == 0) ? 0 : 1;
                for (int d2 = start; d2 < array.GetLength(1); d2 += step)
                {
                    sum += array[d1, d2];
                }
            }
            return sum;
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

        public static string Status((string, bool)[] parameters)
        {
            string status = string.Empty;
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].Item2)
                {
                    status += parameters[i].Item1 + ", ";
                }
            }
            return (string.IsNullOrEmpty(status)) ? "None" : status; 
        }
    }
}