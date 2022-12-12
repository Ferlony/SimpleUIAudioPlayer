using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;


namespace Dotnet
{
    interface IMenus
    {
        string Menu_2_AddFiles_ChoosePlaylist();
        void MainMenu();
        void Menu_5_DeletePlaylist();
        void Menu_4_AddDir();
        void Menu_3_DeleteFiles();
        void Menu_2_AddFiles();
        void Menu_1_PlayFiles();
    }
}
