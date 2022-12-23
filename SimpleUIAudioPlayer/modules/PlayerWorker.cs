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
        private static double volume = 0.03;
        public static void Play(string song, bool loopSongFlag=false)
        {
            engine.SoundVolume = (float)volume;
            music = engine.Play2D(song, loopSongFlag);
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
            if(music.PlayPosition >= time * 1000)
            {
                music.PlayPosition = music.PlayPosition + (uint)time * 1000;
            }
            else
            {
                if((time < 0) && (music.PlayPosition <= time * 1000))
                {
                    music.PlayPosition = 0;
                }
                else
                {
                    music.PlayPosition = music.PlayPosition + (uint)time * 1000;
                }
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
