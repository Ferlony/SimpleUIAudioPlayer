using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace Dotnet
{
    internal partial class WorkerFiles
    {
        internal static void CreateFile(FileInfo file)
        {
            if (file.Exists)
            {
                Console.WriteLine($"Файл {file.Name} уже существует");
            }
            else
            {
                Console.WriteLine(file.FullName);
                file.Create().Dispose();
                Console.WriteLine($"Файл {file.Name} создан");
            }
        }

        internal static void DeleteFile(FileInfo file)
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

        internal static void CreateDir(string path)
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

        internal static void WriteFile(FileInfo file, string text, bool writeToEndFlag=true)
        {

            string path = file.FullName;
            StreamWriter writer = new StreamWriter(path, writeToEndFlag, Encoding.UTF8);
            writer.WriteLine(text);
            writer.Close();
            Console.WriteLine($"Текст записан в {file}");
        }

        internal static void WriteFileJSON(FileInfo file, string text)
        {
            string path = file.FullName;

            string[] lines = File.ReadAllLines(path.Replace(",", ""));
            string newtext = "";
            if (lines.Length != 2)
            {
                for (int i = 1; i < lines.Length - 1; i++)
                {
                    if (i == lines.Length - 2)
                    {
                        newtext += lines[i] + "," + "\n";
                    }
                    else
                    {
                        newtext += lines[i] + "\n";
                    }
                }
            }

            StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);

            string album = GetFileDir(text);
            string fileName = GetFileName(text);

            string jsonReq = ("{" + 
            "\"fileName\":" + "\"" + fileName + "\"" + ", " + 
            "\"album\":" + "\"" + album + "\"" + ", " +
            "\"filepath\":" + "\"" + text + "\"" +
            "}");

            writer.WriteLine("{\"playlist\":[");
            
            writer.WriteLine(newtext);
            writer.WriteLine(jsonReq);
            writer.WriteLine("]}");
            
            writer.Close();
            Console.WriteLine($"Текст записан в {file}");
        }

        internal static string ReadFile(FileInfo file, bool textflag=true)
        {
            string path = file.FullName;
            StreamReader reader = new StreamReader(path, Encoding.UTF8);
            string text = reader.ReadToEnd();
            if (textflag)
            {
                Console.WriteLine($"\nФайл {file.Name}");
            }
            //Console.WriteLine(text);
            reader.Close();
            return text;
        }

        internal static string[] GetAllFilesInDir(string dirPath)
        {
            string[] allfiles = Directory.GetFiles(dirPath).Select(x => System.IO.Path.GetFileName(x)).ToArray();
            return allfiles;
        }

        internal static string[] GetAllFilesInDirWithoutExtension(string dirPath)
        {
            string[] allfiles = Directory.GetFiles(dirPath).Select(x => System.IO.Path.GetFileNameWithoutExtension(x)).ToArray();
            return allfiles;
        }
        
        internal static string[] GetAllDirsInDir(string dirPath)
        {
            string[] alldirs = Directory.GetDirectories(dirPath).Select(x => System.IO.Path.GetFileNameWithoutExtension(x)).ToArray();
            return alldirs;
        }

        internal static string GetFileDir(string filePath)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(filePath));
            string dirName = dir.Name;
            return dirName;
        }

        internal static string GetFileName(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            return fileName;
        }

        internal static int FindStringLineInFile(FileInfo file, string stringToFind)
        {
            
            string path = file.FullName;
            int lineCounter = 0;
            string line;
            bool flag = false;
            string lineChecker = "\"fileName\"" + ":" + "\"" + stringToFind + "\"";
            
            StreamReader reader = new StreamReader(path, Encoding.UTF8);
            while ((line = reader.ReadLine()) != null)
            {
                lineCounter++;
                if (line.Contains(lineChecker))
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                return lineCounter;
            }
            else
            {
                return -1;
            }
        }

        internal static List<string> GetFilesInDB(FileInfo file)
        {
            string path = file.FullName;
            string[] lines = File.ReadAllLines(path);
            List<string> newtext = new List<string>();
            
            if (lines.Length != 2)
            {
                for (int i = 1; i < lines.Length - 1; i++)
                {
                    if ((i % 2 == 0))
                    {
                        newtext.Add(lines[i]);
                    }
                }
            }
            return newtext;
        }

        internal static void DeleteLineInFile(FileInfo file, int lineIndex)
        {
            string path = file.FullName;
            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(lineIndex);
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

    }
}
