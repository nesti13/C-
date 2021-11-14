using System;

//Создать класс Book: id, название, автор(ы), издательство, год издания, количество страниц, цена, тип переплета.
namespace лаба3
{
    public partial class Book
    {
        public void Set()
        {
            Console.Write("My laboratory work");
        }
    }
    public partial class  Book
    {
        public int id;
        public string name;
        public string author;
        private string publishing;
        public string Publishing
        {
            set
            {
                if (publishing == "")
                {
                    Console.WriteLine("Издательство не указано");
                }
                else
                {
                    publishing = value;
                }
            }
            get
            {
                return publishing;
            }
        }
        public int year = 2019;
        private int numberofpages;
        public virtual int Numberofpages
        {
            set
            {
                if (numberofpages < 0)
                {
                    Console.WriteLine("Количество страниц не может быть отрицательным числом");
                }
                else
                {
                    numberofpages = value;
                }
            }
            get
            {
                return numberofpages;
            }
        }
        public double price;
        public string binding;
        public void Information()
        {
            Console.WriteLine($"Идентификатор: {id}\nНазвание: {name}\nАвтор: {author}\nИздательство: {publishing}\nГод издания: {year}\nКоличество страниц: {numberofpages}\nЦена: {price}р\nТип переплета: {binding}");
        }

        public void Inf()
        {
            Console.WriteLine($"Идентификатор: {id}\nНазвание: {Name}\nАвтор: {Author}\nИздательство: {publishing}\nГод издания: {year}\nКоличество страниц: {numberofpages}\nЦена: {price}р\nТип переплета: {binding}");
        }

        public Book()
        {
            id = 542317;
            name = "Эльфийские камни Шаннары";
            author = "Терренс Дин Брукс";
            publishing = "Эксмо";
            year = 1982;
            numberofpages = 743;
            price = 27.56;
            binding = "Твердый";
            count++;
        }

        public Book(int a, string b, string c, string d, int e, int f, double g, string h)
        {
            id = a;
            name = b;
            author = c;
            publishing = d;
            year = e;
            numberofpages = f;
            price = g;
            binding = h;
            count++;
        }

        public readonly uint ID;
        public string Name { get; private set; }
        public string Author { get; private set; }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Name))
                return base.ToString();
            return Name;
        }

        public Book(int id, string name, string author, string publishing, int year, double price, string binding)
        {
            this.id = id;
            Name = name;
            Author = author;
            this.publishing = publishing;
            this.year = year;
            this.price = price;
            this.binding = binding;
            count++;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + author.GetHashCode();
        }

        public override bool Equals(Object id)
        {
            if ((id == null) || this.GetType().Equals(id.GetType()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string str;
        static Book()
        {
            str = "Объект создан";
        }

        private Book(int a) { } // закрытый конструктор
        public static string close = "";

        public static int count = 0;

        public static void numberofbooks(ref int count)
        {
            Console.WriteLine("Количество хранящихся книг: " + count);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Book work = new Book();
            work.Move();

            Console.WriteLine(Book.str);

            Console.WriteLine(Book.close);

            Book one = new Book();
            one.Information();
            Console.WriteLine();

            Book second = new Book(254571, "Благие знамения", "Терри Пратчетт и Нил Гейман", "Эксмо", 2012, 451, 45.13, "Твердый");
            second.Information();
            Console.WriteLine();

            Book third = new Book(id: 476215, name: "Меч Шаннары", author: "Терренс Дин Брукс", publishing: "Эксмо", year: 1977, price: 29.75, binding: "Твердый");
            third.Inf();
            Console.WriteLine();
            Console.WriteLine("Тип созданного третьего объекта: {0}", third.GetType());

             //анонимный тип

            var book = new { id = 654396, name = "Гарри Поттер и философский камень", author = "Джоан Роулинг", publishing = "Эксмо", year = 1978, numberofpages = 547, price = 24.79 + "p", binding = "Твердый" };
            Console.WriteLine("\nИдентификатор: " + book.id);
            Console.WriteLine("Название: " + book.name);
            Console.WriteLine("Автор: " + book.author);
            Console.WriteLine("Издательство: " + book.publishing);
            Console.WriteLine("Год издания: " + book.year);
            Console.WriteLine("Количество страниц: " + book.numberofpages);
            Console.WriteLine("Цена: " + book.price);
            Console.WriteLine("Тип переплета: " + book.binding);
            Console.WriteLine();

            Book.numberofbooks(ref Book.count);

            Console.WriteLine($"Вторая и третья книги равны:" + third.Equals(second));

            Book[] books = new Book[3];
            books[0] = one;
            books[1] = second;
            books[2] = third;

            Console.WriteLine("Введите искомого автора: ");
            string author = Console.ReadLine();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Author == author)
                {
                    Console.WriteLine("\nИдентификатор: " + books[i].id);
                    Console.WriteLine("Название: " + books[i].Name);
                    Console.WriteLine("Автор: " + books[i].Author);
                    Console.WriteLine("Издательство: " + books[i].Publishing);
                    Console.WriteLine("Год издания: " + books[i].year);
                    Console.WriteLine("Количество страниц: " + books[i].Numberofpages);
                    Console.WriteLine("Цена: " + books[i].price + "p");
                    Console.WriteLine("Тип переплета: " + books[i].binding);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Не автор этой книги");
                }
            }

            Console.WriteLine("Введите год, после которого должны были быть выпущены книги: ");
            int year = int.Parse(Console.ReadLine()); //преобразуем тип string in int
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].year > year)
                {
                    Console.WriteLine("\nИдентификатор: " + books[i].id);
                    Console.WriteLine("Название: " + books[i].name);
                    Console.WriteLine("Автор: " + books[i].author);
                    Console.WriteLine("Издательство: " + books[i].Publishing);
                    Console.WriteLine("Год издания: " + books[i].year);
                    Console.WriteLine("Количество страниц: " + books[i].Numberofpages);
                    Console.WriteLine("Цена: " + books[i].price + "p");
                    Console.WriteLine("Тип переплета: " + books[i].binding);
                    Console.WriteLine();
                }
            }
        }   
    }
}