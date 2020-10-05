using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4lab
{
    public class Arr
    {
        public int[] myArr;
        public Arr()//конструктор
        {        
            myArr = new int[10];
            for (int i = 0; i < myArr.Length; i++)
            {
                myArr[i] = 0;
            }
        }
        public int this[int i]//индексатор
        {
            get
            {
                return myArr[i];
            }
            set
            {
                myArr[i] = value;
            }
        }
        public void Random()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < myArr.Length; i++)
            {
                myArr[i] = random.Next(-3, 10);
            }
        }
        public void Output()//вывод
        {
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.Write(myArr[i] + "\t");
            }
        }
        public static Arr operator *(Arr myarr1, Arr myarr2)
        {
            Arr arrmult = new Arr();
            for( int i=0; i< 10; i++)
                arrmult[i] = myarr1[i] * myarr2[i];
            return arrmult;
        }
        public static bool operator true(Arr arr)//проверка на наличие отрицательных эл-ов
        {
            for (int j = 0; j < 10; j++)
            {
                if (arr[j] < 0)
                    return false;
            }
            return true;
        }
        public static bool operator false(Arr arr)//проверка на наличие отрицательных эл-ов
        {
            for (int j = 0; j < 10; j++)
            {
                if (arr[j] < 0)
                    return false;
            }
            return true;
        }
        public static explicit operator int(Arr arr)//длина массива
        {
            return arr.myArr.Length;
        }
        public static bool operator ==(Arr myarr1, Arr myarr2)//равенство массивов
        {
            if (Equals(myarr1, myarr2))
                return true;
            else
                return false;
        }
        public static bool operator !=(Arr myarr1, Arr myarr2)
        {
            if (!Equals(myarr1, myarr2))
                return true;
            else
                return false;
        }
        public static bool operator >(Arr myarr1, Arr myarr2)//сравнение массивов
        {
            if (myarr1.SumElem() > myarr2.SumElem())
                return true;
            else
                return false;
        }
        public static bool operator <(Arr myarr1, Arr myarr2)
        {
            if (myarr1.SumElem() < myarr2.SumElem())
                return true;
            else
                return false;
        }
        public class Owner
        {
            public Owner()
            {
                id = 111;
                name = "Olga Babich";
                org = "BSTU";
            }
            public static int id { get; set; }
            public static string name { get; set; }
            public static string org { get; set; }
        }
        public class Date
        {
            public string datenow { set; get; }
            public Date()
            {
                datenow = Convert.ToString(DateTime.Now);
            }
        }
    }
    static class StatisticOperation
    {
        public static bool DeleteNull(this Arr arr)//удаление отрицательных
        { 
        int j;
        int size = arr.myArr.Length;
        bool countnull = true;
            for (int i = 0; i<size; i++)
            {
                if (arr[i] < 0)
                {
                    j = i;
                    for (; i<size - 1; i++)
                    {
                        arr[i] = arr[i + 1];
                        countnull = false;
                    }
                    i = j;
                    size--;
                }
                if (arr[i] >= 0)
                {
                    Console.Write(arr[i] + "\t");
                }
            }
            return countnull;
        }
        public static bool Containssumb(this Arr arr, int value)//проверка на содержание символа
        {

            for (int i = 0; i < arr.myArr.Length; i++)
            {
                if (arr[i] == value)
                    return true;
            }  
            return false;
        }
        public static int SumElem(this Arr arr)//сумма элементов
        {
            int sum = 0;
            for (int i= 0; i < arr.myArr.Length; i++) 
            {
                sum = sum + arr[i];
            }
            return sum;
        }
        public static int MaxMin(this Arr arr)//разница между максимальным и минимальным
        {
            int xmin = arr.myArr.Min();
            int xmax = arr.myArr.Max();
            int diffminmax = xmax - xmin;
            return diffminmax;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Arr myarr1 = new Arr();
            Arr myarr2 = new Arr();
            Console.Write("1.Создание и вывод массивов\n2.Умножение массивов\n3.Поиск символа\n4.Удаление отрицательных\n5.Проверка на равенств\n" +
                "6.Сравнение\n7.Сумма элементов\n8.Разница между min и max\n9.Owner\n10.Дата\n");
            for (; ; )
            {
                Console.Write("\nСделайте выбор: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice <= 10)
                {
                    switch (choice)
                    {
                        case 1:
                            myarr1.Random(); myarr2.Random();
                            Console.Write("\nПервый массив: "); myarr1.Output();
                            Console.Write("\nВторой массив: "); myarr2.Output();
                            break;
                        case 2:
                            {
                                Console.WriteLine("\nУмножение 2ух массивов: ");
                                Arr arrres = myarr1 * myarr2;
                                arrres.Output();
                                break;
                            }
                        case 3:
                            Console.Write("\nВведите символ для поиска: ");
                            int value = int.Parse(Console.ReadLine());
                            Console.Write("\nВ 1ом массиве: " + myarr1.Containssumb(value));
                            Console.Write("\nВо 2ом массиве: " + myarr2.Containssumb(value));
                            break;
                        case 4:
                            Console.Write("\nУдаление отрицательных: "); myarr1.DeleteNull();
                            break;
                        case 5:
                            Console.Write("\nПроверка на равенство: "); Console.Write(Equals(myarr1, myarr2));
                            break;
                        case 6:
                            Console.Write("\nmyarr1 > myarr2: "); Console.Write(myarr1 > myarr2);
                            Console.Write("\nmyarr1 < myarr2: "); Console.Write(myarr1 < myarr2);
                            Console.Write("\n(myarr1: " + myarr1.SumElem()); Console.Write(", myarr2: " + myarr2.SumElem() + ")");
                            break;
                        case 7:
                            Console.Write("\nСумма элементов: " + myarr1.SumElem()); 
                            break;
                        case 8:
                            Console.Write("\nРазница между min и max: " + myarr1.MaxMin()); 
                            break;
                        case 9:
                            Console.WriteLine("Owner: ");
                            Arr.Owner Oowner = new Arr.Owner();
                            Console.WriteLine(Arr.Owner.id);
                            Console.WriteLine(Arr.Owner.name);
                            Console.WriteLine(Arr.Owner.org);
                            break;
                        case 10:
                            Console.WriteLine("Date: ");
                            Arr.Date Ddate = new Arr.Date();
                            Console.WriteLine(Ddate.datenow);
                            break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
