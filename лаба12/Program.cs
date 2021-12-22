using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            Serial serial = new Serial("Good Omens", "Дуглас Маккиннон");
            Console.WriteLine("1 задание");
            Console.WriteLine("Определение имени сборки, в которой определен класс");  
            Reflector.Get_a();
            Console.WriteLine("Есть ли публичные конструкторы");
            Reflector.Get_b(serial);
            if (true)
            {
                Console.WriteLine("Класс (Сериал) включает в себя публичный конструктор");
                using (StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\лаба12\out.txt",true))
                {
                    file.WriteLine("Класс (Сериал) включает в себя публичный конструктор");
                }
            }
            Console.WriteLine("Извлечение всех общедоступных публичных методов класса");
            Reflector.Get_c(serial);
            Console.WriteLine();
            Console.WriteLine("Получение информации о полях и свойствах класса");
            Reflector.Get_d(serial);
            Console.WriteLine();
            Console.WriteLine("Получение всех реализованных классом интерфейсов");
            Reflector.Get_e(serial);
            Console.WriteLine("Выводит по имени класса имен методов, которые содержат заданный тип параметра");
            Reflector.Get_f(serial, "Int32 i");
            Reflector.Invoke("text.txt", "Toconsole");
            object ob = Reflector.Create("Люцифер", "Кевин Алехандро");
            Console.Write($"{(ob as Serial).Name} {(ob as Serial).Director}");
        }
    }
}
