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
        //
        // Нужно будет добавить аргументы для быстрого доступа
        // К примеру:
        // --help       -h      : Справка по аргументам 
        // --play       -p      : Проиграть плейлист
        // --stop       -s      : Приостановить проигрывание
        // --continue   -c      : Продолжить проигрывание
        // --loop       -l      : Зациклить проигрывание плейлиста
        // --loopsong   -ls     : Зациклить проигрывание песни
        // --kill       -k      : Убить демона проигрывания
        //
        // Пример запроса через окружение среды в терминале:
        // suiap -p someplaylist    : Будет проигрываться плейлист в базе данных, расширение в запрос писать не нужно
        // Или же полностью равносильный запрос, только более понятный человеку
        // suiap --play someplaylist
        //
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Menus menu = new Menus();
            
            if (Modules.OsChecker() == "linux")
                Modules.Logo("rick.txt");
                
            Modules.Logo("SUIAP.txt");
            menu.MainMenu();
            
        }
    }
}
