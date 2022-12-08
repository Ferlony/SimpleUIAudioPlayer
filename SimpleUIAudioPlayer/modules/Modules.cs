using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dotnet
{
    internal partial class Modules
    {
        static internal void CreateFile(FileInfo file)
        {
            if (file.Exists)
            {
                Console.WriteLine($"Файл {file.Name} уже существует");
            }
            else
            {
                Console.WriteLine(file.FullName);
                file.Create();
                Console.WriteLine($"Файл {file.Name} создан");
            }
        }

        static internal void DeleteFile(FileInfo file)
        {
            if (file.Exists)
            {
                Console.WriteLine(file.FullName);
                file.Delete();
                Console.WriteLine($"Файл {file.Name} успешно удален");
            }
            else
            {
                Console.WriteLine($"Файл {file.Name} не существует");
            }
        }

        static internal void CreateDir(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine($"Папка {path} уже существует");
            }
            else
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"Папка {path} создана");
            }
        }

        static internal void WriteFile(FileInfo file, string text)
        {

            string path = file.FullName;
            StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine(text);
            writer.Close();
            Console.WriteLine($"Текст записан в {file}");
        }

        static internal void ReadFile(FileInfo file)
        {
            string path = file.FullName;
            StreamReader reader = new StreamReader(path, Encoding.UTF8);
            string text = reader.ReadToEnd();
            Console.WriteLine($"\nФайл {file.Name}");
            Console.WriteLine(text);
            reader.Close();
        }
    }
}
