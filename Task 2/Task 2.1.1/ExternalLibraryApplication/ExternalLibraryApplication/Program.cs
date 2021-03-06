﻿namespace ExternalLibraryApplication
{
    using System;
    using System.Text;
    using MyTools;

    public static class Program
    {
        static void Main()
        {
            Console.WriteLine("Some functionality demo");

            CustomString cs = (CustomString)"What a lovely day!";
            CustomString cs2 = new CustomString("0123456789");
            CustomString cs3 = new CustomString(' ', 15);

            Console.Write("{0} = ", new CustomString(nameof(cs)).ToString());
            Console.WriteLine(cs);
            Console.WriteLine(new string(' ', 5) + cs2 + cs2.Substring(0, 8));
            Console.WriteLine(cs3 + new CustomString('1', 8));

            Console.WriteLine(new CustomString());

            Console.WriteLine("cs.IndexOf('A') = {0}", cs.IndexOf('A'));
            Console.WriteLine("cs.IndexOf('a') = {0}", cs.IndexOf('a'));
            Console.WriteLine("cs.LastIndexOf('a') = {0}", cs.LastIndexOf('a'));
            Console.WriteLine("cs.IndexOf('a', 4) = {0}", cs.IndexOf('a', 4));
            Console.WriteLine("cs.LastIndexOf('a', 0, 3) = {0}", cs.LastIndexOf('a', 0, 3));
            Console.WriteLine("cs.LastIndexOf('a', 0, 2) = {0}", cs.LastIndexOf('a', 0, 2));

            Console.WriteLine();

            Console.WriteLine("cs.Contains('A') = {0}", cs.Contains('A'));
            Console.WriteLine("cs.Contains('o') = {0}", cs.Contains('o'));
            Console.WriteLine("cs.Contains(\"loe\") = {0}", cs.Contains("loe"));
            Console.WriteLine("cs.Contains(\"ely d\") = {0}", cs.Contains("ely d"));

            Console.WriteLine();

            Console.WriteLine("cs.Length = {0}{1}", cs.Length, new CustomString('\n', 1));

            CustomString hello = new CustomString("Hello");
            CustomString world = new CustomString(' ', 1) + "World!";

            Console.WriteLine("CustomString hello = \"{0}\"", hello);
            Console.WriteLine("CustomString world = \"{0}\"", world);
            Console.WriteLine("CustomString.Concat(hello, world) = \"{0}\"", CustomString.Concat(hello, world));
            hello[1] = 'E';
            Console.WriteLine("hello[1] = 'E';\nhello = \"{0}\"", hello);
            Console.WriteLine("hello.Replace('l', 'L') = \"{0}\"", hello.Replace('l', 'L'));

            Console.WriteLine("world.Insert(2, new CustomString(\"[INSERT]\")) = \"{0}\"", world.Insert(2, new CustomString("[INSERT]")));
            Console.WriteLine("world.Insert(5, \"[INSERT]\") = \"{0}\"", world.Insert(5, "[INSERT]"));

            Console.WriteLine();
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("NEW FUNCTIONALITY");
            Console.WriteLine();

            char[] charArray = new char[] { 'W', 'h', 'a', 't', '\'', 's', ' ', 'u', 'p', '?' };
            CustomString newcs1 = new CustomString(charArray);
            CustomString newcs2 = (CustomString)charArray;

            Console.WriteLine("{0} {1} = new {0} {2}", "char[]", nameof(charArray), Program.DisplayInBrackets(charArray));

            Console.WriteLine();

            Console.WriteLine("{0} {1} = new {0}({2})", newcs1.GetType(), nameof(newcs1), nameof(charArray));
            Console.WriteLine("{0} = {1}", nameof(newcs1), newcs1);
            
            Console.WriteLine();

            Console.WriteLine("{0} {1} = ({0}){2}", newcs2.GetType(), nameof(newcs2), nameof(charArray));
            Console.WriteLine("{0} = {1}", nameof(newcs2), newcs2);
        }

        public static string DisplayInBrackets(char[] charArray)
        {
            StringBuilder result = new StringBuilder("{ ");

            int lastElement = charArray.Length - 1;
            for (int i = 0; i < lastElement; i++)
            {
                result.AppendFormat("'{0}', ", charArray[i]);
            }

            result.AppendFormat("{0} }}", lastElement);
            
            return result.ToString();
        }
    }
}