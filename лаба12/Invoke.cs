using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
namespace _12
{
    class Invoke
    {
        public static void Invokeg(string name1, string name2) 
        {
            Console.WriteLine($"{name1},{name2}");
            using (StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\лаба12\out.txt", true))
            {
                file.WriteLine($"{name1},{name2}");
            }
        }
    }
}
