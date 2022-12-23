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
        public static Mutex mtx;
        static Modules()
        {
            mtx = Mutex.OpenExisting("GlobalMutex");
        }
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
            try
            {
                string filePath = $@".{Path.DirectorySeparatorChar}modules{Path.DirectorySeparatorChar}ProgressBar{Path.DirectorySeparatorChar}progbar.txt";
                FileInfo file = new FileInfo(filePath);
                int N = (int)WorkerPlayer.music.PlayLength;
                while (WorkerPlayer.music.Finished != true)
                {
                    mtx.WaitOne();
                    WorkerFiles.WriteFile(file, ProgressBar.DrawProgressBar((int)WorkerPlayer.music.PlayPosition, N, true), false);
                    mtx.ReleaseMutex();
                    if (WorkerPlayer.music.Finished)
                    {
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка, трек не выбран");
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
            for (int i = 1000; i <= N; i++)
            {
                mtx.WaitOne();
                WorkerFiles.WriteFile(file, ProgressBar.DrawProgressBar(i, N, true), false);
                mtx.ReleaseMutex();
            }
        }

    }
}
