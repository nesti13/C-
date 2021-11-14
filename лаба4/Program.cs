using System;
using System.Collections.Generic;
using System.Linq;

namespace лаба4
{
    public class Books
    {
        public string Bookname { get; set; }

        public Date curdate = new Date();

        public static bool operator ==(Books a, Books b)  
        {
            return a.Equals(b);
        }
        public static bool operator !=(Books a, Books b)  
        {
            return !a.Equals(b);
        }
        public static int operator +(Books s1, int s2)  
        {
            int back = s2;
            return back;
        }
        public static int operator >>(Books s1, int s2)  
        {
            int back = s2;
            return back;
        }

        private Owner Owner1 = new Owner(1927362, "Yana", "BSTU");

        public class Owner 
        {
            public int id { get; set; }
            public string name { get; set; }
            public string organization { get; set; }
            public string Date { get; set; }

            public Owner(int id, string name, string organization)
            {
                this.id = id;
                this.name = name;
                this.organization = organization;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Date //вложенный класс
    {
        public string str;
        public Date()
        {
            str = getdate();
        }
        public static string getdate()
        {
            DateTime curdate = new DateTime();
            curdate = DateTime.Now;
            return curdate.ToString();
        }
    }
    public static class StaticOperation
    {
        public static int Kol(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
        public static string Findword(List<Books> mybooks) 
        {
            string Biggestword = ""; 
            for (int i = 0; i < mybooks.Count; i++)
            {
                string[] word = mybooks[i].Bookname.Split(' '); //разделяем строку на массив подстрок
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j].Length > Biggestword.Length) 
                        Biggestword = word[j];
                }
            }
            return Biggestword;
        }

        public static List<Books> Deletelast(List<Books> mybooks) 
        {
            mybooks.Remove(mybooks.Last());
            return mybooks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Books> mybooks = new List<Books>();
            mybooks.Add(new Books() { Bookname = "Гарри поттер"});
            mybooks.Add(new Books() { Bookname = "Тень и кость"});
            mybooks.Add(new Books() { Bookname = "Академия проклятий"});
            mybooks.Add(new Books() { Bookname = "Темная империя"});
            mybooks.Add(new Books() { Bookname = "Во власти стихии\n" });
            Console.WriteLine("Список 1:\n");

            for (int i = 0; i < mybooks.Count; i++)
            {
                Console.WriteLine(mybooks[i].Bookname);
            }
            Console.ReadKey();

            List<Books> newbooks = new List<Books>();
            newbooks.Add(new Books() { Bookname = "Хроники Шаннары"});
            newbooks.Add(new Books() { Bookname = "Дары смерти\n"});
            
            Console.WriteLine("Список 2:\n");

            for (int i = 0; i < newbooks.Count; i++)
            {
                Console.WriteLine(newbooks[i].Bookname);
            }
            Console.ReadKey();

            Console.WriteLine("Самое длинное слово: " + StaticOperation.Findword(mybooks));  //вызываем метод расширения
            Console.ReadKey();

            Books.Owner director = new Books.Owner(63526, "Yana", "BSTU");
            Console.WriteLine("Id директора: " + director.id);
            Console.WriteLine("Имя директора: " + director.name);
            Console.WriteLine("Название организации: " + director.organization);
            Console.ReadKey();

            int del = 1 >> 0;
            mybooks.RemoveAt(del);
            int add = 0 + 0;
            mybooks.Insert(add, new Books() { Bookname = "Хроники Шаннары" });
            for (int i = 0; i < mybooks.Count; i++)
            {
                Console.WriteLine(mybooks[i].Bookname);
            }
            Console.ReadKey();
            
            StaticOperation.Deletelast(mybooks); //вызываем метод расширения

            Console.WriteLine("Список после удаления последнего элемента: ");

            for (int i = 0; i < mybooks.Count; i++)
            {
                Console.WriteLine(mybooks[i].Bookname);
            }
            Console.ReadKey();
            
            if(mybooks != newbooks)
                Console.WriteLine("Множества не равны"); 

            Console.WriteLine(mybooks[0].curdate.str);

            string s = "Книги и журналы";
            char c = 'и';
            int a = s.Kol(c);
            Console.WriteLine(a);
        }
    }
}