using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dotnet
{
    public class ProgressBar
    {
        private int progress = 0;
        private int maxLength = 0;
        private static int barWidth = 10;

        //private string back = "\b\b\b\b\b\b\b\b\b\b\b"; 
        private string block = "#";
        private string blockempt = "=";
        private int currentPosition = 0;

        public int CurrentPosition
        {
            get
            {
                return currentPosition;
            }
            set
            {
                currentPosition = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return maxLength;
            }
            set
            {
                maxLength = value;
            }
        }

        public int Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
            }
        }

        public void DrawProgressBar(int currentLength, bool update=false)
        {
            if(update)
            {
                //Console.Write(back);
                ClearCurrentConsoleLine();
            }
            Console.Write("[");
            
            currentPosition = ((currentLength * barWidth) / maxLength);

            for (int i = 0; i < barWidth; i++)
            {
                if (i > currentPosition)
                {
                    Console.Write(blockempt);
                }
                else
                {
                    Console.Write(block);
                }
            }
            progress++;
            Console.Write($"] {progress} / {maxLength}");
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition(0, Console.CursorLeft);
            Console.Write(new string(' ', Console.WindowWidth)); 
        }
        

    }
}
