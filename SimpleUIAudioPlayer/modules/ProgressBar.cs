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
        //private int progress = 0;
        private static int maxLength = 0;
        private static int barWidth = 20;

        //private string back = "\b\b\b\b\b\b\b\b\b\b\b"; 
        private string back = "\n";
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

        // public int Progress
        // {
        //     get
        //     {
        //         return progress;
        //     }
        //     set
        //     {
        //         progress = value;
        //     }
        // }

        public void DrawProgressBar(int currentLength, bool update=false)
        {
            if(update)
            {
                Console.Write(back);
                //ClearCurrentConsoleLine();
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
            //progress++;
            string[] arr = TurnToMenute(currentLength);
            Console.Write($"] {arr[0]} / {arr[1]}");
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition(0, Console.CursorLeft);
            Console.Write(new string(' ', Console.WindowWidth)); 
        }
        
        
        public static string[] TurnToMenute(int currentLength)
        {
            string[] arr = new string[2];
            arr[0] = MakeBeauty(currentLength);
            arr[1] = MakeBeauty(maxLength);
            return arr;
        }

        private static string MakeBeauty(int arg)
        {
            return (arg / 60000).ToString() + "." + ((arg % 60000) / 1000 ).ToString();
        }

    }
}
