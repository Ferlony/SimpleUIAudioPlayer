using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotnet
{
    partial class WorkerPlayer
    {
        private static List<string> currentPlaylist = new List<string>();
        private static List<string> currentPlaylistAllSongs = new List<string>();
        private static List<string> currentPlaylistSongsNames = new List<string>();
        private static string currentPlaylistName = null;
        private static int currentPlaylistSongIndex = 0;
        public static Semaphore sem = new Semaphore(1, 1);
        public static bool isReleased = false;

        public string CurrentPlaylistName
        {
            set
            {
                currentPlaylistName = value;
                currentPlaylist = AWorkerDB.GetFilesFromDB(currentPlaylistName);
                currentPlaylistAllSongs = AWorkerDB.GetListFilesFromDB(currentPlaylist, "filepath");
                currentPlaylistSongsNames = AWorkerDB.GetListFilesFromDB(currentPlaylist, "fileName");
                currentPlaylistSongIndex = 0;
            }
        }


        public void PlayAllSongsInPlaylist()
        {
            Play(currentPlaylistAllSongs[currentPlaylistSongIndex]);
            CurrentSongInfo();
            currentPlaylistSongIndex++;
            while (true)
            {
                if (currentPlaylistSongIndex == currentPlaylistAllSongs.Count)
                {
                    break;
                }
                else
                {
                    if(music.Finished)
                    {
                        Play(currentPlaylistAllSongs[currentPlaylistSongIndex]);
                        CurrentSongInfo();
                        currentPlaylistSongIndex++;
                    }
                }
            }
        }
        private static void CurrentSongInfo()
        {
            //sem.WaitOne();
            Console.Write("Название трека: ");
            Console.WriteLine(currentPlaylistSongsNames[currentPlaylistSongIndex]);
            Console.Write("Продолжительность трека: ");
            Console.Write(music.PlayLength / 60000);
            Console.Write(":");
            Console.WriteLine((music.PlayLength % 60000) / 1000);
            sem.Release();
            isReleased = true;
        }
        public static void CurrentSongProgressBar()
        {
            ProgressBar bar = new ProgressBar();
            bar.MaxLength = (int)WorkerPlayer.music.PlayLength;
            Console.WriteLine(bar.DrawProgressBar((int)WorkerPlayer.music.PlayPosition, true));
        }
    }
}