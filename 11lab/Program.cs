using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Math;


namespace _11lab
{
    public class Vector
    {
        public int count; 
        public int[] array;  
        public bool status;  

        public Vector(int tmp)
        {
            array = new int[tmp];
            count = tmp;
            status = true;

            for (int i = 0; i < count; i++)
            {
                array[i] = 0;
            }
        }
        public bool IsNegative()
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i] < 0) return true;
            }
            return false;
        }
        public void RandomFill() 
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                array[i] = rnd.Next(-5, 10);
            }
        }
        public int[] Add(int number) 
        {
            for (int i = 0; i < count; i++)
            {
                array[i] += number;
            }
            return array;
        }
        public void Output() 
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        public bool Contains()
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i] == 0) return true;
            }
            return false;
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
    class Author
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
    class Book
    {
        public string Title { get; set; }
        public string Person { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //////////////1  4
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] summer_winter_months = { "June", "July", "August", "January", "February", "December" };
            foreach (string obj in months)
                Console.Write(obj + ", ");

            Console.WriteLine("\nМесяцы с заданой длинной(4): ");
            IEnumerable<string> rezult1 = from n in months
                                          where n.Length < 5 && n.Length > 3
                                          select n;
            foreach (string obj in rezult1)
                Console.Write(obj + ", ");

            Console.WriteLine("\n\nМесяцы с длинной не меньше: ");
            IEnumerable<string> rezult2 = from n in months
                                          where n.Length >= 4
                                          select n;
            foreach (string obj in rezult2)
                Console.Write(obj + ", ");

            Console.WriteLine("\nМесяцы в алфавитном порядке: ");
            IEnumerable<string> rezult3 = from n in months
                                          orderby n
                                          select n;
            foreach (string obj in rezult3)
                Console.Write(obj + ", ");

            Console.WriteLine("\n\nМесяцы, содержащие букву 'u': ");
            IEnumerable<string> rezult4 = from n in months
                                          where n.Contains("u")
                                          select n;
            foreach (string obj in rezult4)
                Console.Write(obj + ", ");

            Console.WriteLine("\n\nЗимние и летние месяцы: ");
            IEnumerable<string> rezult5 = months.Intersect<string>(summer_winter_months);
            foreach (string obj in rezult5)
                Console.Write(obj + ", ");
            Console.WriteLine();

            Console.WriteLine("\n\n\nСобственный запрос: ");
            IEnumerable<string> rezult6 = months
                                          .Where(p => p.Contains("u"))
                                          .Intersect<string>(summer_winter_months)
                                          .Take(3)
                                          .Skip(1)
                                          .OrderBy(p => p);
            foreach (string obj in rezult6)
                Console.Write(obj + "\t");

            ///////////////2  3

            List<Vector> vectorlist = new List<Vector>();
            Vector vector1 = new Vector(4); vector1.RandomFill();
            Vector vector2 = new Vector(5); vector2.RandomFill();
            Vector vector3 = new Vector(3); vector2.RandomFill();
            vectorlist.Add(vector1); vectorlist.Add(vector2); vectorlist.Add(vector3);
            Console.WriteLine("\n\n\nList<Vector>: ");
            vector1.Output(); Console.WriteLine();
            vector2.Output(); Console.WriteLine();
            vector3.Output(); Console.WriteLine();
            Console.WriteLine("\nВектора, содержащие 0: ");
            var rezult7 = from p in vectorlist
                          where p.Contains()
                          select p;
            foreach (Vector v in rezult7)
            {
                v.Output(); Console.WriteLine();
            }

            Console.WriteLine("\nНаименьший модуль: ");
            var rezult8 = vectorlist.Min(p => p.Sum());
            Console.WriteLine(Math.Abs(rezult8));

            Console.WriteLine("\nВектор длины 5: ");
            var rezult9 = from p in vectorlist
                          where p.count == 5
                          select p;
            foreach (Vector v in rezult9)
                v.Output();

            Console.WriteLine("\n\nМаксимальное значение вектора: ");
            var rezult10 = vectorlist.Max(p => p.Sum());
            Console.WriteLine(rezult10);

            Console.WriteLine("\nПервый вектор с отрицательным значением: ");
            var rezult11 = vectorlist.First(p => p.IsNegative());
            rezult11.Output();

            Console.WriteLine("\n\nСписок, упорядоченный по размеру: ");
            var rezult12 = vectorlist.OrderBy(p => p.count);
            foreach (Vector v in rezult12)
            {
                v.Output(); Console.WriteLine();
            }

            ///////////////5
            Console.WriteLine("\n\nЗапрос с оператором Join: ");
            List<Author> authors = new List<Author>()
                {
                   new Author { Name = "Льюис Кэрролл", Title ="Алиса в Стране чудес" },
                   new Author { Name = "Уильям Шекспир", Title ="Ромео и Джульетта" }
                };
            List<Book> books = new List<Book>()
                {
                new Book { Title = "Ромео и Джульетта", Person ="Ромео" },
                   new Book { Title = "Алиса в Стране чудес", Person ="Алиса" }
                   
                };
            var result13 = from p in books
                           join t in authors on p.Title equals t.Title
                           select new { Name = t.Name, Title = p.Title, Person = p.Person };

            foreach (var item in result13)
                Console.WriteLine($"{item.Name} - {item.Title} ({item.Person})");

            Console.ReadKey();
        }
    }
}
