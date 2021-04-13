namespace CustomPaint
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        // Entry point
        public static void Main()
        {
            List<Figure> storage = new List<Figure>();
            List<string> usernames = new List<string>();

            Console.WriteLine("EPAM-XT-2021 .NET-WEB - Custom Paint");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose a user to continue:");
                string currentUser = Tools.ChooseUser(usernames);
                if (currentUser == string.Empty)
                {
                    break;
                }

                Tools.ShowPaintMenu(storage, currentUser);
            }
        }
    }
}