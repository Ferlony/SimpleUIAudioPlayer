using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dotnet
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Menus menu = new Menus();
            //Menus.MainMenu();
            
            Modules.Logo("cat.txt");
            Modules.Logo("SUIAP.txt");
            menu.MainMenu();
        }
    }
}
