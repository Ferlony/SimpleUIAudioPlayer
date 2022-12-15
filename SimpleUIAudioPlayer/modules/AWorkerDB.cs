using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dotnet
{
    public static class AWorkerDB
    {
        
        static string dirPath = @$".{Path.DirectorySeparatorChar}playListDB";
        static string signJSON = ".json";

        public static void AddFileToPlaylist(string path, string playlistName)
        {
            FileInfo playlist = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            
            CreatePlaylist(playlistName, playlist);
            //WorkerFiles.WriteFile(playlist, path);
            WorkerFiles.WriteFileJSON(playlist, path);
            Console.WriteLine(WorkerFiles.ReadFile(playlist));
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

            if (alldirs.Length > 0)
            {
                foreach (string dir in alldirs)
                {
                    newDirPath = dirPath + dir + Path.DirectorySeparatorChar;
                    AddOneDirToPlaylist(newDirPath, playlistName);
                }
            }
            else
            {
                AddOneDirToPlaylist(dirPath, playlistName);
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

        
        public static void DeleteFileFromPlaylist(string playlistName, string stringToDelete)
        {
            FileInfo file = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            int lineIndex = WorkerFiles.FindStringLineInFile(file, stringToDelete);
            if ((lineIndex > 2) && (lineIndex % 2 > 0))
            {
                //WorkerFiles.DeleteLineInFile(file, lineIndex - 1);
                WorkerFiles.DeleteLineInFile(file, lineIndex - 1);
                WorkerFiles.DeleteLineInFile(file, lineIndex - 2);
                Console.WriteLine($"Текст {stringToDelete} \nуспешно удален в \nплейлисте {playlistName}");
            }
            else
            {
                Console.WriteLine(
                    $"Текст {stringToDelete} \nне найден в \nплейлисте {playlistName}/n"+
                     "Или не может быть удален");
            }
        }

        public static void FindStringInFile(string playlistName, string stringToFind)
        {
            FileInfo file = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            int lineIndex = WorkerFiles.FindStringLineInFile(file, stringToFind);
            if (lineIndex > 0)
            {
                Console.WriteLine($"Текст {stringToFind} \nнайден в \n{lineIndex.ToString()} строке \nплейлиста {playlistName}");
            }
            else
            {
                Console.WriteLine($"Текст {stringToFind} \nне найден в \nплейлисте {playlistName}");
            }
        }

        public static void ShowPlaylistFiles(string playlistName)
        {
            FileInfo file = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            string filesInPlaylist = WorkerFiles.ReadFile(file, false);
            Console.WriteLine(filesInPlaylist);
        }

        // public static void FindStringInAllFiles(string playlistName, string stringToFind)
        // {

        // }
    }
}
