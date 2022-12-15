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
        string Menu_7_FindFileInPlaylist_ChoosePlaylist();
        void MainMenu();
        void Menu_5_DeletePlaylist();
        void Menu_4_AddDir();
        void Menu_3_DeleteFiles();
        void Menu_2_AddFiles();
        void Menu_1_PlayFiles();
        void Menu_7_FindFileInPlaylist();
        void Menu_6_ShowPlaylistFiles();


        void MenuPlayer_1();
        void MenuShower_2();
        void MenuAdder_3();
        void MenuFinder_4();
        void MenuDeleter_5();
    }
}
