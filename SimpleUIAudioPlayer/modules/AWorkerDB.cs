using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
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
                WorkerFiles.DeleteLineInFile(file, lineIndex - 1);
                WorkerFiles.DeleteLineInFile(file, lineIndex - 2);
                Console.WriteLine($"Текст {stringToDelete} \nуспешно удален в плейлисте {playlistName}");
            }
            else
            {
                Console.WriteLine(
                    $"Текст {stringToDelete} \nне найден в плейлисте {playlistName}\n"+
                     "Или не может быть удален");
            }
        }

        public static void FindStringInFile(string playlistName, string stringToFind)
        {
            FileInfo file = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            int lineIndex = WorkerFiles.FindStringLineInFile(file, stringToFind);
            if (lineIndex > 0)
            {
                Console.WriteLine($"Текст {stringToFind} \nнайден в {lineIndex.ToString()} строке плейлиста {playlistName}");
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

        public static void FindStringInAllFiles(string stringToFind)
        {
            string[] allfiles = WorkerFiles.GetAllFilesInDirWithoutExtension(dirPath);
            	
            List<string> foundSongsInPlaylists = new List<string>();
            List<int> foundSongsInPlaylistsIndexLine = new List<int>();
            foreach (string playlistName in allfiles)
            {
                FileInfo file = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
                int lineIndex = WorkerFiles.FindStringLineInFile(file, stringToFind);
                if (lineIndex > 0)
                {
                    //Console.WriteLine($"Текст {stringToFind} \nнайден в \n{lineIndex.ToString()} строке \nплейлиста {playlistName}");
                    foundSongsInPlaylists.Add(playlistName);
                    foundSongsInPlaylistsIndexLine.Add(lineIndex);

                }
                // else
                // {
                //     //Console.WriteLine($"Текст {stringToFind} \nне найден в \nплейлисте {playlistName}");
                // }
            }

            if (foundSongsInPlaylists.Count > 0)
            {
                for (int i = 0; i < foundSongsInPlaylists.Count; i++)
                {
                    Console.WriteLine($"Текст {stringToFind} \nнайден в {foundSongsInPlaylistsIndexLine[i].ToString()} строке плейлиста {foundSongsInPlaylists[i]}\n");
                }
            }
            else
            {
                Console.WriteLine($"Текст {stringToFind} \nне найден\n");
            }

            Console.WriteLine($"Всего найдено: {foundSongsInPlaylists.Count}");

        }

        public static List<string> GetFilesFromDB(string playlistName)
        {
            FileInfo playlist = new FileInfo(dirPath + Path.DirectorySeparatorChar + playlistName + signJSON);
            List<string> allSongsInPlaylist = WorkerFiles.GetFilesInDB(playlist);

            return allSongsInPlaylist;

        }

        public static string GetStringFromBDLine(string file, string desiredString)
        {            
            string checktext = "";
            int counter = 0;
            bool flag = false;
            for (int i = 0; i < file.Length; i++)
            {
                if (!flag)
                {
                    if (file[i].ToString() == "\"")
                    {
                        counter++;
                    }
                    if (counter > 0)
                    {
                        if (counter % 2 > 0)
                        {
                            checktext += file[i];
                        }
                        else
                        {
                            if (checktext == "\"" + desiredString)
                            {
                                flag = true;
                                counter = 0;
                                checktext = "";
                            }
                            else
                            {
                                checktext = "";
                            }
                        }
                    }
                }
                else
                {
                    if (counter < 1)
                    {
                        i += 2;
                        counter++;
                    }
                    checktext += file[i];
                    if (file[i].ToString() == "\"")
                    {
                        return checktext.Replace("\"", "");
                    }
                }
            }
            return "";
        }



        
        public static List<string> GetListFilesFromDB(List<string> list, string desiredString)
        {
            List<string> newlist = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                newlist.Add(GetStringFromBDLine(list[i], desiredString));   
            }
            return newlist;
        }
    }
}
