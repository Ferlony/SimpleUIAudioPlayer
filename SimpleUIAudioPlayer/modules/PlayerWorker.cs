using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;

namespace Dotnet
{
    partial class WorkerPlayer
    {
        private static ISoundEngine engine = new ISoundEngine();
        public static ISound music;
        private static double volume = 0.01;
        public static void Play(string song)
        {
            engine.SoundVolume = (float)volume;
            music = engine.Play2D(song, false);
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
            if(music.PlayPosition >= (uint)time * 1000)
            {
                music.PlayPosition = music.PlayPosition + (uint)time * 1000;
            }
            else
            {
                music.PlayPosition = 0;
            }
        }
        public static void Restart()
        {
            music.PlayPosition = 0;
        }
        public static void Next()
        {
            music.PlayPosition = music.PlayLength;
        }
    }

}
