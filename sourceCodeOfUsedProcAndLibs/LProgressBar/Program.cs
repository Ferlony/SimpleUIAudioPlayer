using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dotnet
{
    class Program
    {

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
        public static void Main(string[] args)
        {
            string filePath = $@".{Path.DirectorySeparatorChar}modules{Path.DirectorySeparatorChar}ProgressBar{Path.DirectorySeparatorChar}progbar.txt";
            FileInfo file = new FileInfo(filePath);

            
            while(true)
            {
                Console.Clear();
                Console.Write(ReadFile(file, false));
                Thread.Sleep(500);
            }

        }

    }
}
