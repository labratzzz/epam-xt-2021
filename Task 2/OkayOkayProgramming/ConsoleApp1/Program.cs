﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "kek";
            string s2 = "kek";
            Console.WriteLine(Object.ReferenceEquals(s1, s2));
        }
    }
}