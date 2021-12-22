using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace _12
{
    class Reflector
    {
        public static void Get_a()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();  
            Console.WriteLine(assembly.FullName);
            using (StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\лаба12\out.txt"))
            {
                file.WriteLine(assembly.FullName);
                file.WriteLine();
            }
            return;
        }
        public static bool Get_b(object ob)
            => Type
            .GetType(ob.ToString())
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
            .Length != 0;

        public static void Get_c(object ob)
        {
            Type t = ob.GetType();
            t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)  
            .ToList()
            .ForEach(x => Console.Write($"{x.Name} "));
            using (StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\лаба12\out.txt", true))
            {
                t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .ToList()
            .ForEach(x => file.WriteLine($"{x.Name} "));
            }
        }
        public static void Get_d(object ob)
        {
            Type t = ob.GetType();
            t.GetProperties()  
            .ToList()
            .ForEach(x => Console.Write($"{x.Name} "));
            using (StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\лаба12\out.txt", true))
            {
                t.GetProperties()
                .ToList()
                .ForEach(x => file.WriteLine($"{x.Name} "));
            }

        }
        public static void Get_e(object ob)
        {
            Type t = ob.GetType();
            t.GetInterfaces()
            .ToList()
            .ForEach(x => Console.Write($"{x.Name} "));
            using (StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\лаба12\out.txt", true))
            {
                t.GetInterfaces()
               .ToList()
                .ForEach(x => file.WriteLine($"{x.Name} "));
            }

        }
        public static void Get_f(object ob, string par)
        {
            Type t = ob.GetType();
            t.GetMethods()
            .Where(x => x.GetParameters().Any(n => n.ToString() == par))
            .ToList()
            .ForEach(x => Console.Write($"{x.Name} "));
            using (StreamWriter file = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\лаба12\out.txt", true))
            {
                t.GetMethods()
                .Where(x => x.GetParameters().Any(n => n.ToString() == par))
                .ToList()
                .ForEach(x => file.WriteLine($"{x.Name} "));
            }
        }
       
        static public void Invoke(string classname, string methode)         
                                                                             
        {
            Type type = Type.GetType(classname);
            List<string> list = File.ReadAllLines(@"C:\Users\Admin\Desktop\ооп\лаба12\text.txt").ToList();
            List<string>[] list2 = new List<string>[] { list };
            try
            {
                object obj = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod(methode);
                Console.WriteLine(methodInfo.Invoke(obj, list2));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static object Create(string Name, string Director)  //создает объект переданного типа и возвращает пользователю его
        {
            Type type = typeof(Serial);
            ConstructorInfo info = type.GetConstructor(new Type[] { typeof(string), typeof(string) });
            object obj = info.Invoke(new object[] { Name, Director });  

            return obj;
        }
    }
}
