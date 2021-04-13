namespace CustomPaint
{
    using System;

    /// <summary>
    /// Static class that provides additional console tools.
    /// </summary>
    public static class ConsoleExtensions
    {
        // Methods

        /// <summary>
        /// Method that returns user decision of a given question in a logical value.
        /// </summary>
        /// <param name="question">Question to ask.</param>
        /// <returns>Logical value of a decision.</returns>
        public static bool RequestConfirmation(string question)
        {
            Console.Write("{0} > ", question);
            string line = Console.ReadLine();

            return line == string.Empty || line.ToLower() == "y";
        }

        /// <summary>
        /// Method that gets user input as a string value.
        /// </summary>
        /// <returns>Non-empty and non-whitespace user-entered string.</returns>
        public static string InputString()
        {
            string line;
            bool correctInput;
            
            do
            {
                line = Console.ReadLine();
                correctInput = 
                    line != string.Empty 
                    && !string.IsNullOrWhiteSpace(line);
                if (!correctInput)
                {
                    Console.WriteLine("Incorrect input. Please, try again.");
                }
            } 
            while (!correctInput);

            return line;
        }

        /// <summary>
        /// Method that gets user input as Enumeration value.
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <returns>Enumeration item of type T</returns>
        public static T InputEnum<T>() where T : struct
        {
            string line;
            T enum_value;
            bool convertedSuccessfully;

            do
            {
                line = Console.ReadLine();
                convertedSuccessfully = Enum.TryParse<T>(line, out enum_value);
                if (!convertedSuccessfully)
                {
                    Console.WriteLine("Incorrect input. Please, try again.");
                }
            } 
            while (!convertedSuccessfully);

            return enum_value;
        }

        /// <summary>
        /// Method that gets user input as Int32 value.
        /// </summary>
        /// <returns>User-entered integer.</returns>
        public static int InputInt32()
        {
            string line;
            int int32Value;
            bool convertedSuccessfully;

            do
            {
                line = Console.ReadLine();
                convertedSuccessfully = int.TryParse(line, out int32Value);
                if (!convertedSuccessfully)
                {
                    Console.WriteLine("Incorrect input. Please, try again.");
                }
            } 
            while (!convertedSuccessfully);
                        
            return int32Value;
        }

        /// <summary>
        /// Method that gets user input as Double value, filtered by a given predicate.
        /// </summary>
        /// <param name="predicate">Predicate for filtering input.</param>
        /// <returns>User-entered integer that satisfies a given predicate.</returns>
        public static double InputDouble(Predicate<double> predicate)
        {
            string line;
            double doubleValue;
            bool convertedSuccessfully;
            
            do
            {
                line = Console.ReadLine();
                convertedSuccessfully = 
                    double.TryParse(line, out doubleValue) 
                    && predicate.Invoke(doubleValue);
                if (!convertedSuccessfully)
                {
                    Console.WriteLine("Incorrect input. Please, try again.");
                }
            } 
            while (!convertedSuccessfully);
            
            return doubleValue;
        }

        /// <summary>
        /// Method that gets user input as value of Point structure.
        /// </summary>
        /// <returns>User-entered Point.</returns>
        public static Point InputPoint()
        {
            string[] line;
            double[] doubleValues = new double[2];
            bool convertedSuccessfully;
            char[] separators = { ' ' };

            do
            {
                line = Console.ReadLine().Split(separators, 2, StringSplitOptions.RemoveEmptyEntries);
                convertedSuccessfully = 
                    line.Length == 2 
                    && double.TryParse(line[0], out doubleValues[0]) 
                    && double.TryParse(line[1], out doubleValues[1]);
                if (!convertedSuccessfully)
                {
                    Console.WriteLine("Incorrect input. Please, try again.");
                }
            } 
            while (!convertedSuccessfully);

            return new Point(doubleValues[0], doubleValues[1]);
        }
    }
}