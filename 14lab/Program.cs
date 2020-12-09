using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace _14lab
{
    class Phone
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
    [Serializable]
    public class Programmer
    {
        public string Name { get; set; }
        public Programmer()
        {
            Name = "Programmer_Name";
        }
        public Programmer(string name) 
        {
            Name = name;
        }
        public void Info()
        {
            Console.WriteLine("Name: " + Name);
        }
    }
    [Serializable]
    class Game : Programmer
    {
        public int Year { get; set; }
        public Game()
        {
            Year = 2020;
        }
        public Game(string name, int year) : base(name)
        {
            Year = year;
        }
        public void Info()
        {
            Console.WriteLine("Year: " + Year);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /////////////1
            Game game1 = new Game("N1", 2021);
            Console.WriteLine("Бинарная сериализация");
            BinaryFormatter formatter = new BinaryFormatter(); // создаем объект BinaryFormatter
            using (FileStream fs = new FileStream("games.dat", FileMode.OpenOrCreate))// получаем поток, куда будем записывать сериализованный объект
            {
                formatter.Serialize(fs, game1);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("games.dat", FileMode.OpenOrCreate))// десериализация из файла
            {
                Game newgame = (Game)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Name: {newgame.Name}, Year: {newgame.Year}");
            }

            Console.WriteLine("\n\nСериализация в формат SOAP");
            Game game2 = new Game("N2", 2022);
            SoapFormatter formatter2 = new SoapFormatter();// создаем объект SoapFormatter
            using (FileStream fs2 = new FileStream("games2.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs2, game2);

                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs2 = new FileStream("games2.soap", FileMode.OpenOrCreate))
            {
                Game newgame2 = (Game)formatter.Deserialize(fs2);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Name: {newgame2.Name}, Year: {newgame2.Year}");
            }

            /////////////////
            Console.WriteLine("\n\nСериализация в JSON");
            Game game3 = new Game("N3", 2023);
            string json = JsonConvert.SerializeObject(game3);
            Console.WriteLine(json);
            Game restoredGame = JsonConvert.DeserializeObject<Game>(json);
            Console.WriteLine(restoredGame.Name);

            Console.WriteLine("\n\nСериализация в XML");
            Programmer prog1 = new Programmer("N4");
            XmlSerializer formatter4 = new XmlSerializer(typeof(Programmer));
            using (FileStream fs4 = new FileStream("progers.xml", FileMode.OpenOrCreate))// получаем поток, куда будем записывать сериализованный объект
            {
                formatter.Serialize(fs4, prog1);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs4 = new FileStream("progers.xml", FileMode.OpenOrCreate))
            {
                Programmer newProgrammer = (Programmer)formatter.Deserialize(fs4);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Name: {newProgrammer.Name}");
            }

            ///////////2
            Programmer prog2 = new Programmer("N5");
            Programmer prog3 = new Programmer("N6");
            Programmer[] progers = new Programmer[] { prog2, prog3 };
            XmlSerializer formatter5 = new XmlSerializer(typeof(Programmer[]));
            Console.WriteLine("\n\nСериализация массивa объектов");
            using (FileStream fs5 = new FileStream("progers5.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs5, progers);
            }
            using (FileStream fs5 = new FileStream("progers5.xml", FileMode.OpenOrCreate))
            {
                Programmer[] newprog = (Programmer[])formatter.Deserialize(fs5);
                foreach (Programmer g in newprog)
                {
                    Console.WriteLine($"Name: {g.Name}");
                }
            }

            /////////////3
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("users.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            Console.WriteLine("\n\nXPath: селекторы для XML документа\n");
            Console.WriteLine("Все дочерниt узлы");
            XmlNodeList childnodes = xRoot.SelectNodes("*");// выбор всех дочерних узлов
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            Console.WriteLine("\nВсе узлы <user>");
            XmlNodeList childnodes2 = xRoot.SelectNodes("user");//Выберем все узлы <user>
            foreach (XmlNode n in childnodes2)
                Console.WriteLine(n.SelectSingleNode("@name").Value); 

            Console.WriteLine("\nAтрибут name имеет значение 'Bill Gates'");
            XmlNode childnode = xRoot.SelectSingleNode("user[@name='Bill Gates']");//атрибут name имеет значение "Bill Gates"
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);

            ////////////4
            Console.WriteLine("\n\nLinq to XML\n");
            XDocument xdoc = XDocument.Load("phones.xml");
            foreach (XElement phoneElement in xdoc.Element("phones").Elements("phone"))//обращение к корневому эл-ту
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");//получаем атрибуты
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Смартфон: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("1)");
            var items = from xe in xdoc.Element("phones").Elements("phone")
                        where xe.Element("company").Value == "Samsung"
                        select new Phone
                        {
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value
                        };
            foreach (var item in items)
                Console.WriteLine($"{item.Name} - {item.Price}");
            Console.WriteLine("2)");
            var items2 = from xe in xdoc.Element("phones").Elements("phone")
                         where xe.Element("price").Value == "40000"
                         select new Phone
                         {
                             Name = xe.Attribute("name").Value,
                             Price = xe.Element("price").Value
                         };
            foreach (var item in items2)
                Console.WriteLine($"{item.Name} - {item.Price}");




            Console.ReadKey();
        }
    }
}
