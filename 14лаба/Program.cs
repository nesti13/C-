using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.SOAP;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;


namespace _14
{
    class Program
    {
        static void Main(string[] args)
        {
            //B I N A R Y
            Console.WriteLine("Binary");
            Gym gym1 = new Gym("Body Shop", " Уильям Глен Гарольд Херрингтон");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("gym.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, gym1);
            }
            using (FileStream stream = new FileStream("gym.dat", FileMode.OpenOrCreate))        ///десериал.
            {
                Gym gyms = (Gym)formatter.Deserialize(stream);
                Console.WriteLine($"Десериализован: {gyms.Name}, Тренер: {gyms.Master}\n");
            }

            //using (FileStream stream = new FileStream("gym.soap", FileMode.OpenOrCreate))       ///сериал.
            //{
            //    Gym gym1_1 = new Gym("Рикардо Милос", "Nico Nico Douga");
            //    soapFormatter.Serialize(stream, gym1_1);
            //}


            //using (FileStream stream = new FileStream("gym.soap", FileMode.OpenOrCreate))        ///десериал.
            //{
            //    Gym gym1_11 = (Gym)soapFormatter.Deserialize(stream);
            //    Console.WriteLine($"Десериализован: {gym1_11.Name}, Тренер: {gym1_11.Master}\n");
            //}


            //X M L 
            XmlSerializer serializer = new XmlSerializer(typeof(Gym));
            Console.WriteLine("XML");
            Gym gym2 = new Gym("Парни со свалки", " Денни Ли");

            using (FileStream stream = new FileStream("gym.xml", FileMode.OpenOrCreate))            ///сериализ.
            {

                serializer.Serialize(stream, gym2);
            }


            using (FileStream stream = new FileStream("gym.xml", FileMode.OpenOrCreate))   //OpenOrCreate: если файл существует, он открывается, если нет - создается новый         ///десериал.
            {
                Gym gym2_1 = (Gym)serializer.Deserialize(stream);
                Console.WriteLine($"Десериализован: {gym2_1.Name}, Тренер: {gym2_1.Master}\n");
            }




            //J S O N 
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Gym));
            Console.WriteLine("JSON");
            Gym gym3 = new Gym("Deep Dark Fantasies", " Ван Даркхолм");  
            // сохранение данных
            using (FileStream stream = new FileStream("gym.json", FileMode.OpenOrCreate))               ///сериал.
            {

                jsonSerializer.WriteObject(stream, gym3);
            }

            // чтение данных
            using (FileStream stream = new FileStream("gym.json", FileMode.OpenOrCreate))               ///десериал.
            {
                Gym sgym3 = (Gym)jsonSerializer.ReadObject(stream);
                Console.WriteLine($"Десериализован: зал: {sgym3.Name}, Тренер: {sgym3.Master}\n");
            }

            //S E R I A L I Z E R 
            //C O L L E C T I O N 
            XmlSerializer collser = new XmlSerializer(typeof(List<Gym>));
            List<Gym> list = new List<Gym>();
            list.Add(gym1);
            list.Add(gym2);
            list.Add(gym3);
            using (FileStream fs = new FileStream("Collection.xml", FileMode.OpenOrCreate))
            {
                collser.Serialize(fs, list);
            }
            Console.WriteLine("Коллекция");
            using (FileStream fr = new FileStream("Collection.xml", FileMode.OpenOrCreate))
            {
                List<Gym> newlist = (List<Gym>)collser.Deserialize(fr);

                foreach (var thinks in newlist)
                {
                    Console.WriteLine($"Десериализован: зал: { thinks.Name}, Тренер: {thinks.Master}\n");
                }
            }


            //X - P A T H 

            XmlDocument document = new XmlDocument();
            document.Load("Collection.xml");
            XmlNode xml = document.DocumentElement;

            XmlNodeList GYMS = xml.SelectNodes("*"); // выбор всех дочерних узлов

            foreach (XmlNode item in GYMS)
            {
                Console.WriteLine($"{item.InnerText} ");
            }


            //L I N Q    T O    X M L 
            XDocument Actors = new XDocument();
            XElement puk = new XElement("Актеры");

            XElement actor;
            XElement name;
            XAttribute age;

            actor = new XElement("actor");
            name = new XElement("name", "Уильям Глен Гарольд Херрингтон");
            age = new XAttribute("age", "48");

            actor.Add(name);
            actor.Add(age);
            puk.Add(actor);

            actor = new XElement("actor");
            name = new XElement("name", "Денни Ли");
            age = new XAttribute("age", "69");

            actor.Add(name);
            actor.Add(age);
            puk.Add(actor);

            Actors.Add(puk);
            Actors.Save("Actors.xml");

            Console.WriteLine("Введите возраст:");
            string yearXML = Console.ReadLine();
            var moreActor = puk.Elements("actor");

            foreach (var thinks in moreActor)
            {
                if (thinks.Attribute("age").Value == yearXML)
                {
                    Console.WriteLine(thinks.Value);
                }
            }
        }
    }
}
