using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3lab
{
    class Vector
    {
        public int[] items;
        public int count;
        public int status;

        //конструкторы
        public Vector()//без параметров
        {
            items = new int[10];
            count = 10;
            status = 1;
            for (int i = 0; i < count; i++)
            {
                items[i] = 0;
            }
        }
        public Vector(int N)//с параметром
        {
            items = new int[N];
            count = N;
            status = 1;
            for (int i = 0; i < count; i++)
            {
                items[i] = 0;
            }

        }
        public Vector(int N, int a = 1)//с параметром по умолчанию
        {
            items = new int[N];
            count = N;
            status = 1;
            for (int i = 0; i < count; i++)
            {
                items[i] = a;
            }

        }

        //индексатор
        public int this[int i]
        {
            get
            {
                return items[i];
            }
            set
            {
                items[i] = value;
            }
        }
        public void Random()//заполнение массива
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < count; i++)
            { 
                items[i] = random.Next(10);
            }
        }
        public int[] Addition(int x) //сложение  эт-ов с числом
        {
            for (int i = 0; i < count; i++)
            {
                items[i] += x;
            }
            return items;
        }
        public int[] Multiplication(int q) //сложение  эт-ов на число
        {
            for (int i = 0; i < count; i++)
            {
                items[i] *= q;
            }
            return items;
        }
        public void OutputArr()//вывод массива
        {
            
            for (int i = 0; i < count; i++)
            {
                Console.Write(items[i]+"\t");
            }
            Console.Write("\n");
        }
        public bool hasNull()
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public double Module()
        {
            double module = 0;
            for (int i = 0; i < count; i++)
            {
                module += Math.Abs(items[i]);
            }
            return module;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1.Создание массива векторов\n2.Сложение эл-ов с числом\n3.Умножение эл-ов на число\n4.Векторов с 0\n5.Вектора с наим. модулем");
            int status;
            //Vector items1 = new Vector();//создание с помощью конструкторов
            //Vector items2 = new Vector(20);
            //Vector items3 = new Vector(5, 1);

            Vector[] items = new Vector[5];
            for (; ; )
            {
                Console.Write("\nСделайте выбор: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice <= 5)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\nВывод массива: ");
                            for (int i = 0; i < items.Length; i++)
                            {
                                items[i] = new Vector(2);
                                items[i].Random();
                                items[i].OutputArr();
                            }
                            status = 1;
                            Console.WriteLine("Статус операции: " + status);
                            break;
                        case 2:
                                Console.Write("\nВведите число для сложения: ");
                                int x = int.Parse(Console.ReadLine());
                                for (int i = 0; i < items.Length; i++)
                                {
                                    items[i].Addition(x);
                                    items[i].OutputArr();
                                }
                                status = 1;
                                Console.WriteLine("Статус операции: " + status);
                            break;
                        case 3:
                                Console.Write("\nВведите число для умножения: ");
                                int q = int.Parse(Console.ReadLine());
                                for (int i = 0; i < items.Length; i++)
                                {
                                    items[i].Multiplication(q);
                                    items[i].OutputArr();
                                }
                                status = 1;
                                Console.WriteLine("Статус операции: " + status);
                            break;
                        case 4:
                            bool hasNull = true;
                            for (int i = 0; i < items.Length; i++)
                            {
                                if (items[i].hasNull())
                                {
                                    if (hasNull)
                                    {
                                        Console.WriteLine("Список векторов, содержащих нули:");
                                        hasNull = !hasNull;
                                    }
                                    items[i].OutputArr();
                                    status = 1;
                                    Console.WriteLine("Статус операции: " + status);
                                }
                            }
                            if (hasNull)
                            {
                                Console.WriteLine("Нет векторов, содержащих 0.");
                                status = 0;
                                Console.WriteLine("Статус операции: " + status);
                            }
                            break;
                        case 5:
                            int minModIndex = 0;
                            for (int i = 1; i < items.Length; i++)
                            {
                                if (items[i].Module() < items[minModIndex].Module())
                                {
                                    minModIndex = i;
                                }
                            }
                            Console.WriteLine("Вектор с наименьшим модулем:");
                            items[minModIndex].OutputArr();
                            Console.Write("Модуль: ");
                            Console.WriteLine(items[minModIndex].Module());
                            break;
                    }
                }
                else
                    break;
            }
            Console.ReadKey();
        }
    }
}
