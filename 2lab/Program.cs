using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    class Program
    {

        static void Main(string[] args)
        {
            //1
            Console.Write("---------------------1---------------------\n");
            bool XBOOL = true;
            byte XBYTE = 25;
            int XINT = 115;
            long XLONG = -434472;
            double XDOUBLE = 3.14;
            string XSTRING = "somth";
            Console.WriteLine("Типы c#: ");
            Console.WriteLine("bool: " + XBOOL + ", byte: " + XBYTE + ", int: " + XINT + ",\nlong: " + XLONG
                 + ", double: " + XDOUBLE + ", string: " + XSTRING);

            //явное преобразование
            byte x = (byte)XINT;
            int q = (int)XBYTE;
            long w = (long)XINT;
            Console.WriteLine("Явное преобразование: ");
            Console.WriteLine("int в byte: " + x + ", byte в int: " + q + ", int в long: " + w);
            //неявное
            int a = x;
            long s = q;
            long d = x;
            Console.WriteLine("Неявное преобразование: ");
            Console.WriteLine("byte в int: " + a + ", int в longe: " + s + ", byte в long: " + d);

            //упаковка-распаковка
            object O = XINT;
            int j = (int)O;
            Console.WriteLine("Упаковка: " + O);
            Console.WriteLine("Распаковка: " + j);

            //неявно типизированная перем.
            var VAR = 34;
            Console.WriteLine("Неявно типизированная переменная var: " + VAR);

            //nullable
            int? N = null;
            Console.Write("Значение Nullable переменной: ");
            if (N.HasValue)
                Console.WriteLine(N.Value);
            else
                Console.Write("N равно нулю");

            //2
            Console.Write("\n\n---------------------2---------------------\n");
            string first = "hello, world", second = " and c#,", third = " i'm Olga";
            Console.Write("Сравнение: ");
            if (first == second) Console.Write("true" + "\n");
            else Console.Write("false" + "\n");

            Console.Write("Объединение: ");
            string concat = first + second + third; Console.Write(concat + "\n");
            Console.Write("Копирование: ");
            string strcopy = String.Copy(second); Console.Write(strcopy + "\n");
            Console.Write("Выделение подстроки: ");
            var substring = first.Substring(0, 6); Console.Write(substring + "\n");
            Console.Write("Разделение строки на слова: ");
            string[] words = third.Split(new char[] { ' ' });
            int len = words.Length;
            for (int i=1; i < len; i++)
            {
                Console.Write(i + ") ");
                Console.Write(words[i] + ", ");
            }
            Console.Write("\nВставки подстроки в заданную позицию: ");
            string instr = third.Insert(0, substring); Console.Write(instr + "\n");
            Console.Write("Удаление заданной подстроки: ");
            third = third.Remove(0, 4);//вырезание
            Console.Write(third + "\n\n");

            Console.Write("Сравнение пустой строки и строки null: ");
            string EMPTY = "";
            string STRNULL = null;
            if (EMPTY.Equals(STRNULL))
            {
                Console.Write("строки эквивалентны");
            }
            else
                Console.Write("строки EMPTY и STRNULL не эквивалентны");

            StringBuilder NEWSTRBUI = new StringBuilder("aa made by StringBuilder", 25);
            Console.Write("\n\nСтрока с исп-ем StringBuilder до преобр-ий: " + NEWSTRBUI);
            NEWSTRBUI = NEWSTRBUI.Remove(0, 2);//Удалите определенные позиции
            NEWSTRBUI.Insert(0, "String ");//добавление в начало 
            NEWSTRBUI.Append("!!!");//добавление в конец
            Console.Write("\nСтрока после преобр-ий: " + NEWSTRBUI);

            //3.1
            Console.Write("\n\n\n---------------------3---------------------\n");
            Console.WriteLine("Двумерный массив: ");
            int[,] arr2 = new int[3, 3]
            {
                { 34, 15, 10 },
                { 22, 9, 14 },
                { 32, 6, 61 }
            };

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write(arr2[i, k] + "\t");
                }
                Console.WriteLine();
            }

            //3.2
            string[] days = new string[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" };
            Console.WriteLine("\nОдномерный массив: ");
            for (int k = 0; k < days.Length; k++)
            {
                Console.Write(days[k] + "\t");
            }
            Console.WriteLine("\n\nДлина одномерного массива: " + days.Length);
            Console.Write("\nВведите эл-т, который хотите заменить: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("\nВведите новый элемент: ");
            for (int k = 0; k < days.Length; k++)
            {
                if(k+1==num)
                {
                    days[k]= Console.ReadLine();
                }
            }
            Console.WriteLine("\nОдномерный массив после замены 1-го эл-та: ");
            for (int k = 0; k < days.Length; k++)
            {
                Console.Write(days[k] + "\t");
            }

            //3.3
            int[][] arrstepped = new int[3][];
            arrstepped[0] = new int[2];
            arrstepped[1] = new int[3];
            arrstepped[2] = new int[4];

            Console.Write("\n\nВведите ступенчатый массив" + "\n");
            for (int i = 0; i < arrstepped.Length; i++)
            {
                for (int z = 0; z < arrstepped[i].Length; z++)
                {
                    arrstepped[i][z] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }

            Console.WriteLine("Ступенчатый массив: ");
            for (int i = 0; i < arrstepped.Length; i++)
            {
                for (int z = 0; z < arrstepped[i].Length; z++)
                {
                    Console.Write(arrstepped[i][z] + "\t");
                }
                Console.WriteLine();
            }

            //3.4
            var strrrr = new[] { "some", "array" };
            Console.WriteLine("\n\nНеявно типизированная пер-ая для хранения строки: ");
            for (int k = 0; k < strrrr.Length; k++)
            {
                Console.Write(strrrr[k] + "\t");
            }
            var arrrr = new[]
            {
            new[]{1,2,3,4},
            new[]{5,6,7,8}
            };
            Console.WriteLine("\nНеявно типизированная пер-ая для хранения массива: ");
            for (int i = 0; i < arrrr.Length; i++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Console.Write(arrrr[i][z] + "\t");
                }
                Console.WriteLine();
            }

            //4
            Console.Write("\n\n---------------------4---------------------\n");
            (int, string, char, string, ulong) cortege1 = (34, "hello", 'g', " home", 544674);
            (int u1, string u2, char u3, string u4, ulong u5) = cortege1;//(34, "hello", 'g', " home", 544674);
            (int u21, string u22, char u23, string u24, ulong u25) cortege2 = (18, "it's", 'g', " my", 67384);
            (int u21, string u22, char u23, string u24, ulong u25) cortege3 = (18, "it's", 'g', " my", 67384);
            Console.WriteLine("Вывод кортежа: " + cortege1.ToString());
            Console.WriteLine("Вывод 2-го и 4-го эл-ов кортежа: " + u2 + u4);
            //распаковка кортежа
            int cortu1 = cortege1.Item1;
            string cortu2 = cortege1.Item2;
            char cortu3 = cortege1.Item3;
            string cortu4 = cortege1.Item4;
            ulong cortu5 = cortege1.Item5;
            Console.WriteLine("Вывод эл-ов кортежа после распаковки: " + cortu1 + "\t" + cortu2 + "\t" + cortu3 + "\t" + cortu4 + "\t" + cortu5);
            //сравнить 2 кортежа
            var comp = cortege1.CompareTo(cortege2);
            Console.WriteLine("Сравнение разных кортежей с пом. CompareTo: " + comp);
            var comp2 = cortege3.CompareTo(cortege2);
            Console.WriteLine("Сравнение одинаковых кортежей с пом. CompareTo: " + comp2);

            //5
            Console.Write("\n\n---------------------5---------------------\n");
            var tuple = GetValues();
            Console.WriteLine(tuple); 
 
            Console.ReadKey();
        }
        private static (int, int, int, char) GetValues()
        {
            int[] arrr5 = new int[4] { 1, 2, 3, 5 };
            string str5 = "string5";
            int max = arrr5.Max();
            int min = arrr5.Min();
            int arrsum = arrr5.Sum();
            char el = str5[0];
            var result = (max, min, arrsum, el);
            return result;
        }
    }
}
