using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_9
{
    public static class StringHandler
    {
        public static string RemoveS(string str)        ///удал знаки преп
        {
            str = str.Replace(".", string.Empty);
            str = str.Replace(",", string.Empty);
            str = str.Replace("!", string.Empty);
            str = str.Replace("?", string.Empty);
            return str;
        }


        public static string AddToString(string str)    ///добавление строки
        {
            return str += "строка";
        }

        public static string RemoveSpase(string str)    ///удал пробелов
        {
            return str.Replace(" ", string.Empty);
        }

        public static string Upper(string str)          ///замена на заглавные
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], Char.ToUpper(str[i]));
            }
            return str;
        }

        public static string Lower(string str)          ///замена на строчные
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], Char.ToLower(str[i]));
            }
            return str;
        }
    }
}
