using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~1 задание ~~~~~~~");
            string[] Monthes = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            Console.WriteLine("Сколько буков в месяце, который вы хотите найти?:");
            int n = Convert.ToInt32(Console.ReadLine());
            var res = Monthes.Where(el => el.Length == n).Select(n => n);  
            res = from el in Monthes          
                  where el.Length == n   
                  select el;  
            Console.WriteLine($"Месяцы с количеством букв равным {n} :");
            foreach (string el in res)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("Летние месяцы:");
            res = from el in Monthes
                  where el.Equals("Июнь") || el.Equals("Июль") || el.Equals("Август")
                  select el;
            foreach (string el in res)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("Зимние месяцы:");
            res = from el in Monthes
                  where el.Equals("Декабрь") || el.Equals("Январь") || el.Equals("Февраль")
                  select el;
            foreach (string el in res)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("Месяцы в алфавитном порядке:");
            res = Monthes.OrderBy(el => el);
            foreach (string el in res)
            {
                Console.WriteLine(el);
            }
            res = from el in Monthes
                  where (el.Contains('И') || el.Contains('и')) && (el.Length >= 4)
                  select el;
            Console.WriteLine("Запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х:");
            foreach (string el in res)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("~~~~~~~2 задание ~~~~~~~");
            List<Bus> Buslist = new List<Bus>();
            Bus bus1 = new Bus("Грэм", "Уилл", "Д", "Ford", 2, 3, 15, 16);
            Bus bus2 = new Bus("Кроуфорд", "Джек", "Л", "Kia", 3, 4, 163, 5);
            Bus bus3 = new Bus("Дио", "Брандо", "Д", "Audi", 1, 1, 17, 7);
            Bus bus4 = new Bus("Какеин", "Нориаки", "Д", "Жигуль", 4, 2, 25, 12);

            Buslist.Add(bus1);
            Buslist.Add(bus2);
            Buslist.Add(bus3);
            Buslist.Add(bus4);
            Console.WriteLine("Список автобусоа:");
            foreach (Bus el in Buslist)
            {
                Console.WriteLine(el.Info());
            }

            Console.WriteLine("Введите номер маршрута:");
            var num = Console.ReadLine();
            int number = Convert.ToInt32(num);
            var result = from element in Buslist
                         where element.routenumber.Equals(number) == true
                         select element;
            Console.WriteLine($"Список автобусов с маршрутом {number}");
            foreach (Bus el in result)
            {
                Console.WriteLine(el.Info());
            }
            Console.WriteLine("Введите значение эксплуатации:");
            num = Console.ReadLine();
            number = Convert.ToInt32(num);
            result = from element in Buslist
                     where element.yearexplut >= number
                     select element;
            Console.WriteLine($"Список автобусов с эксплуатацией больше {number}");
            foreach (Bus el in result)
            {
                Console.WriteLine(el.Info());
            }
            Console.WriteLine("Самый минимальный пробег:");
            var min = Buslist.Min(element => element.mileage);
            result = from el in Buslist
                     where el.mileage.Equals(min)
                     select el;
            foreach (Bus el in result)
            {
                Console.WriteLine(el.Info());
            }
            Console.WriteLine("Самый максимальный пробег:");
            int x = 0;
            result = from el in Buslist
                     orderby el.mileage descending  
                     select el;
            foreach (Bus el in result)

            {
                if (x != 2)
                {
                    x++;
                    Console.WriteLine(el.Info());
                }
            }
            Console.WriteLine("Сортировка по номеру по убыванию:");
            result = from el in Buslist
                     orderby el.busnumber descending
                     select el;
            foreach (Bus el in result)
            {
                Console.WriteLine(el.Info());
            }
            Console.WriteLine("Сортировка по номеру по возрастанию:");
            result = from el in Buslist
                     orderby el.busnumber ascending 
                     select el;
            foreach (Bus el in result)
            {
                Console.WriteLine(el.Info());
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~4 задание ~~~~~~~");
            number = 3;
            string[] lastname = { "Грэм","Кроуфорд" };
            var res1=Buslist.Join(  
                lastname,
                last=>last.lastname,
                s=>s,
                (last,s)=>last
                ).
                Where(element=>element.routenumber.Equals(number)).
                OrderBy(p=>p.mileage).  
                ThenBy(b=>b.busnumber).  //задает дополнительные критерии для упорядочивания элементов возрастанию
                Distinct(). 
                Select(el => el);  
            foreach (Bus el in res1)
            {
                Console.WriteLine(el.Info());
            }
        }
    }
}
