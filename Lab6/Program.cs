using System;
using System.Collections.Generic;

namespace Lab6
{
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
    public abstract class publication : Apublication, Ipublication
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

            Book book = new Book("Гарри Поттер и философский камень", "Фэнтези-книга", 1991, 49, 123) ;
            Guide guide = new Guide("Психология поведения детей дошкольного возраста", "Учебник", 2019, 23, 1);
            Magazine magazine = new Magazine("Times", "Журнал", 2021, 41, "Мягкая");

            Library library = new Library();
            library.Push(book);
            library.Push(guide);
            library.Push(magazine);
            library.DisplayAll();
            library.Count();
            library.Price();
        }
    }
}