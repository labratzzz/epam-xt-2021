namespace CustomPaint
{
    using System;
    using System.Collections.Generic;
    using CustomPaint.Entities;
    using CustomPaint.Utils;

    public static class Program
    {
        // Entry point
        public static void Main()
        {
            List<User> users = new List<User>();

            Console.WriteLine("EPAM-XT-2021 .NET-WEB - Custom Paint");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose a user to continue:");
                User currentUser = Tools.ChooseUser(users);
                if (currentUser == null)
                {
                    break;
                }

                Tools.ShowPaintMenu(currentUser);
            }
        }
    }
}