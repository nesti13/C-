using System;
using System.Text;

namespace лаба1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task_1a");

            string hello = "Aloha";
            Console.WriteLine(hello);

            int a = 3, b = 5;
            bool f = a == b;
            Console.WriteLine(f);

            byte c = 0;
            byte d = 255;
            Console.WriteLine(c);
            Console.WriteLine(d);

            sbyte e = -128;
            sbyte g = 126;
            Console.WriteLine(e);
            Console.WriteLine(g);

            char h = '*';
            Console.WriteLine(h);

            decimal i = 2003.1M;
            Console.WriteLine(i);

            double j = 666.6;
            Console.WriteLine(j);

            float k = 514.98f;
            Console.WriteLine(k);

            int l = 654;
            Console.WriteLine(l);

            uint m = 0b101;
            Console.WriteLine(m);

            long n = -40762539282;
            Console.WriteLine(n);

            ulong o = 40762539282;
            Console.WriteLine(o);

            short p = -6534;
            Console.WriteLine(p);

            ushort q = 6534;
            Console.WriteLine(q);

            Console.WriteLine("\n");
            Console.WriteLine("Task_1b");

            byte r = 100;
            int s = r;
            Console.WriteLine(s);

            int t = 19;
            decimal u = t;
            Console.WriteLine(u);

            long v = 1963423;
            float w = v;
            Console.WriteLine(w);

            ulong x = 342564735;
            float y = x;
            Console.WriteLine(y);

            float z = 1073630;
            double a1 = z;
            Console.WriteLine(a1);

            double r1 = 100.7321;
            int s1;
            s1 = (int)r1;
            System.Console.WriteLine(s1);

            float t1 = 134.45E-2f;
            int u1;
            u1 = (short)t1;
            System.Console.WriteLine(u1);

            decimal v1 = 2003.1M;
            int w1;
            w1 = (int)v1;
            System.Console.WriteLine(w1);

            ulong x1 = 8063;
            short y1;
            y1 = (short)x1;
            System.Console.WriteLine(y1);

            sbyte z1 = 107;
            byte a2;
            a2 = (byte)z1;
            System.Console.WriteLine(a2);

            Console.WriteLine("\n");
            Console.WriteLine("Task_1c");

            int up = 69;             //упаковка
            object up1 = up;
            Console.WriteLine(up1);

            up1 = 69;                //распаковка
            up = (int)up1;
            Console.WriteLine(up1);

            Console.WriteLine("\n");
            Console.WriteLine("Task_1d");

            var str = "hallo";
            Type strType = str.GetType();
            Console.WriteLine("Тип переменной str: {0}", strType);

            Console.WriteLine("\n");
            Console.WriteLine("Task_1e");

            object x3 = null;
            object y3 = x3 ?? 100; //объединение с null
            Console.WriteLine(y3);

            Console.WriteLine("\n");
            Console.WriteLine("Task_1f");

            /*var f2 = 231;
            string f2 = "hi";
            Console.WriteLine("f2");*/

            Console.WriteLine("\n");
            Console.WriteLine("Task_2a");

            string str1 = "first";
            string str2 = "second";
            Console.WriteLine(String.Compare(str1, str2));

            Console.WriteLine("\n");
            Console.WriteLine("Task_2b");

            string str1_2 = "first string";
            string str2_2 = "second string";
            string str3_2 = "third string";
            string s2 = str1_2 + " " + str2_2; //сцепление
            Console.WriteLine(s2);
            string str2_3 = String.Copy(str1_2); //копирование
            Console.WriteLine(str2_3);
            string str3_3 = str2_2.Substring(0, 6); //выделение подстроки
            Console.WriteLine(str3_3);
            string[] str1_3 = str3_2.Split(); //разделение строки на слова
            Console.WriteLine(str1_3[1]);
            string str3_4 = str2_2.Substring(0, 6); //вставка подстроки в заданную позицию
            str1_2 = str1_2.Insert(6, str3_4);
            Console.WriteLine(str1_2);
            Console.WriteLine(str1_2.Remove(5));  //удаление заданной подстроки
            int xy = 111;
            int yx = 222;
            string result = $"{xy} + {yx} = {xy + yx}";
            Console.WriteLine(result);

            Console.WriteLine("\n");
            Console.WriteLine("Task_2c");

            string pust = "";
            string nu = null;
            bool ex = string.IsNullOrEmpty(pust);
            Console.WriteLine(ex);
            bool ex2 = string.IsNullOrEmpty(nu);
            Console.WriteLine(ex2);

            Console.WriteLine("\n");
            Console.WriteLine("Task_2d");

            StringBuilder sb = new StringBuilder("blablabla", 50);
            Console.WriteLine(sb.Remove(5, 1));
            Console.WriteLine(sb.Insert(0, "o"));
            Console.WriteLine(sb.Insert(9, "a"));

            Console.WriteLine("\n");
            Console.WriteLine("Task_3a");

            int[,] myArray = new int[4, 4]
            {
                {8, 7, 6, 5},
                {7, 8, 7, 6},
                {6, 7, 8, 7},
                {5, 6, 7, 8}
            };
            int height = myArray.GetLength(0);
            int width = myArray.GetLength(1);
            for (int y0 = 0; y0 < height; y0++)
            {
                for (int x0 = 0; x0 < width; x0++)
                {
                    Console.Write(myArray[y0, x0] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n");
            Console.WriteLine("Task_3b");

            string[] names = { "Julie", "Emma", "Emilia", "Eva", "Johny", "Jeremy" };
            Console.WriteLine($"Names: {names[0]}, {names[1]}, {names[2]}, {names[3]}, {names[4]}, {names[5]}");
            Console.WriteLine("Length of Array:{0,3}", names.Length);
            Console.WriteLine("Выберите элемент который хотите заменить: ");
            int change = int.Parse(Console.ReadLine());
            change--;
            Console.WriteLine("Введите строку");
            string schange = Console.ReadLine();
            names[change] = schange;
            for (int i3 = 0; i3 < names.Length; i3++)
            {
                Console.Write(names[i3] + ' ');
            }
           
            Console.WriteLine("\n");
            Console.WriteLine("Task_3c");

            int i4 = 0;
            int[][] myArr = new int[4][];
            myArr[0] = new int[4];
            myArr[1] = new int[6];
            myArr[2] = new int[3];
            myArr[3] = new int[4];

            for (; i4 < 4; i4++)
            {
                myArr[0][i4] = i4;
                Console.Write("{0}\t", myArr[0][i4]);
            }

            Console.WriteLine();
            for (i4 = 0; i4 < 3; i4++)
            {
                myArr[1][i4] = i4;
                Console.Write("{0}\t", myArr[1][i4]);
            }

            Console.WriteLine();
            for (i4 = 0; i4 < 2; i4++)
            {
                myArr[2][i4] = i4;
                Console.Write("{0}\t", myArr[2][i4]);
            }

            Console.WriteLine("\n");
            /*Console.WriteLine("Task_3d");

            var array = new object[0];
            var str3d = "";*/

            Console.WriteLine("\n");
            Console.WriteLine("Task_4abcd");

            (int, string, char, string, ulong) kort = (5, "string", '*', "string2", 263426613123);
            Console.WriteLine(kort.Item1);
            Console.WriteLine(kort);
            int numb = kort.Item1;
            string stri = kort.Item2;
            char star = kort.Item3;
            string stri2 = kort.Item4;
            ulong ul = (ulong)kort.Item5;

            var firstkort = ValueTuple.Create(1, 2);
            var secondkort = ValueTuple.Create(2, 1);
            Console.WriteLine(firstkort.CompareTo(secondkort));
            Console.ReadKey();

            Console.WriteLine("\n");
            Console.WriteLine("Task_5");

           static void Main(string[] args)
           {
                Tuple<int, int, int, string> task5(int[] arr, int count, string str1)
                {
                    string str9 = "string";
                    int[] nums = { 1, 2, 3, 4, 5 };
                    int min = 999999999;
                    int max = 0;
                    int sum = 0;
                    for (int i = 0; i < count; i++)
                    {
                        if (arr[i] > max) max = arr[i];
                        if (arr[i] < min) min = arr[i];
                        sum += arr[i];
                    }
                    string first = str9.Substring(0, 1);
                    var kort = Tuple.Create(min, max, sum, first);
                    Console.WriteLine(kort);
                    return kort;
                }
           }

            Console.WriteLine("\n");
            Console.WriteLine("Task_6");

            int task_a(int a)
            {
                checked
                {
                    a = a + 2;
                }
                return a;
            }
          
            int task_b(int a)
            {
                unchecked
                {
                    a = a + 2;
                }

                return a;
            }

        }
    }
}