using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;
using ProgressBarModulLib;
using System.Diagnostics;

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

        public static void Threader()
        {
            //string absPath = "C:\\Users\\panas\\Downloads\\SimpleUIAudioPlayer-main\\SimpleUIAudioPlayer-main\\SimpleUIAudioPlayer\\modules\\progbar.txt"
            string filePath = $@".{Path.DirectorySeparatorChar}modules{Path.DirectorySeparatorChar}ProgressBar{Path.DirectorySeparatorChar}progbar.txt";
            FileInfo file = new FileInfo(filePath);
            int counter = 0;
            int N = (int)WorkerPlayer.music.PlayLength;
            for (int i = (int)WorkerPlayer.music.PlayPosition; i<= N;)
            {
                WorkerFiles.WriteFile(file, ProgressBar.DrawProgressBar(i, N, true), false);
                counter++;
                //Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - counter);
                counter = 0;
            }
        }

        public static void KillProcess(int pid)
        {
            Process[] process = Process.GetProcesses();

            foreach (Process prs in process)
            {
                if (prs.Id == pid)
                {
                    prs.Kill();
                    return;
                }
            }
        }

        public static void DrawerExample()
        {
            string filePath = $@".{Path.DirectorySeparatorChar}modules{Path.DirectorySeparatorChar}ProgressBar{Path.DirectorySeparatorChar}progbar.txt";
            FileInfo file = new FileInfo(filePath);
            int N = 100000;
            //int counter = 0;

            for (int i = 50000; i <= N; i++)
            {
                WorkerFiles.WriteFile(file, ProgressBar.DrawProgressBar(i, N, true), false);
                // counter++;
                // Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - counter);
                // counter = 0;
            }
        }

    }
}
