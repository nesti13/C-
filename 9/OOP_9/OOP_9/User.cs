using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP_9
{
    class User
    {
        public delegate void Software(List<string> list, string message);
        public event Software Upgrade;
        public event Software Work;
        
        public void Edit(List<string> list, string m)
        {
            Console.Write("\n Введите номер объекта (1 - 5), который хотите изменить: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Что вы хотите добавить?: ");
            string name = Console.ReadLine();

            list[number-1] += name;
            Upgrade?.Invoke(list, "Изменено.\n");
        }
        public void Loading(List<string> list, string m)
        {Console.Write("\nВведите номер объекта (1 - 5), который хотите запустить: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write($"{list[number - 1]}");
            Work?.Invoke(list," Загружен");
        }
    }
}
