using System;
using System.Collections.Generic;

namespace CustomPaint
{
    /// <summary>
    /// Enumeration of all available types of figures.
    /// </summary>
    enum FigureTypes 
    {
        Circle = 1,
        Round = 2, 
        Ring = 3,
        Rectangle = 4,
        Square = 5,
        Triangle = 6
    }

    /// <summary>
    /// Enumeration of all actions that available to perform in figure editing menu.
    /// </summary>
    enum Actions
    { 
        ChooseUser = 0,
        Show = 1,
        Add = 2,
        Remove = 3,
        Clear = 4
    }

    /// <summary>
    /// Enumeration of all actions that available to perform in user editing-choosing menu.
    /// </summary>
    enum UserActions
    {
        Exit = 0,
        Show = 1,
        Add = 2,
        Remove = 3,
        Clear = 4,
        Choose = 5
    }

    /// <summary>
    /// Static class that provides primary functionality.
    /// </summary>
    static class Tools
    {
        /// <summary>
        /// Method that creates figure by given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Figure of a specified type</returns>
        public static Figure CreateFigure(FigureTypes type)
        {
            switch (type)
            {
                default:
                    return null;
                case FigureTypes.Circle:
                    {
                        Console.WriteLine("Enter circle center coordinates (separated by a space):");
                        Point center = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter circle radius:");
                        double radius = ConsoleExtensions.InputDouble(number => number > 0);

                        return new Circle(center, radius);
                    }
                case FigureTypes.Round:
                    {
                        Console.WriteLine("Enter round center coordinates (separated by a space):");
                        Point center = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter round radius:");
                        double radius = ConsoleExtensions.InputDouble(number => number > 0);

                        return new Round(center, radius);
                    }
                case FigureTypes.Ring:
                    {
                        Console.WriteLine("Enter ring center coordinates (separated by a space):");
                        Point center = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter ring inner radius:");
                        double inner_radius = ConsoleExtensions.InputDouble(number => number > 0);
                        Console.WriteLine("Enter ring outer radius:");
                        double outer_radius = ConsoleExtensions.InputDouble(number => number > 0);

                        try
                        {
                            return new Ring(center, inner_radius, outer_radius);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return null;
                        }
                    }
                case FigureTypes.Rectangle:
                    {
                        Console.WriteLine("Enter rectangle position (top-left corner) coordinates (separated by a space):");
                        Point position = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter rectangle side A:");
                        LineSegment side_a = new LineSegment(ConsoleExtensions.InputDouble(number => number > 0));
                        Console.WriteLine("Enter rectangle side B:");
                        LineSegment side_b = new LineSegment(ConsoleExtensions.InputDouble(number => number > 0));

                        return new Rectangle(position, side_a, side_b);
                    }
                case FigureTypes.Square:
                    {
                        Console.WriteLine("Enter square position (top-left corner) coordinates (separated by a space):");
                        Point position = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter square side:");
                        LineSegment side = new LineSegment(ConsoleExtensions.InputDouble(number => number > 0));

                        return new Square(position, side);
                    }
                case FigureTypes.Triangle:
                    {
                        Console.WriteLine("Enter triangle verticle A position coordinates (separated by a space):");
                        Point verticle_a = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter triangle verticle B position coordinates (separated by a space):");
                        Point verticle_b = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter triangle verticle C position coordinates (separated by a space):");
                        Point verticle_c = ConsoleExtensions.InputPoint();

                        return new Triangle(verticle_a, verticle_b, verticle_c);
                    }
            }
        }

