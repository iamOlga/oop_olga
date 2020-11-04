using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace _7lab
{
    static class Computer
    {
        static public List<Developer> Developers = new List<Developer>(6);
        static public void Add(Developer obj)
        {
            Developers.Add(obj);
        }
        static public void Print()
        {
            foreach (Developer p in Developers)
            {
                p.Info();
                Console.WriteLine();
            }
        }
        static public void DeleteByIndex(int index)             //удаление по индексу
        {
            if (index > Developers.Count || index < 0)
            {
                throw new RangeException(
                    "Попытка удалить несуществующий элемент",
                    "Обращение к null"
                );
            }
            else
            {
                Developers.RemoveAt(index);//удаление
            }
        }
    }
    class RangeException : Exception                 //класс исключений
    {
        public string Cause { get; set; }
        public string ExcName { get; set; }
        public string Date { get; set; }
        public RangeException(string name, string message)
        {
            Cause = message;
            ExcName = name;
            Date = DateTime.Now.ToLongTimeString();
        }
        public string MyExcCause()
        {
            return Cause;
        }
        public string MyExcName()
        {
            return ExcName;
        }
        public string MyExcDate()
        {
            return Date + " (кастомное исключение 1)";
        }
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
            Debug.Assert(year < 2000 , "Uncorrect values");///////////////////////Assert
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
        public static struc s = new struc();
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
            Console.WriteLine("Genre: " + Genre + ", year: " + s.Year);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Genre: {Genre}, year: {s.Year}";
        }
    }
    enum VirusName
    {
        Strorm,
        Sasser,
        Nimda
    };
    class Virus : Programmer
    {
        public bool Isworked { get; set; }
        public VirusName NameV { get; set; } 
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
            Game GameEx = new Game();
            Virus VirusEx = new Virus();
            Game GameEx1 = new Game("A_Surname", "c++", "Simulators", 2019);
            Game GameEx2 = new Game("B_Surname", "c#", "Arcade", 2020);
            Game GameEx3 = new Game("C_Surname", "js", "Arcade", 2015);
            Computer.Developers.Add(GameEx);
            Computer.Developers.Add(GameEx1);
            Computer.Developers.Add(GameEx2);

            //1
            Console.WriteLine("Исключениe 1:\n");
            try
            {
                Computer.DeleteByIndex(-1);//Вызовется исключение
            }
            catch (RangeException ex)
            {
                Console.WriteLine("Error Name: " + ex.MyExcName());
                Console.WriteLine("Reason:  " + ex.MyExcCause());
                Console.WriteLine("Time:  " + ex.MyExcDate());
            }
            finally
            {
                Console.WriteLine("Блок выполнился");
            }
//2
            Console.WriteLine("\n\nИсключениe 2:\n");
            try
            {
                Game GameEx4 = new Game("D_Surname", "js", "Arcade", 2017);
                Console.WriteLine("Исключений нет");
            }
            catch (RangeException ex)
            {
                Console.WriteLine("Error Name: " + ex.MyExcName());
                Console.WriteLine("Reason:  " + ex.MyExcCause());
                Console.WriteLine("Time:  " + ex.MyExcDate());
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
            finally
            {
                Console.WriteLine("Блок выполнился");
            }
//3         
            Console.WriteLine("\n\nИсключениe 3:\n");
            try
            {
                object obj = 55;
                string str = (string)obj;
                Console.WriteLine($"Результат: {str}");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Исключение InvalidCastException! Неверное преобразование типов!");
            }
            finally
            {
                Console.WriteLine("Блок выполнился");
            }
            //4           
            Console.WriteLine("\n\nИсключениe 4:\n");
            try
            {
                string str2 = null;
                str2.ToUpper();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Исключение NullReferenceException! Обращение к типу, который равен 0!");
            }
            finally
            {
                Console.WriteLine("Блок выполнился");
            }



            Console.ReadKey();
        }
    }
}
