using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_9
{
    class Program
    {    
        public static string StringProcessing(string String)
            { 
            StringProcessing str = new StringProcessing();
            Func<string, string> StringProcessingDelegate = str => str.ToLower();
            string String1 = StringProcessingDelegate(String);
            Console.WriteLine(String1);
            StringProcessingDelegate += str => str.ToUpper();
            string String2 = StringProcessingDelegate(String1);
            Console.WriteLine(String2);
            StringProcessingDelegate += str => str.Trim();
            string String3 = StringProcessingDelegate(String2);
            Console.WriteLine(String3);
            return String3;

}
        static void Main(string[] args)
        {
            User.Software Software;
            User user = new User();
            List<string> SW = new List<string> { "Windows", "MacOS", "Linux", "Android", "UNIX" };
            foreach (string item in SW)
            {
                Console.Write(item + "\t");
            }
            user.Upgrade += (list, message) =>
            {
                Console.WriteLine(message);
                foreach (string item in list)
                {
                    Console.Write(item + "\t");
                }
            };
            user.Work += (list, message) =>
            {
                Console.WriteLine(message);
                Console.ResetColor();
            };
           
            Software = user.Loading;
            Software(SW, ""); 
            Software = user.Edit;
            Software(SW, "");
            Console.WriteLine("\n\nРабота со строками\n");


            Func<string, string> A;
            string str = "auf , Frak, кис";

            Console.WriteLine($"Исходная строка:  {str}");
            A = StringHandler.RemoveS;
            Console.WriteLine($"Без знаков препинания:  {str = A(str)}");
            A = StringHandler.RemoveSpase;
            Console.WriteLine($"Без пробелов:  {str = A(str)}");
            A = StringHandler.Upper;
            Console.WriteLine($"Заглавными буквами:  {str = A(str)}");
            A = StringHandler.Lower;
            Console.WriteLine($"Строчными буквами:  {str = A(str)}");
            A = StringHandler.AddToString;

            Console.WriteLine($"С добавлением символа:  {str = A(str)}");

        }

    }
}
