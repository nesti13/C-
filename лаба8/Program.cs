using System;
using System.Collections.Generic;
using System.IO;

namespace лаба8
{
    class Program
    {
        interface IActions<T>
        {
            void Add(T bookname);
            void Delete(T number);
            void Display();
        }

        class CollectionType<T> : IActions<T> where T : class   //ограничение 
        {
            List<T> MyBook = new List<T>();

            public static T number;
            public void Add(T bookname)
            {
                MyBook.Add(bookname);
            }
            public void Delete(T number)
            {
                MyBook.Remove(number);
            }
            public void Display()
            {
                foreach (T elem in MyBook)
                {
                    Console.WriteLine(elem);
                }

            }
            public void WriteToFile()
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Admin\\Desktop\\ооп\\лаба8\\Test.txt");
                foreach (T elem in MyBook)
                {
                    sw.WriteLine(elem);
                }
                sw.Close();
            }
            public void ReadFromFile()
            {
                string line;
                StreamReader sr = new StreamReader("C:\\Users\\Admin\\Desktop\\ооп\\лаба8\\Test.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        static void Main(string[] args)
        {
            Book book1 = new Book("Путешествие зеленого человечка", 1984);
            Book book2 = new Book("Хроники Нарнии", 1993);
            Book book3 = new Book("Хроники Шаннары", 1982);
            Book book4 = new Book("Благие знамения", 2016);
            Book book5 = new Book("Гарри Поттер и философский камень", 1978);

            try
            {
                CollectionType<Book> Books = new CollectionType<Book>();
                Books.Add(book1);
                Books.Add(book2);
                Books.Add(book3);
                Books.Add(book4);
                Books.Add(book5);
                CollectionType<Book> Books2 = new CollectionType<Book>();
                CollectionType<string> Books3 = new CollectionType<string>();
                CollectionType<Book>.number = new Book("Искусство пофигизма", 2020);

                Books.Display();
                Console.WriteLine();

                Books.Delete(book2);
                Books.Display();

                Books.WriteToFile();
                Console.WriteLine("Произошла запись в файл\n");

                Books.ReadFromFile();
                Console.WriteLine("Произошло чтение из файла\n");

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Запись и чтение прошли успешно");
            }

            NumType<int> example1 = new NumType<int> { Id = 13, Num = 10890 };
            NumType<sbyte> example2 = new NumType<sbyte> { Id = -7, Num = -100 };

            Console.WriteLine("Идентификатор: " + example1.Id + "; Номер: " + example1.Num);
            Console.WriteLine("Идентификатор: " + example2.Id + "; Номер: " + example2.Num);
        }
    }
}