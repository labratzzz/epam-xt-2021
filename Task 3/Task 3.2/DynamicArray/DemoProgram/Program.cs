namespace DemoProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MyCollections;

    public static class Program
    {
        public static void Main()
        {
            DynamicArray<string> stringArray = new DynamicArray<string>();
            Program.ShowContentsAndInfo(stringArray);

            Console.WriteLine("ADDING");

            stringArray.Add("first");
            Program.ShowContentsAndInfo(stringArray);

            stringArray.AddRange(new string[] { "second", "third", "fourth" });
            Program.ShowContentsAndInfo(stringArray);
            
            stringArray.AddRange(new string[] { "fifth", "sixth", "seventh" });
            Program.ShowContentsAndInfo(stringArray);
            
            stringArray.AddRange(new string[] { "eighth", "ninth" });
            Program.ShowContentsAndInfo(stringArray);

            Console.WriteLine("INSERTING");

            stringArray.InsertRange(8, new string[] { "new1", "new2" });
            Program.ShowContentsAndInfo(stringArray);

            Console.WriteLine("REMOVING");

            stringArray.RemoveAt(2);
            Program.ShowContentsAndInfo(stringArray);

            stringArray.Remove("eighth");
            Program.ShowContentsAndInfo(stringArray);
        }

        public static void ShowContentsAndInfo<T>(DynamicArray<T> collection)
        {
            int index = 0;
            foreach (var item in collection)
            {
                Console.WriteLine("{0,2} - |{1}|", index, item);
                index++;
            }
            Console.WriteLine("Capacity: {0}", collection.Capacity);
            Console.WriteLine("Length: {0}", collection.Length);
            Console.WriteLine();
        }
    }
}