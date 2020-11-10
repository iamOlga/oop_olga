using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace _8lab
{
    class PO
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
    }
    public class CollectionType<T> //where T : class   //ограничение
    {
        public List<T> List;
        public static int count = 0;
        public CollectionType()
        {
            List = new List<T>();
            count++;
        }
        public CollectionType(int z)
        {
            List = new List<T>(z);
            count++;
        }
        public void Add(T obj)
        {
            List.Add(obj);
        }
        public void Output()
        {
            foreach (T obj in List)
            {
                Console.WriteLine(obj);
            }
        }
        public void Delete(T obj)
        {
            if (List.Contains(obj))
            {
                List.Remove(obj);
            }
            else
            {
                throw new ValueException("Такого элемента не существует.");
            }
        }
        public void Write(string fileName)//запись в файл
        {
            StreamWriter Writer = new StreamWriter("../../../" + fileName + ".txt");
            foreach (T element in List)
            {
                Writer.WriteLine(element);
            }
            Writer.Close();
        }
        public void Read(string fileName)//чтение из файла
        {
            StreamReader Reader = new StreamReader("../../../" + fileName + ".txt");
            Console.WriteLine(Reader.ReadToEnd());
            Reader.Close();
        }
    }
    class ValueException : Exception
    {
        public string Message { get; set; }
        public ValueException(string message)
        {
            Message = message; 
        }
    }
    interface IInterface<T>           //обобщенный интерфейс
    {
        void Add(T obj);
        void Delete(T obj);
        void Output();
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            CollectionType<int> List1 = new CollectionType<int>();
            for(int i=1; i<6; i++)
            {
                List1.Add(i);
            }

            CollectionType<string> List2 = new CollectionType<string>();
            List2.Add("q");
            List2.Add("w");
            List2.Add("e");
            List2.Add("r");
            List2.Add("t");

            CollectionType<TextProcessor> List3 = new CollectionType<TextProcessor>();
            TextProcessor tpr1 = new TextProcessor("TextProcessor1", 2008);
            TextProcessor tpr2 = new TextProcessor("TextProcessor2", 2012);
            TextProcessor tpr3 = new TextProcessor("TextProcessor3", 2014);
            List3.Add(tpr1);
            List3.Add(tpr2);
            List3.Add(tpr3);

            List1.Write("File_numbers");
            try
            {
                List1.Delete(6);
                Console.WriteLine("выполнение блока try");
            }
            catch(ValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("выполнение блока finally\nвывод списка:");
                List1.Output();
            }

            Console.WriteLine("------------------------");

            List2.Write("File_letters");
            try
            {
                List2.Delete("t");
                Console.WriteLine("выполнение блока try");
            }
            catch (ValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("выполнение блока finally\nвывод списка:");
                List2.Output();
            }

            Console.WriteLine("------------------------");

            Console.WriteLine("чтение файла 1");
            List1.Read("File_numbers");
            Console.WriteLine("------------------------");

            Console.WriteLine("чтение файла 2");
            List2.Read("File_letters");

            Console.ReadKey();
        }
    }
}
