using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;

namespace Dotnet
{
    partial class WorkerPlayer
    {
        private static ISoundEngine engine = new ISoundEngine();
        private static ISound music;
        private static double volume = 0.01;
        public async static int Play(string song)
        {
            engine.SoundVolume = (float)volume;
            music = engine.Play2D(song, false);
            Console.Write("Продолжительность трека: ");
            Console.Write(music.PlayLength / 60000);
            Console.Write(":");
            Console.WriteLine((music.PlayLength % 60000) / 1000);
            return 0;
        }
        public static void Stop()
        {
            engine.SetAllSoundsPaused(true);
        }
        public static void Continue()
        {
            engine.SetAllSoundsPaused(false);
        }
        public static void Volume(int value)
        {
            volume = value / 1000.0;
            engine.SoundVolume = (float)volume;
        }
        public static void Rewind(int time)
        {
            Console.WriteLine(time);
            Console.WriteLine(music.PlayPosition);
            if(time > 0 )
            {
                music.PlayPosition = music.PlayPosition + (uint)time * 1000;
            }
            else
            {
                music.PlayPosition = music.PlayPosition + (uint)time * 1000;
            }
            Console.WriteLine(music.PlayPosition);
        }
    }

}
