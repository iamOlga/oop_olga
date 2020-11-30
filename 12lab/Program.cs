using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace _12lab
{
    public interface iInterface
    {
        void Random();
    }
    class Vector : iInterface
    {
        public int[] items;
        public int count;
        public Vector(int N)
        {
            items = new int[N];
            count = N;
            for (int i = 0; i < count; i++)
            {
                items[i] = 0;
            }
        }
        public void Random()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < count; i++)
            {
                items[i] = random.Next(10);
            }
        }
        public void OutputArr()//вывод массива
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(items[i] + "\t");
            }
            Console.Write("\n");
        }
    }
    class Reflector
    {
        public static void ReadFile(Type type, string method)
        {
            StreamReader streamreader = new StreamReader(@"C:\Users\Ольга\Desktop\study\2 курс\ооп\oop_olga\12lab\file.txt");
            object obj = Activator.CreateInstance(type, true);//Создает экземпляр указанного типа
            string readtoend = streamreader.ReadToEnd();//читаем файл до конца
            MethodInfo methodinfo = type.GetMethod(method);//создаем метод из переданной строки
            var result = methodinfo.Invoke(obj, new object[] { readtoend });
            (obj as Vector).OutputArr();
        }
        public static void WriteToFile(StreamWriter file, string str)
        {
            file.WriteLine(str);
            Console.WriteLine(str);
        }

        public static void FileInfo(Type t)
        {
            StreamWriter info = new StreamWriter(@"C:\Users\Ольга\Desktop\study\2 курс\ооп\oop_olga\12lab\file.txt");
            bool isinterface = t.IsInterface; //возвращает true, если тип представляет интерфейс
            bool isclass = t.IsClass;//true, если тип представляет класс
            bool isarray = t.IsArray;//true, если тип является массивом
            bool isenum = t.IsEnum;//true, если тип явл перечислением

            WriteToFile(info, "Name: " + t.Name);
            WriteToFile(info, "IsClass: " + isclass);
            WriteToFile(info, "IsArray: " + isarray);
            WriteToFile(info, "IsInterface: " + isinterface);
            WriteToFile(info, "IsEnum: " + isenum);
            WriteToFile(info, "------------------");

            MethodInfo[] methods = t.GetMethods();//b. извлекает все общедоступные публичные методы
            WriteToFile(info, "Методы: ");
            foreach (var m in methods)
                WriteToFile(info, m.ToString()); WriteToFile(info, "------------------");

            WriteToFile(info, "Методы, которые содержат заданный тип параметра: ");//е. 
            foreach (var e in methods)
            {
                var argument = e.GetParameters();// получаем параметры
                foreach (var a in argument)
                    if (a.ParameterType == typeof(Vector))
                        WriteToFile(info, e.ToString());
            }
            WriteToFile(info, "------------------");

            FieldInfo[] fields = t.GetFields();//с. получает информацию о полях класса
            WriteToFile(info, "Поля: ");
            foreach (var f in fields)
                WriteToFile(info, f.ToString()); WriteToFile(info, "------------------");

            PropertyInfo[] properties = t.GetProperties();//с. получает информацию о свойствах класса
            WriteToFile(info, "Свойства класса: ");
            foreach (var p in properties)
                WriteToFile(info, p.ToString()); WriteToFile(info, "------------------");

            Type[] interfaces = t.GetInterfaces();//d. получает все реализованные классом интерфейсы;
            WriteToFile(info, "Интерфейсы: ");
            foreach (var i in interfaces)
                WriteToFile(info, i.ToString()); WriteToFile(info, "------------------");
            info.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.FileInfo(typeof(Vector));
            Console.WriteLine("\n");
            Reflector.ReadFile(typeof(Vector), "Random");

            Console.ReadKey();
        }
    }
}
