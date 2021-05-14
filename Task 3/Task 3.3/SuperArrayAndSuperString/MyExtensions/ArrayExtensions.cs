namespace MyExtensions
{
    using System;
    using System.Linq;

    public static class ArrayExtensions
    {
        public static T[] ForEach<T>(this T[] array, Action<T> action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            T[] result = array.Clone() as T[];
            foreach (var item in result)
            {
                action.Invoke(item);
            }

            return result;
        }

        public static T MostFrequent<T>(this T[] array)
        {
            return array.GroupBy(a => a)
                    .OrderBy(a => a.Count())
                    .Select(g => g.Key)
                    .LastOrDefault();
        }
        
        public static sbyte SumOfElements(this sbyte[] array)
        {
            sbyte sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static byte SumOfElements(this byte[] array)
        {
            byte sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static short SumOfElements(this short[] array)
        {
            short sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static ushort SumOfElements(this ushort[] array)
        {
            ushort sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static int SumOfElements(this int[] array)         
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            
            return sum;
        }

        public static uint SumOfElements(this uint[] array)
        {
            uint sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static long SumOfElements(this long[] array)
        {
            long sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static ulong SumOfElements(this ulong[] array)
        {
            ulong sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static double Average(this sbyte[] array)
        {
            return ArrayExtensions.SumOfElements(array) / (double)array.Length;
        }

        public static double Average(this byte[] array)
        {
            return ArrayExtensions.SumOfElements(array) / (double)array.Length;
        }

        public static double Average(this short[] array)
        {
            return ArrayExtensions.SumOfElements(array) / (double)array.Length;
        }

        public static double Average(this ushort[] array)
        {
            return ArrayExtensions.SumOfElements(array) / (double)array.Length;
        }

        public static double Average(this int[] array)
        {
            return ArrayExtensions.SumOfElements(array) / (double)array.Length;
        }

        public static double Average(this uint[] array)
        {
            return ArrayExtensions.SumOfElements(array) / (double)array.Length;
        }

        public static double Average(this long[] array)
        {
            return ArrayExtensions.SumOfElements(array) / (double)array.Length;
        }

        public static double Average(this ulong[] array)
        {
            return ArrayExtensions.SumOfElements(array) / (double)array.Length;
        }
    }
}
