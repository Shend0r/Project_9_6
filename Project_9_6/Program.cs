using System;
using System.Collections;

namespace Project_9_6
{
    internal class Program
    {
        static object[] excepitionsContainer = new object[5]
        {
                new ArgumentNullException("arg0", "Аргумент не может быть пустым."),
                new System.IO.FileNotFoundException("Файл не найден."),
                new IndexOutOfRangeException("ID не может быть больше или равно 5."),
                new UnauthorizedAccessException("У вас нету прав доступа к этой папке."),
                new SortingException("Сортировка не удалась.")
        };

        //не очень я конечно уверен что это именно то, что нужно, но вроде так я пониял

        static void Main(string[] args)
        {

            try
            {
                argNullException(null);
            }
            catch (ArgumentException anex)
            {
                Console.WriteLine(anex);
            }

            try
            {
                fileNotFoundException();
            }
            catch (System.IO.FileNotFoundException fnfex)
            {
                Console.WriteLine(fnfex);
            }

            try
            {
                indexOutOfRangeException(5);
            }
            catch (IndexOutOfRangeException iorex)
            {
                Console.WriteLine(iorex);
            }

            try
            {
                unauthorizedAccessException("C:\\Program Files(x86");
            }
            catch (UnauthorizedAccessException uaex)
            {
                Console.WriteLine(uaex);
            }

            try // Сортировка студентов
            {
                SortingStudents(new string[] { "Борис", "Петр", "Анатолий", "Максим", "Яна" }, 0);
            }
            catch (SortingException sortingException)
            {
                Console.WriteLine(sortingException);
            }

            Console.ReadKey();
        }

        public static void argNullException(string arg0)
        {
            if (arg0 == null || arg0 == "" || arg0 == default(string))
            {
                ArgumentNullException anex = (ArgumentNullException)excepitionsContainer[0];

                throw new ArgumentException("Ошибка", anex);
            }
        }

        public static void fileNotFoundException()
        {
            if (System.IO.File.Exists("EmptyFile") == false)
            {
                System.IO.FileNotFoundException fnfex = (System.IO.FileNotFoundException)excepitionsContainer[1];

                throw new System.IO.FileNotFoundException("Ошибка", fnfex);
            }
        }

        public static void indexOutOfRangeException(byte id)
        {
            string[] data = new string[5] { "text0", "text1", "text2", "text3", "text4" };

            string text = "";

            if (id >= 5)
            {
                IndexOutOfRangeException iorex = (IndexOutOfRangeException)excepitionsContainer[2];

                throw new IndexOutOfRangeException("Ошибка", iorex);
            }
            else
            {
                text = data[id];
            }

            Console.WriteLine(text);
        }

        public static void unauthorizedAccessException(string Path)
        {
            bool result;

            try
            {
                System.IO.File.WriteAllText(Path, "Привет, мир!");
                result = true;
                System.IO.File.Delete(Path);
            }
            catch
            {
                result = false;
            }

            if (result == false)
            {
                UnauthorizedAccessException uaex = (UnauthorizedAccessException)excepitionsContainer[3];

                throw new UnauthorizedAccessException("Ошибка", uaex);
            }
        }

        public static void SortingStudents(string[] Data, byte Type) // Сортировка студентов
        {

            if (Type > 2 || Type < 1)
            {
                SortingException sortingException = (SortingException)excepitionsContainer[4];

                throw new SortingException("Ошибка, не верный тип сортировки.", sortingException);
            }
            else
            {
                IComparer comparer = null;

                Sorting.students_data = Data;

                if (Type == 1)
                {
                    comparer = new Sorting.Comparer();
                }

                if (Type == 2)
                {
                    comparer = new Sorting.ReverseComparer();
                }

                Array.Sort(Sorting.students_data, comparer);

                Sorting.DisplayValues(Sorting.students_data);
            }
        }
    }
}
