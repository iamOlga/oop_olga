using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _13lab
{
    class BOALog//1
    {
        public static StreamWriter CreateStreamWriter(string str)//Создает экземпляр класса записи в файл
        {
            StreamWriter streamWriter = new StreamWriter(str);
            return streamWriter;
        }
        public static StreamReader CreateStreamReader(string str)//Создает экземпляр класса чтение из файла
        {
            StreamReader streamReader = new StreamReader(str);
            return streamReader;
        }
        public static void BOAWriter(StreamWriter streamWriter, string info)//Запись в файл время создания записи и запись 
        {
            streamWriter.WriteLine(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ", " + DateTime.Now.Day 
                + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "\n");
            streamWriter.WriteLine(info);
        }
        public static void CloseStream(StreamWriter streamWriter)//Закрываем файл
        {
            streamWriter.Close();
        }
        public static string BOAReader(StreamReader streamReader)
        {
            return streamReader.ReadToEnd();
        }
        public static void BOASearcher(StreamReader streamReader, string info)//Поиск в файле 
        {
            string text = BOAReader(streamReader);
            if (text.Contains(info))
            {
                Console.WriteLine("Файл содержит данную информацию");
            }
            else
            {
                Console.WriteLine("Файл не содержит данную информацию");
            }
        }
    }
    class BOADiskInfo//2
    {
        private static DriveInfo[] Drives = DriveInfo.GetDrives();//Возвращает имена всех логических дисков на компьютере

        public static void FreeSpace(StreamWriter streamWriter)//инф о свободном месте на диске
        {
            BOALog.BOAWriter(streamWriter, "Свободное место на диске: ");
            for (int i = 0; i < Drives.Length; i++)
            {
                if (Drives[i].IsReady)//готов ли диск к работе
                {
                    Console.WriteLine(Drives[i].Name + " свободное место: " + Drives[i].AvailableFreeSpace);
                }
            }
        }
        public static void FileSystemInfo(StreamWriter streamWriter)//инф о файловой системе
        {
            BOALog.BOAWriter(streamWriter, "Информация о файловой системе: ");
            Console.WriteLine("Файловая система: " + Drives[0].DriveFormat);
        }
        public static void InfoDisk(StreamWriter streamWriter)//для диска - имя, объем, доступный объем, метка тома
        {
            BOALog.BOAWriter(streamWriter, "Информация о каждом диске: ");
            for (int i = 0; i < Drives.Length; i++)
            {
                if (Drives[i].IsReady)
                {
                    Console.WriteLine(Drives[i].Name + ", объем: " + Drives[i].TotalSize +
                        ", доступный объем: " + Drives[i].AvailableFreeSpace + "метка тома: " + Drives[i].VolumeLabel);
                }
            }
        }
    }
    static class BOAFileInfo//3
    {
        public static void FullDirection(StreamWriter streamWriter, string f)// полный путь до файла
        {
            BOALog.BOAWriter(streamWriter, "Полный путь");
            FileInfo ff = new FileInfo(f);
            if (ff.Exists)//существует ли
            {
                Console.WriteLine("Полный путь: " + ff.DirectoryName + ff.Name);
            }
        }
        public static void FileInfo(StreamWriter streamWriter, string f)//Размер, расширение, имя
        {
            BOALog.BOAWriter(streamWriter, "Размер, расширение, имя: ");
            FileInfo ff = new FileInfo(f);
            if (ff.Exists)//проверка на существование
            {
                Console.WriteLine("Размер: " + ff.Length + ", расширение: " + ff.Extension + ", имя: " + ff.Name);
            }
        }
        public static void CreationTime(StreamWriter streamWriter, string f)//Время создания файла
        {
            BOALog.BOAWriter(streamWriter, "Время создания файла: ");
            FileInfo ff = new FileInfo(f);
            if (ff.Exists)
            {
                Console.WriteLine("Время создания файла: " + ff.CreationTime);
            }
        }
    }
    class BOADirInfo//4
    {
        public static void FileCount(StreamWriter streamWriter, string s)//Количестве файлов
        {
            BOALog.BOAWriter(streamWriter, "Количестве файлов: ");
            DirectoryInfo dirinfo= new DirectoryInfo(s);
            if (dirinfo.Exists)
            {
                FileInfo[] ff = dirinfo.GetFiles();
                Console.WriteLine("Количестве файлов: " + ff.Length);
            }
        }
        public static void CreationTime(StreamWriter streamWriter, string s)//Время создания
        {
            BOALog.BOAWriter(streamWriter, "Время создания: ");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists)
                Console.WriteLine("Время создания: " + dirinfo.CreationTime);
            else Console.WriteLine("Не существует!");
        }        
        public static void DirCount(StreamWriter streamWriter, string s)//Количестве поддиректориев
        {
            BOALog.BOAWriter(streamWriter, "Количестве поддиректориев: ");
            DirectoryInfo dirinfo= new DirectoryInfo(s);
            if (dirinfo.Exists && dirinfo.Extension == "")
            {
                DirectoryInfo[] d = dirinfo.GetDirectories();
                Console.WriteLine("Количестве поддиректориев: " + d.Length);
            }
        }
        public static void ParentsCount(StreamWriter streamWriter, string s)//Список родительских директориев
        {
            BOALog.BOAWriter(streamWriter, "Список родительских директориев: ");
            DirectoryInfo dirinfo= new DirectoryInfo(s);
            if (dirinfo.Exists)
            {
                Console.WriteLine("Список родительских директориев: " + dirinfo.Root);
            }
        }
    }
    class BOAFileManager//5
    {
        public static void DiskReader(StreamWriter streamWriter, string str)
        {
            BOALog.BOAWriter(streamWriter, "Начинаем создавать директорий BOAInspect");
            Directory.CreateDirectory("BOAInspect");//создаем  директорию
            FileStream fstream = File.Create("BOAInspect\\BOAdirinfo.txt");//создаем файл
            fstream.Close();
            BOALog.BOAWriter(streamWriter, "Cоздание BOAdirinfo.txt");//пишем в файл
            StreamWriter swriter = new StreamWriter("BOAInspect\\BOAdirinfo.txt");//в файл BOAdirinfo.txt открываем поток
            DirectoryInfo diInfor = new DirectoryInfo(str);//получаем информацию о директории

            if (diInfor.Exists)
            {
                DirectoryInfo[] d = diInfor.GetDirectories();//получаем директории и файлы
                FileInfo[] f = diInfor.GetFiles();

                for (int i = 0; i < d.Length; i++)//выводим все директоии и файлы
                {
                    Console.WriteLine(d[i].Name);
                    swriter.WriteLine(d[i].Name);
                }
                for (int i = 0; i < f.Length; i++)
                {
                    Console.WriteLine(f[i].Name);
                    swriter.WriteLine(f[i].Name);
                }
                swriter.Close();

                BOALog.BOAWriter(streamWriter, "Копирование из BOAdirinfo в BOAdirinfo2");//пишем в файл 
                if (File.Exists("BOAInspect\\BOAdirinfo2.txt"))//перемещаем файл создавая его копию, после удаляем 
                {
                    File.Delete("BOAInspect\\BOAdirinfo.txt");
                }
                FileInfo q = new FileInfo("BOAInspect\\BOAdirinfo.txt");
                q.CopyTo("BOAInspect\\BOAdirinfo2.txt");
                File.Delete("BOAInspect\\BOAdirinfo.txt");

                Directory.CreateDirectory("BOAFiles");
                BOALog.BOAWriter(streamWriter, "Cоздание BOAFiles");
                BOALog.BOAWriter(streamWriter, "Запись в BOAFile");
                for (int i = 0; i < f.Length; i++)
                {
                    if (f[i].Extension == ".txt")
                    {
                        if (File.Exists("BOAFiles\\" + f[i].Name))
                        {
                            File.Delete("BOAFiles\\" + f[i].Name);
                        }
                        f[i].CopyTo("BOAFiles\\" + f[i].Name);
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter file = BOALog.CreateStreamWriter("File.txt");

            BOADiskInfo.FreeSpace(file);
            BOADiskInfo.FileSystemInfo(file);
            BOADiskInfo.InfoDisk(file); Console.WriteLine();

            BOAFileInfo.FullDirection(file, "File.txt");
            BOAFileInfo.FileInfo(file, "File.txt");
            BOAFileInfo.CreationTime(file, "File.txt"); Console.WriteLine();

            BOADirInfo.CreationTime(file, "..");
            BOADirInfo.FileCount(file, "..");
            BOADirInfo.DirCount(file, "..");
            BOADirInfo.ParentsCount(file, ".."); Console.WriteLine();

            try
            {
                BOAFileManager.DiskReader(file, "D://");
            }
            catch (IOException) { };
            
            file.Close();

            Console.ReadKey();
        }
    }
}
