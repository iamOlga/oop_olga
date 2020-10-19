using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.StringSplitOptions;
using System.Collections.Generic;

namespace _6lab
{
    static class Computer
    {
        static public List<Developer> Developers = new List<Developer>(6);
        static public void Add(Developer obj)
        {
            Developers.Add(obj);
        }
        static public void Delete(Developer obj)
        {
            Developers.Remove(obj);
        }
        static public void Print()
        {
            foreach (Developer p in Developers)
            {
                p.Info();
                Console.WriteLine();
            }
        }
    }
    static class Controller
    {
        public enum Virus_devs
        {
            W_Surname,
            B_Surname,
            G_Surname
        }
        static public List<Developer> FindVirusByDev()//найти вирус по фамилии разработчика
        {
            bool vflag = false;
            Console.WriteLine("Выберите имя разработчика:");
            FieldInfo[] devs = typeof(Virus_devs).GetFields();
            for (int i = 1; i < devs.Length; i++)
            {
                Console.Write(i + ". " + devs[i].Name);
                Console.WriteLine();
            }
            int num_of_dev = Convert.ToInt32(Console.ReadLine());
            List<Developer> Virus = new List<Developer>();
            foreach (Developer p in Computer.Developers)
            {
                if (p.GetType() == typeof(Virus))
                { 
                    Virus virus = p as Virus;
                    if(virus.Name == devs[num_of_dev].Name)
                    {
                        Virus.Add(virus);
                        vflag = true;
                    }
                }
            }
            if (vflag == false)
                Console.WriteLine("Не найдено");
            return Virus;
        }
        public enum Game_genre
        {
            Arcade,
            Simulators,
            Strategies
        }
        static public List<Developer> FindGameByGenre()//найти игру по жанру
        {
            bool fflag = false;
            Console.WriteLine("Выберите жанр:");
            FieldInfo[] genres = typeof(Game_genre).GetFields();
            for (int i = 1; i < genres.Length; i++)
            {
                Console.Write(i + ". " + genres[i].Name);
                Console.WriteLine();
            }
            int num_of_genre = Convert.ToInt32(Console.ReadLine());
            List<Developer> Game = new List<Developer>();
            foreach (Developer p in Computer.Developers)
            {
                if (p.GetType() == typeof(Game))
                { 
                    Game sgame = p as Game;
                if (sgame.Genre == genres[num_of_genre].Name)
                {
                    Game.Add(sgame);
                        fflag = true;
                }
                }
            }
            if(fflag == false)
                Console.WriteLine("Не найдено");
            return Game;
        }
        static public List<Developer> SortByName()//сортировка в алфавитном порядке
        {
            Developer temp;
            List<Developer> List1 = new List<Developer>();
            for (int i = 0; i < Computer.Developers.Count; i++)
            {
                List1.Add(Computer.Developers[i]);
            }
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 1; i < List1.Count; i++)
                {
                    int result = String.Compare(List1[i - 1].Name, List1[i].Name);
                    if (result > 0)//1ая подстрока следует за 2ой подстрокой в порядке сортировки -> меняем местами
                    {
                        temp = List1[i - 1];
                        List1[i - 1] = List1[i];
                        List1[i] = temp;
                        flag = true;
                    }
                }
            }
            return List1;
        }
    }
    abstract partial class PO//////////////////////partial
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
    class Developer
    {
        public string Name { get; set; }

        public Developer()
        {
            Name = "Developer_Name";
        }
        public Developer(string name)
        {
            Name = name;
        }
        public void Info()
        {
            Console.WriteLine("Имя: " + Name);
        }
        public override string ToString()
        {
            return $"Type: {this.GetType()}, Name: {Name}";
        }

    }
    class Programmer : Developer
    {
        public string Language { get; set; }
        public Programmer()
        {
            Language = "c#";
        }
        public Programmer(string name, string language) : base(name)
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

    class Game : Programmer
    {
        public string Genre { get; set; }
        public struct struc
        {
            public int Year;
        }
        public static struc s = new struc();///////////////////////////////struct
        public Game()
        {
            Genre = "Arcade";
            s.Year = 2020;
        }
        public Game(string name, string language, string genre, int year) : base(name, language)
        {
            Genre = genre;
            s.Year = year;
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine("Version: " + Genre + ", year: " + s.Year);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Genre: {Genre}, year: {s.Year}";
        }
    }
    enum VirusName { Strorm, Sasser, Nimda };
    class Virus : Programmer
    {
        public bool Isworked { get; set; }
        public VirusName NameV { get; set; }//////////////////////////////////////////////////////enum
        public Virus()
        {
            Isworked = true;
            NameV = VirusName.Strorm;
        }
        public Virus(string name, string language, bool isworked, VirusName nameV) : base(name, language)
        {
            Isworked = isworked;
            nameV = VirusName.Strorm;
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine("Is virus work? " + Isworked + ", Virus name: " + VirusName.Strorm);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Isworked: {Isworked}, Virus name:{VirusName.Strorm}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENUM Game:\n");
            Game Game1 = new Game();
            Game1.Info();
            Console.WriteLine();
            Game Game2 = new Game("Surname2", "c++", "Arcade", 2021);///////////////////////////////struct
            Game2.Info();
            Console.WriteLine("-----------");

            Console.WriteLine("\n STRUCT Virus:\n");
            Virus virus1 = new Virus();
            virus1.Info();
            Console.WriteLine();
            Virus virus2 = new Virus("SurnameVir", "c++", true, VirusName.Strorm);////////////////////enum
            virus2.Info();
            Console.WriteLine("-----------");

            Console.WriteLine("Class Container:\n");////////////////////////////Class Container
            Game Game3 = new Game("A_Surname", "c++", "Simulators", 2019);
            Virus virus3 = new Virus("W_Surname", "c#", true, VirusName.Strorm);
            Virus virus4 = new Virus("B_Surname", "c++", true, VirusName.Strorm);
            Virus virus5 = new Virus("N_Surname", "JS", true, VirusName.Strorm);
            Computer.Add(new Game("H_Surname", "c#", "Strategies", 2020));
            Computer.Add(new Virus("G_Surname", "java", false, VirusName.Strorm));
            Computer.Add(virus3);
            Computer.Add(virus4);
            Computer.Add(virus5);
            Computer.Add(Game3);
            Console.WriteLine("\nВывод класса Computer: ");
            Computer.Print();
            Computer.Delete(virus4);
            Console.WriteLine("\nУдаление элемента virus4 и вывод класса Computer: ");
            Computer.Print();
            Console.WriteLine("-----------");

            Console.WriteLine("Class Controller:\n");////////////////////////////Class Controller
            List<Developer> Test1 = Controller.FindVirusByDev();
            foreach (Virus v in Test1)
            {
                v.Info();
                Console.WriteLine();
            }
            List<Developer> Test2 = Controller.FindGameByGenre();
            foreach (Game g in Test2)
            {
                g.Info();
                Console.WriteLine();
            }
            Console.WriteLine("-----------");

            Console.WriteLine("Список: ");////////////////////////////Sort
            foreach (Developer p in Computer.Developers)
            {
                p.Info();
                Console.WriteLine();
            }
            Console.WriteLine("Список в алфавитном порядке: ");
            List<Developer> Sort = Controller.SortByName();
            foreach (Developer p in Sort)
            {
                p.Info();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
