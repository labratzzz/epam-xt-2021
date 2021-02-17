using System;

namespace TheMagnificientTen
{
    static class UsefulFunctions
    {
        /// <summary>
        /// Returns square of imaginary rectangle by given arguments
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when a or b limit is less than zero</exception>
        /// <param name="a">Side a</param>
        /// <param name="b">Side b</param>
        /// <returns>Square of imaginary rectangle expressed in System.Double</returns>
        public static Double RectangleSquare(Double a, Double b)
        {
            if (a <= 0 || b <= 0) throw new ArgumentException();
            return a * b;
        }

        /// <summary>
        /// Returns square of imaginary rectangle by given arguments
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when a or b is less than zero</exception>
        /// <param name="a">Side a</param>
        /// <param name="b">Side b</param>
        /// <returns>Square of imaginary rectangle expressed in System.Int32</returns>
        public static int RectangleSqaure(int a, int b)
        {
            if (a <= 0 || b <= 0) throw new ArgumentException("Given arguments must be greater than zero");
            return a * b;
        }

        /// <summary>
        /// Returns sum of numbers that are multiple of 3 of 5 in range from 1 to given limit
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when limit is less than zero</exception>
        /// <param name="limit">Limit of range</param>
        /// <returns>Sum of numbers that are multiple of 3 of 5 expressed in System.Int32</returns>
        public static int SumOfNumbers(int limit)
        {
            if (limit < 1) throw new ArgumentException("This param must be greater than zero", "limit");
            int result = 0;
            for (int i = 0; i < limit; i++) checked { if (i % 3 == 0 || i % 5 == 0) result += i; }
            return result;
        }   
    }

    static class ConsoleDrawing
    {
        public static char Symb { get; set; } = '*';

        /// <summary>
        /// Draws right triangle in Console 
        /// </summary>
        /// <param name="height">Height sets the height of triangle in lines</param>
        public static void DrawRightTriange(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < i + 1; j++) Console.Write(Symb);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Draws isosceles triangle in Console 
        /// </summary>
        /// <param name="height">Height sets the height of triangle in lines</param>
        public static void DrawIsoscelesTriangle(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height - i - 1; j++) Console.Write(' ');
                for (int j = 0; j < 1 + (i * 2); j++) Console.Write(Symb);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Draws X-Mas tree in Console 
        /// </summary>
        /// <param name="height">Height sets the number of X-Mas tree segments</param>
        public static void DrawXmasTree(int height)
        {
            for (int level = 1; level <= height; level++)
            {
                for (int i = 0; i < level; i++)
                {
                    for (int j = 0; j < height - i - 1; j++) Console.Write(' ');
                    for (int j = 0; j < 1 + (i * 2); j++) Console.Write(Symb);
                    Console.WriteLine();
                }
            }
        }
    }
}
