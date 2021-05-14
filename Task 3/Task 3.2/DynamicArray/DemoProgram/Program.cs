namespace DemoProgram
{
    using System;
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

            Console.WriteLine("Last element: stringArray[-1] = " + stringArray[-1]);
            Console.WriteLine("Getter: stringArray[-2] = " + stringArray[-2]);
            Console.WriteLine("Setter: stringArray[-2] = \"NEW_VALUE\";");
            stringArray[-2] = "NEW_VALUE";
            Console.WriteLine("Getter: stringArray[-2] = " + stringArray[-2]);

            Console.WriteLine();
            Console.WriteLine("stringArray.Capacity = 8");
            stringArray.Capacity = 8;
            Program.ShowContentsAndInfo(stringArray);

            Console.WriteLine("CLONING");
            var clonedStringArray = stringArray.Clone() as DynamicArray<string>;
            Console.WriteLine("clonedStringArray");
            Program.ShowContentsAndInfo(clonedStringArray);

            Console.WriteLine("clonedStringArray.RemoveRange(2, 3);");
            clonedStringArray.RemoveRange(2, 3);
            Console.WriteLine("stringArray:");
            Program.ShowContentsAndInfo(stringArray);
            Console.WriteLine("clonedStringArray");
            Program.ShowContentsAndInfo(clonedStringArray);

            Console.WriteLine("TO ARRAY");
            Console.WriteLine("ordinaryStringArray = stringArray.ToArray();");
            var ordinaryStringArray = stringArray.ToArray();
            Program.ShowContentsAndInfo(ordinaryStringArray);

            Console.WriteLine("Press any key to start listing contents of cycled dynamic array");
            Console.ReadLine();
            CycledDynamicArray<string> cycledStringArray = new CycledDynamicArray<string>(stringArray);
            ShowContentsAndInfo(cycledStringArray);
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

        public static void ShowContentsAndInfo<T>(T[] array)
        {
            int index = 0;

            Console.WriteLine("[");
            foreach (var item in array)
            {
                Console.WriteLine("{0,2} - |{1}|", index, item);
                index++;
            }

            Console.WriteLine("] Length: {0}", array.Length);
            Console.WriteLine();
        }
    }
}