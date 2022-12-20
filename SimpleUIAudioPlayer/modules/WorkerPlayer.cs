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
        private static int currentPlaylistSongIndex = null;

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

        



    } 

}
