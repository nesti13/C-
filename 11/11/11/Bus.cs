using System;
using System.Collections.Generic;
using System.Text;

namespace _11
{
    class Bus
    {
        public string lastname;
        public string name, firstlettername;
        public string middlename, firstlettermiddlename;
        public string brand;
        private readonly int id;
        public int routenumber;
        public int mileage;
        public int yearexplut;
        private static int numberofbuses = 0;
        private int Busnumber;
        public int busnumber;
        public Bus(string a, string b, string c, string d, int e, int f, int i, int h)
        {
            Console.WriteLine();
            lastname = a;
            name = b;
            middlename = c;
            brand = d;
            busnumber = e;
            routenumber = f;
            mileage = i;
            yearexplut = h;
            id = GetHashCode();

        }
        public string Info()
        {
            string rs;
            rs = $"Водитель        {lastname} \n" +
                $" Бренд   {brand} \n" +
                $"Номер автобуса   {busnumber} \n" +
                $"Номер маршрута   {routenumber} \n" +
                $"Эксплуатация   {yearexplut} \n" +
                $"Пробег   {mileage} \n" +
                $"ID              {id} \n";
        
            Console.WriteLine("____________________________________");
            return rs;

        }

    }
}