        /// <summary>
        /// Method that shows List items in a prespecified format
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="items">List from System.Collections.Generic</param>
        public static void ShowList<T>(List<T> items)
        {
            int separator_width = 14;
            if (items is null || items?.Count == 0)
            {
                Console.WriteLine("Nothing found.");
                return;
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', separator_width));
            Console.WriteLine("TOTAL COUNT: {0}", items.Count);
        }

        /// <summary>
        /// Method that provides functionality of adding and removing usernames to the given list.
        /// </summary>
        /// <param name="usernames">List of usernames</param>
        /// <returns>Empty string if user chose to exit OR Username that user chose.</returns>
        public static string ChooseUser(List<string> usernames)
        {
            Console.WriteLine("Available actions:");
            Console.WriteLine("{0} to Show all users", (int)UserActions.Show);
            Console.WriteLine("{0} to Add a new user", (int)UserActions.Add);
            Console.WriteLine("{0} to Remove user", (int)UserActions.Remove);
            Console.WriteLine("{0} to Remove all users", (int)UserActions.Clear);
            Console.WriteLine("{0} to Choose a user from list", (int)UserActions.Choose);
            Console.WriteLine("{0} to Exit", (int)UserActions.Exit);

            while (true)
            {
                Console.Write("{0}Enter action number: ", Environment.NewLine);
                switch (ConsoleExtensions.InputEnum<UserActions>())
                {
                    default:
                        Console.WriteLine("Action with entered number doesn't exist.");
                        break;
                    case UserActions.Exit:
                        return string.Empty;
                        break;
                    case UserActions.Show:
                        {
                            Console.WriteLine("Users list: ");
                            ShowList(usernames);
                        }
                        break;
                    case UserActions.Add:
                        {
                            Console.Write("Enter a new user's name: ");
                            string username = ConsoleExtensions.InputString();
                            usernames.Add(username);
                            Console.WriteLine("User \"{0}\" added successfully", username);
                        }
                        break;
                    case UserActions.Remove:
                        {
                            Console.Write("Enter a user's name to remove: ");
                            string username = ConsoleExtensions.InputString();
                            if (ConsoleExtensions.RequestConfirmation("Are you sure?"))
                            {
                                int total_count = usernames.Count;
                                usernames.Remove(username);
                                if (total_count > usernames.Count)
                                {
                                    Console.WriteLine("User \"{0}\" removed successfully", username);
                                }
                                else
                                {
                                    Console.WriteLine("User \"{0}\" not found", username);
                                }
                            }
                        }
                        break;
                    case UserActions.Clear:
                        {
                            if (ConsoleExtensions.RequestConfirmation("Are you sure?"))
                            {
                                usernames.Clear();
                            }
                        }
                        break;
                    case UserActions.Choose:
                        {
                            if (usernames.Count == 0) Console.WriteLine("To choose a user, add it to the list first.");
                            else 
                            {
                                Console.WriteLine("Enter a user's name from list: ");
                                string username = ConsoleExtensions.InputString();
                                if (usernames.Contains(username)) return username;
                                else Console.WriteLine("User \"{0}\" not found", username);
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Method that provides functionality of adding and removing figures to the given list.
        /// </summary>
        /// <param name="figures">List of figures</param>
        /// <param name="username">Username to contact with.</param>
        public static void ShowPaintMenu(List<Figure> figures, string username)
        {
            Console.WriteLine("{0}Hello, {1}! Choose from actions below:", Environment.NewLine, username);
            Console.WriteLine("{0} to Show all figures", (int)Actions.Show);
            Console.WriteLine("{0} to Add a new figure", (int)Actions.Add);
            Console.WriteLine("{0} to Remove figure", (int)Actions.Remove);
            Console.WriteLine("{0} to Remove all figures", (int)Actions.Clear);
            Console.WriteLine("{0} to Choose another user or exit", (int)Actions.ChooseUser);

            while (true)
            {
                Console.Write("{0}{1}, please enter action number: ", Environment.NewLine, username);
                switch (ConsoleExtensions.InputEnum<Actions>())
                {
                    default:
                        Console.WriteLine("Action with entered number doesn't exist.");
                        break;
                    case Actions.ChooseUser:
                        return;
                    case Actions.Show:
                        {
                            Console.WriteLine("Figures list: ");
                            ShowList(figures);
                        }
                        break;
                    case Actions.Add:
                        {
                            string pattern = "{0} - {1}";
                            Console.WriteLine("Available figure types:");
                            Console.WriteLine(pattern, (int)FigureTypes.Circle, FigureTypes.Circle);
                            Console.WriteLine(pattern, (int)FigureTypes.Round, FigureTypes.Round);
                            Console.WriteLine(pattern, (int)FigureTypes.Ring, FigureTypes.Ring);
                            Console.WriteLine(pattern, (int)FigureTypes.Rectangle, FigureTypes.Rectangle);
                            Console.WriteLine(pattern, (int)FigureTypes.Square, FigureTypes.Square);
                            Console.WriteLine(pattern, (int)FigureTypes.Triangle, FigureTypes.Triangle);

                            Console.Write("Enter Figure type number to create a figure: ");
                            Figure figure = CreateFigure(ConsoleExtensions.InputEnum<FigureTypes>());
                            if (figure is null)
                            {
                                Console.WriteLine("Nothing was created.");
                            }
                            else
                            {
                                figures.Add(figure);
                                Console.WriteLine("Figure {0} created and added successfully", figure.Type);
                            }
                        }
                        break;
                    case Actions.Remove:
                        {
                            Console.Write("Enter a fidures's ID to remove: ");
                            int id = ConsoleExtensions.InputInt32();
                            if (ConsoleExtensions.RequestConfirmation("Are you sure?"))
                            {
                                int total_count = figures.Count;
                                figures.RemoveAll(figure => figure.Id == id);
                                if (total_count > figures.Count)
                                {
                                    Console.WriteLine("Figure with ID {0} removed successfully", id);
                                }
                                else
                                {
                                    Console.WriteLine("Figure with ID {0} not found", id);
                                }
                            }
                        }
                        break;
                    case Actions.Clear:
                        {
                            if (ConsoleExtensions.RequestConfirmation("Are you sure?"))
                            {
                                figures.Clear();
                            }
                        }
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Static class that provides additionals console tools.
    /// </summary>
    static class ConsoleExtensions
    {
        /// <summary>
        /// Method that returns user decision of a given question in a logical value.
        /// </summary>
        /// <param name="question">Question to ask.</param>
        /// <returns>Logical value of a decision.</returns>
        public static bool RequestConfirmation(string question)
        {
            Console.Write("{0} > ", question);
            string line = Console.ReadLine();
            if (line == string.Empty || line.ToLower() == "y") return true;
            return false;
        }

        /// <summary>
        /// Method that gets user input as a string value.
        /// </summary>
        /// <returns>Non-empty and non-whitespace user-entered string.</returns>
        public static string InputString()
        {
            string line;
            bool correct_input;
            do
            {
                line = Console.ReadLine();
                correct_input = line != string.Empty && !string.IsNullOrWhiteSpace(line);
                if (!correct_input) Console.WriteLine("Incorrect input. Please, try again.");
            } while (!correct_input);
            return line;
        }

        /// <summary>
        /// Method that gets user input as Enumeration value.
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <returns>Enumeration item of type T</returns>
        public static T InputEnum<T>() where T: struct
        {
            string line;
            T enum_value;
            bool converted_successfully;
            do
            {
                line = Console.ReadLine();
                converted_successfully = Enum.TryParse<T>(line, out enum_value);
                if (!converted_successfully) Console.WriteLine("Incorrect input. Please, try again.");
            } while (!converted_successfully);
            return enum_value;
        }

        /// <summary>
        /// Method that gets user input as Int32 value.
        /// </summary>
        /// <returns>User-entered integer.</returns>
        public static int InputInt32()
        {
            string line;
            int int32_value;
            bool converted_successfully;
            do
            {
                line = Console.ReadLine();
                converted_successfully = int.TryParse(line, out int32_value);
                if (!converted_successfully) Console.WriteLine("Incorrect input. Please, try again.");
            } while (!converted_successfully);
            return int32_value;
        }

        /// <summary>
        /// Method that gets user input as Double value, filtered by a given predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>User-entered integer that satisfies a given predicate.</returns>
        public static double InputDouble(Predicate<double> predicate)
        {
            string line;
            double double_value;
            bool converted_successfully;
            do
            {
                line = Console.ReadLine();
                converted_successfully = double.TryParse(line, out double_value) && predicate.Invoke(double_value);
                if (!converted_successfully) Console.WriteLine("Incorrect input. Please, try again.");
            } while (!converted_successfully);
            return double_value;
        }

        /// <summary>
        /// Method that gets user input as value of Point structure.
        /// </summary>
        /// <returns>User-entered Point.</returns>
        public static Point InputPoint()
        {
            string[] line;
            double[] double_values = new double[2];
            bool converted_successfully;
            char[] separators = { ' ' };
            do
            {
                line = Console.ReadLine().Split(separators, 2, StringSplitOptions.RemoveEmptyEntries);
                converted_successfully = line.Length == 2 && double.TryParse(line[0], out double_values[0]) && double.TryParse(line[1], out double_values[1]);
                if (!converted_successfully) Console.WriteLine("Incorrect input. Please, try again.");
            } while (!converted_successfully);
            return new Point(double_values[0], double_values[1]);
        }
    }
}