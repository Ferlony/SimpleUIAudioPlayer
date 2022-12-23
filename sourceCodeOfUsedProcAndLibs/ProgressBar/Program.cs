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
        public static Mutex mtx;
        static Program()
        {
            mtx = Mutex.OpenExisting("GlobalMutex");
        }
        internal static string ReadFile(FileInfo file, bool textflag)
        {
            string path = file.FullName;
            StreamReader reader = new StreamReader(path, Encoding.UTF8);
            string text = reader.ReadLine();
            if (textflag)
            {
                Console.WriteLine($"\nФайл {file.Name}");
            }
            reader.Close();
            return text;
        }
        public static void Main(string[] args)
        {
            string filePath = $@".{Path.DirectorySeparatorChar}modules{Path.DirectorySeparatorChar}ProgressBar{Path.DirectorySeparatorChar}progbar.txt";
            FileInfo file = new FileInfo(filePath);
            while(true)
            {
                mtx.WaitOne();
                Console.Clear();
                Console.WriteLine(ReadFile(file, false));
                mtx.ReleaseMutex();
                Thread.Sleep(1000);
            }
        }

    }
}
