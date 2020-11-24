using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _10lab
{
    class Student
    {
        private string name;
        public string Name { get ; set ; }
        public Student(string str)
        {
            Name = str;
        }
        public override string ToString()
        {
            return $"Student {Name}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //
            ArrayList list = new ArrayList();
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                list.Add(Convert.ToString(rnd.Next(0, 20)));
            list.Add("Some string");
            Student student = new Student("Olga");
            list.Add(student);

            Console.WriteLine("ArrayList: ");
            foreach (object obj in list)
                Console.Write(obj + "; ");
            Console.WriteLine("\nРазмер: " + list.Count);

            Console.WriteLine("\nВыберите номер удаляемого элемента(с 0): ");
            list.Remove(Console.ReadLine());
            Console.WriteLine("Элемент удален");

            Console.WriteLine("\nВведите элемент для поиска: ");
            if (list.Contains(Console.ReadLine()))
                Console.WriteLine("Элемент содержится в коллекции");
            else Console.WriteLine("Элемент не содержится в коллекции");

//
            Stack<char> sumbols = new Stack<char>();
            sumbols.Push('q');
            sumbols.Push('w');
            sumbols.Push('e');
            sumbols.Push('r');
            sumbols.Push('t');
            Console.WriteLine("\n\nStack<T>: ");
            foreach (object obj in sumbols)
                Console.Write(obj + "; ");

            Console.Write("\nВведите кол-во удаляемых элементов: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                sumbols.Pop();
            foreach (object obj in sumbols)
                Console.Write(obj + "; ");

            char new_obj;
            Console.Write("\nВведите новый добавляемый элемент(0 - для выхода): ");
            for (; ; )
            {
                new_obj = Convert.ToChar(Console.ReadLine());
                if (new_obj == '0') break;
                sumbols.Push(new_obj);
            }
            foreach (object obj in sumbols)
                Console.Write(obj + "; ");

//
            Console.WriteLine("\n\n\nList<T>: ");
            List<char> sumb_list = new List<char>();
            int len= sumbols.Count;
            for (int i = 0; i < sumbols.Count+ len; i++)
            {
                sumb_list.Add(sumbols.Pop());
                Console.Write(sumb_list[i] + "; ");
            }
            Console.Write("\n\nВведите элемент для поиска: ");
            if (sumb_list.Contains(Convert.ToChar(Console.ReadLine())))
                Console.WriteLine("Элемент содержится в коллекции");
            else Console.WriteLine("Элемент не содержится в коллекции");

            Console.ReadKey();
        }
    }
}
