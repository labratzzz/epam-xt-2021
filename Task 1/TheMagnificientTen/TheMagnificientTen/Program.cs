using System;

namespace TheMagnificientTen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.1 - The Magnificient Ten");
            while (true)
            {
                Console.Write("Enter task number (0 - if you want to exit) > ");
                try 
                {
                    int input = Functions.InputInt32();
                    switch (input)
                    {
                        default: Console.WriteLine("You've entered non-existent task number."); break;
                        case 0: return;
                        case 1: Program1(); break;
                        case 2: Program2(); break;
                        case 3: Program3(); break;
                        case 4: Program4(); break;
                        case 5: Program5(); break;
                        case 6: Program6(); break;
                        case 7: Program7(); break;
                        case 8: Program8(); break;
                        case 9: Program9(); break;
                        case 10: Program10(); break;
                    }
                    Console.WriteLine();
                }
                catch (Exception e) { Console.WriteLine("An error occured: {0}", e.Message); }
            }
        }

        public static void Program1()
        {
            Console.WriteLine("Task #1 - Rectangle");

            int a, b;
            Console.Write("Enter side a > ");
            a = Functions.InputInt32();
            Console.Write("Enter side b > ");
            b = Functions.InputInt32();

            Console.WriteLine("Square of given rectagle = {0}", Functions.RectangleSqaure(a, b));
        }

        public static void Program2()
        {
            Console.WriteLine("Task #2 - Triangle");

            Console.Write("Enter height of triangle > ");
            Functions.DrawRightTriange(Functions.InputInt32());
        }

        public static void Program3()
        {
            Console.WriteLine("Task #3 - Another triangle");

            Console.Write("Enter height of triangle > ");
            Functions.DrawIsoscelesTriangle(Functions.InputInt32());
        }

        public static void Program4()
        {
            Console.WriteLine("Task #4 - X-mas tree");

            Console.Write("Enter height of tree > ");
            Functions.DrawXmasTree(Functions.InputInt32());
        }

        public static void Program5()
        {
            Console.WriteLine("Task #5 - Sum of numbers");

            Console.WriteLine("Sum of numbers: {0}", Functions.SumOfNumbers(1000, new int[] { 3, 5 }));
        }

        public static void Program6()
        {
            Console.WriteLine("Task #6 - Font adjustment");
            
            (string, bool)[] settings = { ("Bold", false), ("Italic", false), ("Underline", false) };
            while (true)
            {
                Console.WriteLine("Font parameters: " + Functions.Status(settings));
                Console.WriteLine("Enter:\n0: exit\n1: bold\n2: italic\n3: underline");
                int input = Functions.InputInt32();
                
                if (input == 0) break;
                if (input <= settings.Length)
                {
                    settings[input - 1].Item2 = !settings[input - 1].Item2;
                }
            }
        }

        public static void Program7()
        {
            Console.WriteLine("Task #7 - Array processing");

            int[] array = Functions.Generate1DArray(15, 1, 100);
            Functions.ShowArray(array);

            Console.WriteLine("Maximum element: {0} | Minimum element: {1}", Functions.GetMaxElement(array), Functions.GetMinElement(array));

            Console.WriteLine("Sorted ascending:");
            Functions.ShowArray(Functions.ArraySort(array, true));
            
            Console.WriteLine("Sorted descending:");
            Functions.ShowArray(Functions.ArraySort(array, false));
        }

        public static void Program8()
        {
            Console.WriteLine("Task #8 - No positive");

            int[,,] array = Functions.Generate3DArray(5, 5, 5, -50, 51);
            Functions.ShowArray(array);

            array = Functions.ClearPositive(array);
            Console.WriteLine("Array with no positives:");
            Functions.ShowArray(array);
        }

        public static void Program9()
        {
            Console.WriteLine("Task #9 - Non-negative sum");

            int[] array = Functions.Generate1DArray(15, -50, 51);
            Functions.ShowArray(array);
            Console.WriteLine("Non-negative sum = {0}", Functions.NonNegativeSum(array));
        }

        public static void Program10()
        {
            Console.WriteLine("Task #10 - 2D array");

            int[,] array = Functions.Generate2DArray(5, 5, 1, 10);
            Functions.ShowArray(array);
            Console.WriteLine("Sum of even elements = {0}", Functions.EvenSum(array));
        }
    }
}