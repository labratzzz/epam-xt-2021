using System;

namespace TheMagnificientTen
{
    static class Functions
    {
        public static int RectangleSqaure(int a, int b)
        {
            if (a <= 0 || b <= 0) throw new ArgumentException("Given arguments must be greater than zero");
            return a * b;
        }

        public static int SumOfNumbers(int limit, params int[] numbers)
        {
            if (limit <= 0) throw new ArgumentException("This param must be greater than zero", "limit");
            if (numbers.Length == 0) throw new ArgumentException("At least one number must be specified", "numbers");
            foreach (int number in numbers) if (number <= 0) throw new ArgumentException("This param must be greater than zero", "numbers");
            
            int result = 0;
            for (int i = 0; i < limit; i++)
            {
                checked 
                {
                    foreach (int number in numbers)
                    { 
                        if (i % number == 0) result += i;
                    }
                }
            }
            return result;
        }   

        public static char Symb { get; set; } = '*';

        public static void DrawRightTriange(int height)
        {
            if (height <= 0) throw new ArgumentException("This param must be greater than zero", "height");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < i + 1; j++) Console.Write(Symb);
                Console.WriteLine();
            }
        }

        public static void DrawIsoscelesTriangle(int height, int offset = 0)
        {
            if (height <= 0) throw new ArgumentException("This param must be greater than zero", "height");
            if (offset < 0) throw new ArgumentException("This param must be equal or greater than zero", "offset");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < offset + height - i - 1; j++) Console.Write(' ');
                for (int j = 0; j < 1 + (i * 2); j++) Console.Write(Symb);
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
            for (int i = 1; i < array.Length; i++) if (max < array[i]) max = array[i];
            return max;
        }

        public static int GetMinElement(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++) if (min > array[i]) min = array[i];
            return min;
        }

        public static int[] Generate1DArray(int length, int min_limit, int max_limit)
        {
            Random r = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++) array[i] = r.Next(min_limit, max_limit);
            return array;
        }

        public static int[,] Generate2DArray(int dimension_1, int dimension_2, int min_limit, int max_limit)
        {
            Random r = new Random();
            int[,] array = new int[dimension_1, dimension_2];
            for (int i = 0; i < dimension_1; i++)
            {
                for (int j = 0; j < dimension_1; j++)
                {
                    array[i, j] = r.Next(min_limit, max_limit);
                }
            }
            return array;
        }

        public static int[,,] Generate3DArray(int dimension_1, int dimension_2, int dimension_3, int min_limit, int max_limit)
        {
            Random r = new Random();
            int[,,] array = new int[dimension_1, dimension_2, dimension_3];
            for (int i = 0; i < dimension_1; i++)
            {
                for (int j = 0; j < dimension_1; j++)
                {
                    for (int k = 0; k < dimension_3; k++)
                    {
                        array[i, j, k] = r.Next(min_limit, max_limit);
                    }
                }
            }
            return array;
        }

        public static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++) Console.Write("{0,2} ", array[i]);
            Console.WriteLine();
        }

        public static void ShowArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0,2} ", array[i, j]);
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
                        if (array[d1, d2, d3] > 0) array[d1, d2, d3] = 0;
                    }
                }
            }
            return array;
        }


        public static int NonNegativeSum(int[] array)
        {
            int sum = 0;
            foreach (int element in array) if (element >= 0) sum += element;
            return sum;
        }

        public static int EvenSum(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int step = (i % 2 == 0) ? 1 : 2;
                for (int j = 0; j < array.GetLength(1); j += step)
                {
                    sum += array[i, j];
                }
            }
            return sum;
        }

        public static int InputInt32()
        {
            int result;
            while (!Int32.TryParse(Console.ReadLine(), out result)) Console.Write("You've entered not a number. Try again > ");
            return result;
        }

        public static string Status((string, bool)[] parameters)
        {
            string status = "";
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].Item2) status += parameters[i].Item1 + ", ";  
            }
            return (String.IsNullOrEmpty(status)) ? "None" : status; 
        }
    }
}
