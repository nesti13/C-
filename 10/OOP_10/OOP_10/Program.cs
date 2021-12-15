using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Concurrent;

namespace OOP_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 задание
            ConcurrentDictionary<string, Internet_resours> Internetcollection = new ConcurrentDictionary<string, Internet_resours>(); //коллекция с ключом стринг и value = internet_resours
            //Dictionary<string, Internet_resours> Internetcollection = new Dictionary<string, Internet_resours>();
            Internet_resours shop1 = new Internet_resours("AliExpress", "одежда", "аксессуары");  //в коллекции инициализируем данные
            Internet_resours shop2 = new Internet_resours("OZ", "книги", "ручки", "карандаши");
            Internet_resours shop3= new Internet_resours("Яндекс еда", "суши", "пицца", "домашняя еда","бургер");
            Internetcollection.TryAdd(shop1.internetres, shop1);   //добавляем в коллекцию данные
            Internetcollection.TryAdd(shop2.internetres, shop2);
            Internetcollection.TryAdd(shop3.internetres, shop3);
            Console.WriteLine("Вывод Колекции");
            foreach (KeyValuePair<string, Internet_resours> el in Internetcollection)
            {
                Console.WriteLine(Internetcollection[el.Key].ToString());
            }
            Console.WriteLine("Удалим AliExpress");
            Internetcollection.TryRemove("AliExpress", out shop1);

            foreach (KeyValuePair<string, Internet_resours> el in Internetcollection)
            {
                Console.WriteLine(Internetcollection[el.Key].ToString());
            }

            Console.WriteLine("Если есть OZ нужно вывести");

            if (Internetcollection.ContainsKey("OZ"))
            {
                Console.WriteLine(Internetcollection["OZ"]);
            }
            //2 задание

            ConcurrentDictionary<int, dynamic> universal_collection = new ConcurrentDictionary<int, dynamic>();
            universal_collection.TryAdd(0, 'б');
            universal_collection.TryAdd(1, "брр");
            universal_collection.TryAdd(2, (uint)123);
            universal_collection.TryAdd(3, (double)17.7);
            universal_collection.TryAdd(4, (short)(5000));
            universal_collection.TryAdd(5, shop1);
            

            Console.WriteLine("Универсальная коллекция");
            foreach (KeyValuePair<int, dynamic> el in universal_collection)
            {
                Console.WriteLine(universal_collection[el.Key]);
            }

            var enumer = universal_collection.GetEnumerator();
            dynamic h;
            int delAmount = 2;
            while (delAmount > 0)
            {
                universal_collection.TryRemove(enumer.Current.Key, out h);
                enumer.MoveNext();
                delAmount--;
            }

            Console.WriteLine("После удаления последовательных элементов");
            foreach (KeyValuePair<int, dynamic> el in universal_collection)
            {
                Console.WriteLine(universal_collection[el.Key]);
            }

            universal_collection.TryAdd(6, new StringBuilder("Строка в StringBuilder"));
            universal_collection.TryAdd(7, (long)7321310192432983902);
            universal_collection.GetOrAdd(8, shop3);

            Console.WriteLine("Вывод Универсольной коллекции");
            foreach (KeyValuePair<int, dynamic> el in universal_collection)
            {
                Console.WriteLine(universal_collection[el.Key]);
            }

            Console.WriteLine("Создали вторую коллекцию и заполнили ее данными из первой");
            List<dynamic> lc = new List<dynamic>();
            foreach (KeyValuePair<int, dynamic> pair in universal_collection)
            {
                lc.Add(pair.Value);
            }

            Console.WriteLine("Вывод второй колекции");
            foreach (dynamic el in lc)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("Вывод из коллекции");
            dynamic search = shop3;

            if (lc.Contains(search))
            {
                Console.WriteLine(lc.IndexOf(search).ToString() + " - индекс искомого элемента :\n" + search.ToString());
            }

            //Задание 3

            ObservableCollection<Internet_resours> obscol = new ObservableCollection<Internet_resours>();  //наблюдаемая коллекция
            obscol.CollectionChanged += CollectionChange.Reaction;
            obscol.Add(shop1);
            obscol.Add(shop2);
            obscol.Remove(shop1);
            obscol.Add(shop3);
            obscol.Remove(shop2);

        }
    }
    }
