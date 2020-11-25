using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace _10lab
{
    class Student
    {
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1
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

            Console.WriteLine("\nВыберите удаляемый элемент: ");
            list.Remove(Console.ReadLine());
            foreach (object obj in list)
                Console.Write(obj + "; ");
            Console.WriteLine("Элемент удален");

            Console.WriteLine("\nВведите элемент для поиска: ");
            if (list.Contains(Console.ReadLine()))
                Console.WriteLine("Элемент содержится в коллекции");
            else Console.WriteLine("Элемент не содержится в коллекции");

            //2
            Console.WriteLine("\n\n\nStack<T>: ");
            Stack<char> sumbols = new Stack<char>();
            sumbols.Push('q');
            sumbols.Push('w');
            sumbols.Push('e');
            sumbols.Push('r');
            sumbols.Push('t');
            foreach (char obj in sumbols)
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
            int len = sumbols.Count;
            for (int i = 0; i < sumbols.Count + len; i++)
            {
                sumb_list.Add(sumbols.Pop());
                Console.Write(sumb_list[i] + "; ");
            }
            Console.Write("\n\nВведите элемент для поиска: ");
            if (sumb_list.Contains(Convert.ToChar(Console.ReadLine())))
                Console.WriteLine("Элемент содержится в коллекции");
            else Console.WriteLine("Элемент не содержится в коллекции");

            //3
            Console.WriteLine("\n\n\nStack<Developer>: ");
            Stack<Developer> Developers = new Stack<Developer>();
            Developers.Push(new Developer() { Name = "N1" });
            Developers.Push(new Developer() { Name = "N2" });
            Developers.Push(new Developer() { Name = "N3" });
            foreach (Developer obj in Developers)
                obj.Info();

            Console.Write("\nВведите кол-во удаляемых элементов: ");
            int x = int.Parse(Console.ReadLine());
            for (int i = 0; i < x; i++)
                Developers.Pop();
            foreach (Developer obj in Developers)
                obj.Info();

            Console.Write("\nВведите новый добавляемый элемент(0 - для выхода): ");
            for (; ; )
            {
                string newnn = Console.ReadLine();
                if (newnn == "0") break;
                Developers.Push(new Developer() { Name = newnn });
            }
            Console.WriteLine();
            foreach (Developer obj in Developers)
                obj.Info();

            //
            Console.WriteLine("\n\n\nList<Developer>: ");
            List<Developer> Developers_list = new List<Developer>();

            int lenn = Developers.Count;
            for (int i = 0; i < Developers.Count + lenn; i++)
            {
                Developers_list.Add(Developers.Pop());
                Developers_list[i].Info();
            }


            //4
            Console.WriteLine("\n\n\nObservableCollection<Developer>: ");
            ObservableCollection<Developer> Developers4 = new ObservableCollection<Developer>
                {
                new Developer() { Name = "N7" },
                new Developer() { Name = "N8" },
                new Developer() { Name = "N9" }
            };
            foreach (Developer obj in Developers4)
                obj.Info();
            Console.WriteLine();
            Developers4.CollectionChanged += Developer_Changed;
            Developers4.Add(new Developer { Name = "N10" });
            Developers4.RemoveAt(0);
            Developers4[1] = new Developer { Name = "N11" };
            Console.WriteLine();
            foreach (Developer obj in Developers4)
                obj.Info();

            Console.ReadKey();
        }
        private static void Developer_Changed(object sender, NotifyCollectionChangedEventArgs x)
        {
            switch (x.Action)
            {
                case NotifyCollectionChangedAction.Add: /////добавление
                    Developer newDeveloper = x.NewItems[0] as Developer;
                    Console.WriteLine($"Добавлен объект: {newDeveloper.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: /////удаление
                    Developer delDeveloper = x.OldItems[0] as Developer;
                    Console.WriteLine($"Удален объект: {delDeveloper.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: /////замена
                    Developer replacedDeveloper = x.OldItems[0] as Developer;
                    Developer replacingDeveloper = x.NewItems[0] as Developer;
                    Console.WriteLine($"Объект {replacedDeveloper.Name} заменен объектом {replacingDeveloper.Name}");
                    break;
            }
        }
    }
}
