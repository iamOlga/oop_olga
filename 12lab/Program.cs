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
        public void Sum(int a)
        {
            Console.Write("Сумма: ");
            int b = 5;
            Console.Write(a + b);
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

        public static void ToFile(Type t)
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

            MethodInfo[] methods = t.GetMethods();// извлекает все общедоступные публичные методы
            WriteToFile(info, "Методы: ");
            foreach (var m in methods)
                WriteToFile(info, m.ToString()); WriteToFile(info, "------------------");

            FieldInfo[] fields = t.GetFields();// получает информацию о полях класса
            WriteToFile(info, "Поля: ");
            foreach (var f in fields)
                WriteToFile(info, f.ToString()); WriteToFile(info, "------------------");

            PropertyInfo[] properties = t.GetProperties();// получает информацию о свойствах класса
            WriteToFile(info, "Свойства класса: ");
            foreach (var p in properties)
                WriteToFile(info, p.ToString()); WriteToFile(info, "------------------");

            Type[] interfaces = t.GetInterfaces();// получает все реализованные классом интерфейсы;
            WriteToFile(info, "Интерфейсы: ");
            foreach (var i in interfaces)
                WriteToFile(info, i.ToString()); WriteToFile(info, "------------------");
            info.Close();
        }

        public static void InsaneMethod(Vector obj, string mth)//f.
        {
            FileStream f = new FileStream(@"C:\Users\Ольга\Desktop\study\2 курс\ооп\oop_olga\12lab\message.txt", FileMode.Open);
            StreamReader reader = new StreamReader(f);
            object[] stroke = { Convert.ToInt32(reader.ReadLine()) };
            Type t = typeof(Vector);
            MethodInfo metod = t.GetMethod(mth);
            object m = metod.Invoke(obj, stroke);
            Console.WriteLine(m);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector = new Vector(5);
            Reflector.ToFile(typeof(Vector));
            Console.WriteLine("\n");

            Vector vector2 = new Vector(7);
            Console.WriteLine("Получение параметров и вызов метода:");
            Reflector.InsaneMethod(vector2, "Sum");

            Console.ReadKey();
        }
    }
}
