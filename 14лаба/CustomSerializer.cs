using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace _14
{
    class CustomSerializer
    {
        public static void Deserialize(string newname)
        {
            string[] format = newname.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter binary = new BinaryFormatter();
                        using (FileStream fr = new FileStream(newname, FileMode.Open))
                        {
                            Gym newg = (Gym)binary.Deserialize(fr);
                            Console.WriteLine($"Десиарелизован: Зал: {newg.Name}, Тренер: {newg.Master}");
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Gym));
                        using (FileStream fr = new FileStream(newname, FileMode.OpenOrCreate))
                        {
                            Gym newg = (Gym)json.ReadObject(fr);
                            Console.WriteLine($"Десиарелизован: Зал: {newg.Name}, Тренер: {newg.Master}");
                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(Gym));
                        using (FileStream fr = new FileStream(newname, FileMode.OpenOrCreate))
                        {
                            Gym newg = (Gym)xml.Deserialize(fr);
                            Console.WriteLine($"Десиарелизован: Зал: {newg.Name}, Тренер: {newg.Master}");
                        }
                        break;
                    }

            }

        }

        public static void Serialize(string newname, Gym name)
        {
            string[] format = newname.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter binarForm = new BinaryFormatter();
                        using (FileStream fs = new FileStream(newname, FileMode.OpenOrCreate))
                        {
                            binarForm.Serialize(fs, name);
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(Gym));
                        using (FileStream fs = new FileStream(newname, FileMode.OpenOrCreate))
                        {
                            jsonForm.WriteObject(fs, name);
                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(Gym));
                        using (FileStream fs = new FileStream(newname, FileMode.OpenOrCreate))
                        {
                            xmlSer.Serialize(fs, name);
                        }
                        break;
                    }
            }

        }
    }
}
