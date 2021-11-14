using System;

namespace лаба5
{
    abstract class Printed_edition
    {
        public override string ToString()
        {
            return $"Издание";
        }
        public string name;
        public int year;
        public string binding;
        public string author;
        public string person;
        public string publishing;
        public Printed_edition(string Name, int Year, string Binding, string Author, string Person, string Publishing)
        {
            this.Name = Name;
            this.Year = Year;
            this.Binding = Binding;
            author = Author;
            person = Person;
            publishing = Publishing;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public string Binding
        {
            get { return binding; }
            set { binding = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Person
        {
            get { return person; }
            set { person = value; }
        }
        public string Publishing
        {
            get { return publishing; }
            set { publishing = value; }
        }
        public override int GetHashCode()
        {
            Console.WriteLine($"Хэш-код издания {this.name} is: {name.GetHashCode()}");
            return name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Printed_edition Bookname = obj as Printed_edition;
            if (Bookname as Printed_edition == null)
            {
                return false;
            }
            return Bookname.name == this.name;
        }
        public void Print()
        {
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Год издания: {year}");
            Console.WriteLine($"Переплет: {binding}");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Персона: {person}");
            Console.WriteLine($"Издательство: {publishing}");
        }
        public abstract void Theme();
    }
    interface IVoid
    {
        static string Name { get; set; }
        void Theme();

    }
    sealed class Magazine : Printed_edition, IVoid
    {
        public override string ToString()
        {
            return $"Журнал";
        }
        public string topic;
        public Magazine(string Name, int Year, string Binding, string Author, string Person, string Publishing, string topic) :
            base(Name, Year, Binding, Author, Person, Publishing)
        {
            this.Name = Name;
            this.Year = Year;
            this.Binding = Binding;
            author = Author;
            person = Person;
            publishing = Publishing;
            this.topic = topic;
        }
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        public override void Theme()
        {
            Console.WriteLine("Тема: { topic}\n");
        } 
    }
    class Book : Printed_edition, IVoid
    {
        public override string ToString()
        {
            return $"Книга";
        }
        public string topic;
        public Book(string Name, int Year, string Binding, string Author, string Person, string Publishing, string topic) :
            base(Name, Year, Binding, Author, Person, Publishing)
        {
            this.Name = Name;
            this.Year = Year;
            this.Binding = Binding;
            author = Author;
            person = Person;
            publishing = Publishing;
            this.topic = topic;
        }
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        public override void Theme()
        {
            Console.WriteLine("Тема: { topic}\n");
        }
    }
    sealed class Guide : Printed_edition, IVoid
    {
        public override string ToString()
        {
            return $"Учебник";
        }
        public string topic;
        public Guide(string Name, int Year, string Binding, string Author, string Person, string Publishing, string topic) :
            base(Name, Year, Binding, Author, Person, Publishing)
        {
            this.Name = Name;
            this.Year = Year;
            this.Binding = Binding;
            author = Author;
            person = Person;
            publishing = Publishing;
            this.topic = topic;
        }
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        void IVoid.Theme()
        {
            Console.WriteLine($"Тема: {topic}\n");
        }
        public override void Theme()
        {
            Console.WriteLine("Тема: { topic}\n");
        }
        class Printer : AbsPrinter { }
        abstract class AbsPrinter
        {
            public void IamPrinting(Printed_edition obj)
            {
                Console.WriteLine("Тип этого объекта: " + obj.GetType());
                Console.WriteLine("Данные :" + obj.ToString());
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Magazine magazine = new Magazine("Незнайка", 2020, "мягкий", "Носов Н.Н.", "СШ№1", "БелАсвета", "образование");
                Console.WriteLine($"Журнал");
                magazine.Print();
                magazine.Theme();

                Book book = new Book("Хроники Шаннары", 1982, "твердый", "Терри Брукс", "книжный магазин", "Эксмо", "фантастика");
                Console.WriteLine($"Книга");
                book.Print();
                book.Theme();

                Printed_edition guide = new Guide("Искусство любить", 2016, "твердый", "Эрих Фромм", "ОЗ", "Эксмо", "психология");
                Console.WriteLine($"Учебник");
                Guide guide1 = guide as Guide;
                if(guide1 != null)
                {
                    Console.WriteLine(guide1.Author);
                }
                ((IVoid)guide).Theme();
                guide.Theme();

                Printed_edition newbook = new Book("В поисках приключений", 1991, "твердый", "Терри Брукс", "OZ", "Evers", "художественная литература"); 
                if (newbook is Book newbook2)
                {
                    Console.WriteLine(newbook2.Name);
                }
        
                Printer print = new Printer();
                print.IamPrinting(magazine);
                print.IamPrinting(book);
                print.IamPrinting(guide);
            }
        }
    }
}