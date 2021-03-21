using System;
using System.Collections.Generic;

namespace CustomPaint
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> storage = new List<Figure>();
            List<string> usernames = new List<string>();

            Console.WriteLine("EPAM-XT-2021 .NET-WEB - Custom Paint");

            while (true)
            {
                Console.WriteLine("{0}Choose a user to continue:", Environment.NewLine);
                string current_user = Tools.ChooseUser(usernames);
                if (current_user == string.Empty) break;

                Tools.ShowPaintMenu(storage, current_user);
            }
        }
    }
}