using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace лаба7
{
    class AddException : Exception
    {
        public AddException(string message)
            : base(message)
        { }
    }
    
    class BookException : NullReferenceException
    {
        public BookException(string message)
            : base(message)
        { }
    }
    public class New
    {
        public enum Styles
        {
            Classicism = 1,
            Sentimentalism,
            Romanticism,
            Realism,
            Symbolism,
            Acmeism,
            Futurism,
            Surrealism,
            Naturalism
        }
        public struct User
        {
            public string name;
            public int age;
            public User(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"Имя пользователя: {name}  Возраст: {age}");
            }
        }
    }
    public static partial class partialclass
    {
        public static void Output()
        {
            Console.WriteLine("Моя библиотека");
        }
    }
    interface Ipublication
    {
        string Name { get; set; }
        string Type { get; set; }
        int Year { get; set; }
        int Price { get; set; }
    }
    public abstract class Apublication
    {
        public string Description { get; set; }
        public virtual string Display()
        {
            return Description;
        }
    }
    public class publication : Apublication, Ipublication
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public publication(string name, string type, int year, int price)
        {
            Name = name;
            Type = type;
            Year = year;
            Price = price;
        }
        public override string Display()
        {
            return $"Название: {Name}, Тип: {Type}, Год издания: {Year}, Цена: {Price}";
        }
    }
    class Book : publication
    {
        public int Countpages { get; set; }
        public Book(string Name, string Type, int Year, int Price, int countpages) : base(Name, Type, Year, Price)
        {
            Countpages = countpages;
        }
        public override string Display()
        {
            return $"Название: {Name}, Тип: {Type}, Год издания: {Year}, Цена: {Price}p, Кол-во страниц: {Countpages}";
        }
    }           
    class Guide : publication
    {
        public int Countoftutors;
        public Guide(string Name, string Type, int Year, int Price, int countoftutors) : base(Name, Type, Year, Price)
        {
            Countoftutors = countoftutors;
        }
        public override string Display()
        {
            return $"Название: {Name}, Тип: {Type}, Год издания: {Year}, Цена: {Price}p, Кол-во издателей: {Countoftutors}";
        }
    }
    class Magazine : publication
    {
        public string Cover { get; set; }
        public Magazine(string Name, string Type, int Year, int Price, string cover) : base(Name, Type, Year, Price)
        {
            Cover = cover;
        }
        public override string Display()
        {
            return $"Название: {Name}, Тип: {Type}, Год издания: {Year}, Цена: {Price}p, Обложка: {Cover}";
        }
    }

    class Add
    {
        private int countofpages;
        public int Countofpages
        {
            get
            {
                return countofpages;
            }
            set
            {
                if (value > 5)
                {
                    throw new AddException("Слишком много страниц");
                }
                else
                {
                    countofpages = value;
                }
            }
        }

        public Add(int Countofpages)
        {
            this.Countofpages = Countofpages;
        }
    }
    
    public class Library
    {
        List<publication> MyLibrary = new List<publication>();
        public int tutorscount = 0;
        public int sum = 0;
        public void Push(publication item)
        {
            MyLibrary.Add(item);
            if (item.Type == "Учебник") tutorscount++;
            sum += item.Price;
        }
        public void Pop(int number)
        {
            MyLibrary.RemoveAt(number);
        }
        public void DisplayAll()
        {
            foreach (var item in MyLibrary)
            {
                Console.WriteLine(item.Display());
            }
        }
    }

    public static class Controller
    {
        public static void Count(this Library library)
        {
            Console.WriteLine("Количество учебников: " + library.tutorscount);
        }
        public static void Price(this Library library)
        {
            Console.WriteLine("Цена всех изданий в библиотеке: " + library.sum);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            New.Styles Acmeism = New.Styles.Acmeism;
            Console.WriteLine(Acmeism);
            Console.WriteLine((int)Acmeism);

            New.User user1 = new New.User("Колядко Яна", 18);
            user1.DisplayInfo();

            partialclass.Output();
            partialclass.Output2();

            Book book = new Book("Гарри Поттер и философский камень", "Фэнтези-книга", 1991, 49, 123);
            Guide guide = new Guide("Психология поведения детей дошкольного возраста", "Учебник", 2019, 23, 1);
            Magazine magazine = new Magazine("Times", "Журнал", 2021, 41, "Мягкая");

            Library library = new Library();
            library.Push(book);
            library.Push(guide);
            library.Push(magazine);
            library.DisplayAll();
            library.Count();
            library.Price();

            try
            {
                int x = 5, y = 0;
                x /= y;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Источник: " + ex.Source);
            }
            finally
            {
                Console.WriteLine("Попытка деления на ноль не удалась");
            }

            try
            {
                int[] array = { 1, 2, 3 };
                Console.WriteLine(array[3]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Источник: " + ex.Source);
            }

            try
            {
                Add add = new Add(6);
            }
            catch (AddException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Источник: " + ex.Source);
            }

            try
            {
                string str = "исключение";
                if (str == null)
                {
                    throw new ArgumentNullException("Было присвоено значение NULL ");
                }
                Console.WriteLine(str);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Источник: " + ex.Source);
            }

            try
            {
                Console.Write("Введите число типа byte: ");
                byte b = byte.Parse(Console.ReadLine());
                int[] myArr = new int[5] { 1, 2, 0, 10, 12 };
                Console.WriteLine("Исходный массив: ");

                for (int j = 0; j <= myArr.Length; j++)
                    Console.WriteLine("{0}\t", myArr[j]);

                int i = 120;
                Console.WriteLine("\nДелим на число: \n");
                foreach (int d in myArr)
                    Console.WriteLine(i / d);
            }
            
            catch (OverflowException)
            {
                Console.WriteLine("Данное число не входит в диапазон 0 - 255");
            }
            
            catch (DivideByZeroException)
            {
                Console.WriteLine("Делить на ноль нельзя");
            }
            
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Индекс выходит за пределы\n");
            }

            try
            {
                int[] array = new[] { 12, 10, 82 };
                int index = 100;
                if (array.Length < index)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine(array[index]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Источник: " + ex.Source);

            }
            finally
            {
                Console.WriteLine("Неправильный индекс");
            }

            Console.WriteLine("Введите число");
            int number = int.Parse(Console.ReadLine());

            void findsqrt(int Number)
            {
                Debug.Assert(Number == 0, "Нельзя извлечь корень из отрицательного");

                Console.WriteLine(Math.Sqrt(Number));
            }
            findsqrt(number);
        }
    }
}