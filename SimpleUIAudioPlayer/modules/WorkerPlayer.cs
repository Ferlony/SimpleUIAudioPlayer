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
        private static string currentPlaylistSongsNames = null;
        private static string currentPlaylistName = null;
        private static int currentPlaylistSongIndex = 0;

        public string CurrentPlaylistName
        {
            set
            {
                currentPlaylistName = value;
                currentPlaylist = AWorkerDB.GetFilesFromDB(currentPlaylistName);
                currentPlaylistAllSongs = AWorkerDB.GetListFilesFromDB(currentPlaylist, "filepath");
                currentPlaylistSongIndex = 0;
            }
        }


        public void PlayAllSongsInPlaylist()
        {
            Play(currentPlaylistAllSongs[currentPlaylistSongIndex]);
            CurrentSongLength();
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
                        CurrentSongLength();
                        currentPlaylistSongIndex++;
                    }
                }
            }
        }
        private static void CurrentSongLength()
        {
            lock(Menus.obj)
            {
                Console.Write("Продолжительность трека: ");
                Console.Write(music.PlayLength / 60000);
                Console.Write(":");
                Console.WriteLine((music.PlayLength % 60000) / 1000);
            }
        }
        public static void CurrentSongProgressBar()
        {
            ProgressBar bar = new ProgressBar();
            bar.MaxLength = (int)WorkerPlayer.music.PlayLength;
            Console.WriteLine(bar.DrawProgressBar((int)WorkerPlayer.music.PlayPosition, true));
        }
    }
}