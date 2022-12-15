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
        static string signJSON = ".json";

        public static void AddFileToPlaylist(string path, string playlistName)
        {
            FileInfo playlist = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            
            CreatePlaylist(playlistName, playlist);
            //WorkerFiles.WriteFile(playlist, path);
            WorkerFiles.WriteFileJSON(playlist, path);
            WorkerFiles.ReadFile(playlist);
        }

        internal static void AddOneDirToPlaylist(string dirPath, string playlistName)
        {
            string[] allfiles = WorkerFiles.GetAllFilesInDir(dirPath);
            foreach (string file in allfiles)
            {
                AddFileToPlaylist(dirPath + file, playlistName);
            }
        }

        public static void AddAllDirsToPlaylist(string dirPath, string playlistName)
        {
            string[] alldirs = WorkerFiles.GetAllDirsInDir(dirPath);
            string newDirPath;

            foreach (string dir in alldirs)
            {
                newDirPath = dirPath + dir + Path.DirectorySeparatorChar;
                AddOneDirToPlaylist(newDirPath, playlistName);
            }
        }
        
        public static void CreatePlaylist(string playlistName)
        {
            FileInfo playlist = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            string jsonReq = "{\"playlist\":[";
            WorkerFiles.CreateDir(dirPath);
            WorkerFiles.CreateFile(playlist);
            WorkerFiles.WriteFile(playlist, jsonReq);
            WorkerFiles.WriteFile(playlist, "]}");
        }
        internal static void CreatePlaylist(string playlistName, FileInfo playlist)
        {
            WorkerFiles.CreateDir(dirPath);
            WorkerFiles.CreateFile(playlist);
        }


        public static void DeletePlaylist(string playlistName)
        {
            FileInfo playlist = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            WorkerFiles.DeleteFile(playlist);
        }

        public static void ShowPlaylistDB(bool flagWithoutExtension=false)
        {
            string[] allfiles;
            if (flagWithoutExtension)
            {
                allfiles = WorkerFiles.GetAllFilesInDirWithoutExtension(dirPath);

            }
            else
            {
                allfiles = WorkerFiles.GetAllFilesInDir(dirPath);
            }
            foreach (string filename in allfiles)
            {
                Console.WriteLine(filename);
            }
        }

        public static void ShowAllDirsInDir(string dirPath)
        {
            string[] alldirs = WorkerFiles.GetAllDirsInDir(dirPath);
            foreach (string dir in alldirs)
            {
                Console.WriteLine(dir);
            }
        }
    }
}
