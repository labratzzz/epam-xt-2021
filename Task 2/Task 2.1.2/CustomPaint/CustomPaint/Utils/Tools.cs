namespace CustomPaint.Utils
{
    using System;
    using System.Collections.Generic;
    using CustomPaint.Entities;
    using CustomPaint.Enums;

    /// <summary>
    /// Static class that provides primary functionality.
    /// </summary>
    public static class Tools
    {
        // Methods

        /// <summary>
        /// Method that creates figure by given type
        /// </summary>
        /// <param name="type">Type of figure</param>
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
                        double innerRadius = ConsoleExtensions.InputDouble(number => number > 0);
                        Console.WriteLine("Enter ring outer radius:");
                        double outerRadius = ConsoleExtensions.InputDouble(number => number > 0);

                        try
                        {
                            return new Ring(center, innerRadius, outerRadius);
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
                        LineSegment sideA = new LineSegment(ConsoleExtensions.InputDouble(number => number > 0));
                        Console.WriteLine("Enter rectangle side B:");
                        LineSegment sideB = new LineSegment(ConsoleExtensions.InputDouble(number => number > 0));

                        return new Rectangle(position, sideA, sideB);
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
                        Point verticleA = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter triangle verticle B position coordinates (separated by a space):");
                        Point verticleB = ConsoleExtensions.InputPoint();
                        Console.WriteLine("Enter triangle verticle C position coordinates (separated by a space):");
                        Point verticleC = ConsoleExtensions.InputPoint();

                        return new Triangle(verticleA, verticleB, verticleC);
                    }
            }
        }

        /// <summary>
        /// Method that shows List items in a pre-specified format
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="items">List from System.Collections.Generic</param>
        public static void ShowList<T>(List<T> items)
        {
            int separatorWidth = 14;

            if (items is null || items?.Count == 0)
            {
                Console.WriteLine("Nothing found.");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', separatorWidth));
            Console.WriteLine("TOTAL COUNT: {0}", items.Count);
        }

        /// <summary>
        /// Method that provides functionality of adding and removing usernames to the given list.
        /// </summary>
        /// <param name="users">List of usernames</param>
        /// <returns>Empty string if user chose to exit OR Username that user chose.</returns>
        public static User ChooseUser(List<User> users)
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
                        {
                            Console.WriteLine("Action with entered number doesn't exist.");
                        }

                        break;
                    case UserActions.Exit:
                        return null;
                    case UserActions.Show:
                        {
                            Console.WriteLine("Users list: ");
                            ShowList(users);
                        }

                        break;
                    case UserActions.Add:
                        {
                            Console.Write("Enter a new user's name: ");
                            string username = ConsoleExtensions.InputString();
                            users.Add(new User(username));
                            Console.WriteLine("User \"{0}\" added successfully", username);
                        }

                        break;
                    case UserActions.Remove:
                        {
                            Console.Write("Enter a user's name to remove: ");
                            string username = ConsoleExtensions.InputString();
                            if (ConsoleExtensions.RequestConfirmation("Are you sure?"))
                            {
                                int userIndexToRemove = users.FindIndex(u => u.Name == username);
                                
                                if (userIndexToRemove != -1)
                                {
                                    users.RemoveAt(userIndexToRemove);
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
                                users.Clear();
                            }
                        }

                        break;
                    case UserActions.Choose:
                        {
                            if (users.Count == 0)
                            {
                                Console.WriteLine("To choose a user, add it to the list first.");
                            }
                            else
                            {
                                Console.WriteLine("Enter a user's name from list: ");
                                string username = ConsoleExtensions.InputString();
                                User user = users.Find(u => u.Name == username);
                                if (user != null)
                                {
                                    return user;
                                }

                                Console.WriteLine("User \"{0}\" not found", username);
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
        public static void ShowPaintMenu(User user)
        {
            Console.WriteLine("{0}Hello, {1}! Choose from actions below:", Environment.NewLine, user.Name);
            Console.WriteLine("{0} to Show all figures", (int)Actions.Show);
            Console.WriteLine("{0} to Add a new figure", (int)Actions.Add);
            Console.WriteLine("{0} to Remove figure", (int)Actions.Remove);
            Console.WriteLine("{0} to Remove all figures", (int)Actions.Clear);
            Console.WriteLine("{0} to Choose another user or exit", (int)Actions.ChooseUser);

            while (true)
            {
                Console.Write("{0}{1}, please enter action number: ", Environment.NewLine, user.Name);
                switch (ConsoleExtensions.InputEnum<Actions>())
                {
                    default:
                        {
                            Console.WriteLine("Action with entered number doesn't exist.");
                        }
                        
                        break;
                    case Actions.ChooseUser:
                        return;
                    case Actions.Show:
                        {
                            Console.WriteLine("Figures list: ");
                            ShowList(user.Storage);
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
                                user.Storage.Add(figure);
                                Console.WriteLine("Figure {0} created and added successfully", figure.Type);
                            }
                        }

                        break;
                    case Actions.Remove:
                        {
                            Console.Write("Enter a figure's ID to remove: ");
                            int id = ConsoleExtensions.InputInt32();

                            if (ConsoleExtensions.RequestConfirmation("Are you sure?"))
                            {
                                int total_count = user.Storage.Count;
                                user.Storage.RemoveAll(figure => figure.Id == id);
                                if (total_count > user.Storage.Count)
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
                                user.Storage.Clear();
                            }
                        }

                        break;
                }
            }
        }
    }
}