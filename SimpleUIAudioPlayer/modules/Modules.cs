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

        public static void threader()
        {
            FileInfo file = ProgressBar.ProgressBarCreateFile();
            int counter = 0;
            int N = (int)WorkerPlayer.music.PlayLength;
            for (int i = (int)WorkerPlayer.music.PlayPosition; i<= N;)
            {
                WorkerFiles.WriteFile(file, ProgressBar.DrawProgressBar(i, N, true), false);
                counter++;
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - counter);
                counter = 0;
            }
        }
        

    }
}
