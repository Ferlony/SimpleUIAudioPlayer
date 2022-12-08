using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dotnet
{
    public static class WorkerDB
    {
        
        static string dirPath = @$".{Path.DirectorySeparatorChar}playListDB";

        public static void AddFileToPlaylist(string path, string playlistName)
        {
            FileInfo playlist = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName);
            
            Modules.CreateDir(dirPath);
            Modules.CreateFile(playlist);
            Modules.WriteFile(playlist, path);
            Modules.ReadFile(playlist);
        }
        
        public static async void CreatePlaylist(string playlistName)
        {
            FileInfo playlist = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName);
            Modules.CreateDir(dirPath);
            Modules.CreateFile(playlist);
        }

        public static void DeletePlayList(string playlistName)
        {
            FileInfo playlist = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName);
            Modules.DeleteFile(playlist);
        }

        public static void ShowPlayListDB()
        {
            string[] allfiles = Directory.GetFiles(dirPath).Select(x => System.IO.Path.GetFileNameWithoutExtension(x)).ToArray();
            foreach (string filename in allfiles)
            {
                Console.WriteLine(filename);
            }
        }
       
    }
}
