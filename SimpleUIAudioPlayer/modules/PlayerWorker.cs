using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;

namespace Dotnet
{
    partial class PlayerWorker
    {
        static public ISoundEngine engine = new ISoundEngine();
        public static ISound music;
        static public double volume = 0.01;
        static public void Play()
        {
            engine.SoundVolume = (float)volume;
            music = engine.Play2D(@"C:\Users\panas\Downloads\SimpleUIAudioPlayer-main\SimpleUIAudioPlayer-main\SimpleUIAudioPlayer\Test\Music\TestMus\all\Rick-Astley-Never-Gonna-Give-You-Up-_Official-Music-Video_.wav", false);
            Console.Write("Продолжительность трека: ");
            Console.Write(music.PlayLength / 60000);
            Console.Write(":");
            Console.WriteLine((music.PlayLength % 60000) / 1000);
        }
        static public void Stop()
        {
            engine.SetAllSoundsPaused(true);
        }
        static public void Continue()
        {
            engine.SetAllSoundsPaused(false);
        }
        static public void Volume(int value)
        {
            volume = value / 1000.0;
            engine.SoundVolume = (float)volume;
        }
        static public void Rewind(int time)
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
