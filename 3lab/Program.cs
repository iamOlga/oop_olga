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
        
        ////статический конструктор
        //static Vector()
        //{
        //    count = 0;
        //}

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
            Random random = new Random();
            for (int i = 0; i < count; i++)
            { 
                items[i] = random.Next(100);
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
            Console.WriteLine("\nВывод массива: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(items[i]+"\t");
            }
        }
        public void OutputStatus()//вывод состояния статуса
        {
            Console.WriteLine("\nСостояние статуса: " + status);   
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1.Создание рандомного массива\n2.Вывод массива\n3.Сложение эл-ов с числом\n4.Умножение эл-ов на число");

            Vector items1 = new Vector();
            Vector items2 = new Vector(20);//создание с помощью других конструкторов
            Vector items3 = new Vector(5, 1);
            for (; ; )
            {
                Console.Write("\nСделайте выбор: ");

                int choice = int.Parse(Console.ReadLine());
                if (choice <= 5)
                {
                    switch (choice)
                    {
                        case 1:
                            items1.Random();
                            items1.status = 1;
                            Console.WriteLine("Был создан массив");
                            Console.WriteLine("Статус операции: " + items1.status);
                            break;
                        case 2:
                            try
                            {
                                items1.OutputArr();
                                items1.status = 1;                               
                                items1.OutputStatus();
                            }
                            catch
                            {
                                items1.status = 0;
                                items1.OutputStatus();
                            }
                            break;
                        case 3:
                            try
                            {
                                Console.Write("\nВведите число для сложения: ");
                                int x = int.Parse(Console.ReadLine());
                                items1.Addition(x);
                                items1.status = 1;
                                items1.OutputStatus();
                            }
                            catch
                            {
                                items1.status = 0;
                                items1.OutputStatus();
                            }
                            break;
                        case 4:
                            try
                            {
                                Console.Write("\nВведите число для умножения: ");
                                int q = int.Parse(Console.ReadLine());
                                items1.Multiplication(q);
                                items1.status = 1;
                                items1.OutputStatus();
                            }
                            catch
                            {
                                items1.status = 0;
                                items1.OutputStatus();
                            }
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
