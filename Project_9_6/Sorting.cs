using System;
using System.Collections;

namespace Project_9_6
{
    internal class Sorting
    {
        public static string[] students_data { get; set; }

        public class Comparer : IComparer
        {
            public int Compare(Object x, Object y)
            {
                return (new CaseInsensitiveComparer()).Compare(x, y);
            }
        }

        public class ReverseComparer : IComparer
        {
            public int Compare(Object x, Object y)
            {
                return (new CaseInsensitiveComparer()).Compare(y, x);
            }
        }

        public Sorting() { }

        public static void DisplayValues(String[] array)
        {
            if (array != null || array != default || array != new string[] { })
            {
                for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
                {
                    Console.WriteLine("{0}", array[i]);
                }
                Console.WriteLine();
            }
            else
            {
                throw new SortingException("Ошибка", new SortingException("Массив не может быть пустым."));
            }
        }
    }
}
