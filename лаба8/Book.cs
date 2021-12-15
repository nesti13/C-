using System;

namespace лаба8
{
    public class Book
    {
        private string bookname;
        private int year;
        public string BookName
        {
            get
            {
                return bookname;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Вы ввели пустое значение");
                }
                else
                {
                    bookname = value;
                }
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Вы ввели пустое значение");
                }
                else
                {
                    year = value;
                }
            }
        }

        public Book(string bookname, int year)
        {
            BookName = bookname;
            Year = year;
        }

        public override string ToString()
        {
            return base.ToString() + " Название: " + bookname + ";" + " Год издания: " + year;
        }
    }
}