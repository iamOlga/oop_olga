using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//делегаты - это указатели на методыделегаты - это указатели на методы
//События сигнализируют системе о том, что произошло определенное действие.

namespace _9lab
{
    public delegate void Transfer(Object obj);//делегат перемещение
    public delegate void Squeeze(Object obj);//сжатие
    public class User
    {
        public event Transfer transferr;//событие 
        public event Squeeze squeezee;
        public void Transfer(Object obj) => transferr?.Invoke(obj);//лямбда-выражение
        public void Squeeze(Object obj) => squeezee?.Invoke(obj);
    }
    public class Object
    {
        public int Width;
        public int Coordinate_X;
        public int Coordinate_Y;

        public Transfer transfer;
        public Squeeze squeeze;
        public override string ToString()
        {
            return $"Width: {Width}, Coordinate: ({Coordinate_X},{Coordinate_Y})";
        }
    }
//2
    class Str_metods
    {
        public static string RemoveMarks(string str)//удаление знаков препинания
        {
            char[] marks = { '.', ',', '-', '!', '?'};
            for (int i = 0; i < str.Length; i++)
            {
                if (marks.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }
            Console.WriteLine("\nСтрока после удаления знаков препинания:");
            return str;
        }
        public static string RemoveLast(string str)//удаление посл символа
        {
            int ind = str.Length - 1;
            str = str.Remove(ind);
            Console.WriteLine("\nСтрока после удаления последнего символа:");
            return str;
        }
        public static string ToUpper(string str)//все большие
        {
            Console.WriteLine("\nСтрока после преобразования в прописные буквы:");
            return str.ToUpper();
        }
        public static string ToLower(string str)//все маленькие
        {
            Console.WriteLine("\nСтрока после преобразования в строчные буквы:");
            return str.ToLower();
        }
        public static string Replaсe_sumb(string str)//удаление пробела
        {
            Console.WriteLine("\nСтрока после удаления пробелов:");
            return str.Replace(" ", "");
        }
    }



    class Program
    {
        public delegate int Delete_Last();
        static void Main(string[] args)
        {
            Console.WriteLine("------------1------------");
            User user1 = new User();

            Object obj1 = new Object()
            {
                Width = 55,
                Coordinate_X = 34,
                Coordinate_Y = 15,
                squeeze = (obj) =>
                {
                    Console.Write("Сжатие на: ");
                    var num_w1 = int.Parse(Console.ReadLine());
                    obj.Width -= num_w1;
                    Console.WriteLine($"Сжатие на {num_w1} единиц, ширина: {obj.Width}");
                },
                transfer = (obj) =>
                {
                    Console.Write("Перемещение по оси х на: ");
                    var num_x1 = int.Parse(Console.ReadLine());
                    Console.Write("Перемещение по оси y на: ");
                    var num_y1 = int.Parse(Console.ReadLine());
                    obj.Coordinate_X += num_x1;
                    obj.Coordinate_Y += num_y1;
                    Console.WriteLine($"Перемещение на {num_x1} по оси х и на {num_y1} по оси y, ({obj.Coordinate_X},{obj.Coordinate_Y})");
                }
            };
            Object obj2 = new Object()
            {
                Width = 34,
                Coordinate_X = 45,
                Coordinate_Y = 17,
                squeeze = (objj) =>
                {
                    Console.Write("Сжатие на: ");
                    var num_w2 = int.Parse(Console.ReadLine());
                    objj.Width -= num_w2;
                    Console.WriteLine($"Сжатие на {num_w2} единиц, ширина: {objj.Width}");
                },
                transfer = (objj) =>
                {
                    Console.Write("Перемещение по оси х на: ");
                    var num_x2 = int.Parse(Console.ReadLine());
                    Console.Write("Перемещение по оси y на: ");
                    var num_y2 = int.Parse(Console.ReadLine());
                    objj.Coordinate_X += num_x2;
                    objj.Coordinate_Y += num_y2;
                    Console.WriteLine($"Перемещение на {num_x2} по оси х и на {num_y2} по оси y, ({objj.Coordinate_X},{objj.Coordinate_Y})");
                }
            };
            Console.WriteLine($"Object 1: {obj1.Width}, ({obj1.Coordinate_X},{obj1.Coordinate_Y})");
            Console.WriteLine($"Object 2: {obj2.Width}, ({obj2.Coordinate_X},{obj2.Coordinate_Y})");
            user1.transferr += obj2.transfer; 
            user1.Transfer(obj1);
            user1.squeezee += obj1.squeeze;
            user1.squeezee += obj2.squeeze;
            user1.Squeeze(obj2);
            Console.WriteLine();


            Console.WriteLine("------------2------------");
            string str = Console.ReadLine();
            //Func возвращает результат действия и может принимать параметры
            Func<string, string> strrr = Str_metods.RemoveMarks;
            Console.WriteLine(str=strrr(str));
            strrr = Str_metods.RemoveLast;
            Console.WriteLine(str = strrr(str));
            strrr = Str_metods.Replaсe_sumb;
            Console.WriteLine(str = strrr(str));
            strrr = Str_metods.ToUpper;
            Console.WriteLine(str = strrr(str));
            strrr = Str_metods.ToLower;
            Console.WriteLine(str = strrr(str));
            Console.ReadKey();
        }
    }
}
