using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Developer -> Programmer - Saper
//Developer -> Programmer - Virus
//PO -> OperationsSet
//PO -> TextProcessor -> Word 
namespace _5lab
{
    //интерфейс
    interface IInterface
    {
        void Start();
        void End();
    }
    abstract class PO
    {
        public string Name { get; set; }

        public PO()
        {
            Name = "PO_name";
        }
        public PO(string name)
        {
            Name = name;
        }
        public void PrintInfo()
        {
            Console.WriteLine("PO name: " + Name);
        }
        public override string ToString()
        {
            return $"Type: {this.GetType()}, Name: {Name}";
        }
        
    }
    class TextProcessor : PO
    {
        public int Year { get; set; }
        public TextProcessor() : base()
        {
            Year = 2012;
        }
        public TextProcessor(string name, int year) : base(name)
        {
            Year = year;
        }
        public void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Year: " + Year);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Year: {Year}";
        }
    }
    class Word: TextProcessor
    {
        public string Office { get; set; }
        public Word() : base()
        {
            Name = "Word";//override default field's value
            Year = 2016;
            Office = "Microsoft";
        }
        public Word(string name, int year, string office) : base(name, year)
        {
            Office = office;
        }
        public void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Office: " + Office);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Office: {Office}";
        }
    }
    class OperationsSet : PO
    {
        public string Id { get; set; }
        public OperationsSet()
        {
            Name = "OpSet";
            Id = "xxx";
        }
        public void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Id: " + Id);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Id: {Id}";
        }
    }
    class Developer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Developer()
        {
            Name = "Developer_Name";
            Surname = "Developer_SurName";
        }
        public Developer(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public void Info()
        {
            Console.WriteLine("Имя: " + Name +" "+ Surname);
        }
        public override string ToString()
        {
            return $"Type: {this.GetType()}, Name: {Name}, Surname: {Surname}";
        }

    }
    class Programmer : Developer
    {
        public string Language { get; set; }
        public Programmer()
        {
            Name = "Programmer_Name";
            Surname = "Programmer_SurName";
            Language = "c#";
        }
        public Programmer(string name, string surname, string language) : base(name, surname)
        {
            Language = language;
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine("Language: " + Language);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Language: {Language}";
        }
    }
    class Saper : Programmer, IInterface
    {
        public double Version { get; set; }
        public Saper()
        {
            Version = 13.4;
        }
        public Saper(string name, string surname, string language, double version) : base(name, surname, language)
        {
            Version = version;
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine("Version: " + Version);
        }
        public void Start()
        {
            Console.WriteLine("Игра Сапер началась!");
        }
        public void End()
        {
            Console.WriteLine("Игра Сапер завершилась!");
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Version: {Version}";
        }
    }
    sealed class Virus : Programmer//бесплодный класс
    {
        public bool Isworked { get; set; }
        public Virus()
        {
            Isworked = true;
        }
        public Virus(string name, string surname, string language, bool isworked) : base(name, surname, language)
        {
            Isworked = isworked;
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine("Is virus work? " + Isworked);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Isworked: {Isworked}";
        }
    }
    //одноименные методы в интерфейсе и абстрактном классе
    interface IInterface2
    {
        void Method();
    }
    abstract class Game
    {
        public abstract void Method();
    }
    class CConficker : Game, IInterface2
    {
        public override void Method()/////////
        {
            Console.WriteLine("Вызван метод абстрактного класса");
        }
        void IInterface2.Method()
        {
            Console.WriteLine("Вызван метод интерфейса");
        }
    }
    class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Developer:\n");
            Developer dvlp1 = new Developer();
            dvlp1.Info();
            Developer dvlp2 = new Developer("Olga", "Babich");
            dvlp2.Info();
            Console.WriteLine("\nProgrammer:\n");
            Programmer proger1 = new Programmer();
            proger1.Info();
            Programmer proger2 = new Programmer("Olga", "Babich", "c++");
            proger2.Info();

            Console.WriteLine("-----------");

            Console.WriteLine("\nText_Processor:\n");
            TextProcessor textproc1 = new TextProcessor();
            textproc1.PrintInfo();
            Console.WriteLine();
            TextProcessor textproc2 = new TextProcessor("EtherPad", 2008);
            textproc2.PrintInfo();

            Console.WriteLine("-----------");

            Console.WriteLine("\nWord:\n");
            Word word1 = new Word();
            word1.PrintInfo();
            Console.WriteLine();
            Word word2 = new Word("Word", 2012, "Microsoft");
            word2.PrintInfo();

            Console.WriteLine("-----------");

            Console.WriteLine("\nSaper:\n");
            Saper saper1 = new Saper();
            saper1.Info();
            Console.WriteLine();
            Saper saper2 = new Saper("Name2", "Surname2", "c++", 13.5);
            saper2.Info();

            Console.WriteLine("-----------");

            Console.WriteLine("\nVirus:\n");
            Virus virus1 = new Virus();
            virus1.Info();
            Console.WriteLine();

            Virus virus2 = new Virus("NameVir", "SurnameVir", "c++", true);
            virus2.Info();
            Console.WriteLine();

            Console.WriteLine("-----------");

            Console.WriteLine("\nInterfaces:\n");
            saper1.Start();
            saper1.End();

            Console.WriteLine("\n-----------");

            Console.WriteLine("\nОдноименные методы:\n1)");
            Game game = new CConficker();
            game.Method();
            ((IInterface2)game).Method();
            Console.WriteLine("2)");
            IInterface2 game2 = new CConficker();
            game2.Method();

            Console.WriteLine("\n-----------");

            Console.WriteLine("\nИдентификация типов об-ов с исп. is или as:\n");
            if (game2 is CConficker)
                Console.WriteLine("Объект интерфейсного типа совпадает с типом Game");
            else
                Console.WriteLine("Объект интерфейсного типа не совпадает с типом Game");
            if (game is IInterface2)
                Console.WriteLine("Тип Game совпадает с интерфейсным типом");
            else
                Console.WriteLine("Тип Game не совпадает с интерфейсным типом");

            Console.WriteLine("\n-----------");

            Console.WriteLine("\nToString:\n");
            Console.WriteLine(dvlp1.ToString());
            Console.WriteLine(proger1.ToString());
            Console.WriteLine(textproc1.ToString());
            Console.WriteLine(word1.ToString());
            Console.WriteLine(saper1.ToString());
            Console.WriteLine(virus1.ToString());

            Console.WriteLine("\n-----------");

            Console.WriteLine("\nClass Printer:\n");//dvlp1, proger1, textproc1, word1, saper1, virus1, Printer
            Printer Printer = new Printer();
            Object[] objectsMas = new Object[] { dvlp2, proger2, textproc2, word2, saper2, virus2, Printer };
            for (int i = 0; i < objectsMas.Length; i++)
            {
                Console.WriteLine(Printer.IAmPrinting(objectsMas[i]));
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
