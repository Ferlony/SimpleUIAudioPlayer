using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;


namespace Dotnet
{
    public partial class Modules
    {
        public static void Logo(string logoname)
        {
            string dirPath = @$".{Path.DirectorySeparatorChar}modules{Path.DirectorySeparatorChar}logos";

            FileInfo logofile = new FileInfo(dirPath + Path.DirectorySeparatorChar + logoname);
            Console.WriteLine(WorkerFiles.ReadFile(logofile, false));
        }

        public static string OsChecker()
        {
            if (OperatingSystem.IsWindows())
                return "windows";
            else if (OperatingSystem.IsLinux())
                return "linux";
            else if (OperatingSystem.IsAndroid())
                return "android";
            else
                return ("uknown system");
        }

        public async static void threader()
        {
            int N = 100000;
            ProgressBar bar = new ProgressBar();
            bar.MaxLength = N;
            string filePath = "./progbar.txt";
            FileInfo file = new FileInfo(filePath);
            try
            {
                WorkerFiles.DeleteFile(file);
            }
            catch
            {
                Console.Write("");
            }
            WorkerFiles.CreateFile(file);

            int counter = 0;
            for (int i = 10000;i <= N; i++)
            {
                WorkerFiles.WriteFile(file, bar.DrawProgressBar(i, true), false);
                counter++;
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - counter);
                counter = 0;
            }
        }

    }
}
