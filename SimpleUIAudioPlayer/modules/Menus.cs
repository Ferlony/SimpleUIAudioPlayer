using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;


namespace Dotnet
{
    public class Menus: IMenus
    {
        public void MainMenu()
        {
            string a;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(
                    "Выберите действие\n" +
                    "'1' Проиграть\n" +
                    "'2' Показать\n" +
                    "'3' Добавить\n" +
                    "'4' Найти\n" +
                    "'5' Удалить\n" +
                    "'0' Выйти из программы\n");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        MenuPlayer_1();
                        break;
                    }
                    case "2":
                    {
                        MenuShower_2();
                        break;
                    }
                    case "3":
                    {
                        MenuAdder_3();
                        break;
                    }
                    case "4":
                    {
                        MenuFinder_4();
                        break;
                    }
                    case "5":
                    {
                        MenuDeleter_5();
                        break;
                    }
                    case "0":
                    {
                        flag = false;
                        Console.WriteLine("Выход из программы");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
                }
            }
        }
        //
        //
        // Нужно сделать шаблон для менюшек или что-то подобное
        // и далее переопределять его
        //
        //

        public void MenuPlayer_1()
        {
            
            string a;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine(
                    "'1' Проиграть плейлист\n" +
                    "'2' Пауза\n" +
                    "'3' Воспроизвести\n" +
                    "'4' Настроить громкость\n" +
                    "'5' Перемотать\n" +
                    "'6' Начать заново\n" +
                    "'7' Следующий трек\n" +
                    "'0' Выйти из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        {
                            Menu_1_PlayFiles();
                            break;
                        }
                    case "2":
                        {
                            WorkerPlayer.Stop();
                            Console.WriteLine("Трек остановлен");
                            break;
                        }
                    case "3":
                        {
                            WorkerPlayer.Continue();
                            Console.WriteLine("Трек воспроизведен");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Выберите громкость");
                            int volume = Convert.ToInt32(Console.ReadLine());
                            WorkerPlayer.Volume(volume);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Введите количество секунд");
                            int time = Convert.ToInt32(Console.ReadLine());
                            WorkerPlayer.Rewind(time);
                            break;
                        }
                    case "6":
                        {
                            WorkerPlayer.Restart();
                            Console.WriteLine("Трек воспроизведен заново");
                            break;
                        }
                    case "7":
                        {
                            WorkerPlayer.Next();
                            Console.WriteLine("Воспроизведен следующий трек");
                            break;
                        }
                    case "0":
                        {
                            flag = false;
                            Console.WriteLine("Выход из программы");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод");
                            break;
                        }
                }
            }
        }
        
        public void MenuShower_2()
        {
            string a;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(
                    "'1' Показать плейлисты\n" +
                    "'2' Показать содержимое плейлиста\n" +
                    "'0' Выйти из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        AWorkerDB.ShowPlaylistDB(true);
                        break;
                    }
                    case "2":
                    {
                        Menu_6_ShowPlaylistFiles();
                        break;
                    }
                    case "0":
                    {
                        flag = false;
                        Console.WriteLine("Выход из программы");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
                }
            }
        }

        public void MenuAdder_3()
        {
            string a;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(
                    "'1' Добавить папку в плейлист\n" +
                    "'2' Добавить файл в плейлист\n" +
                    "'0' Выйти из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        Menu_4_AddDir();
                        break;
                    }
                    case "2":
                    {
                        Menu_2_AddFiles();
                        break;   
                    }
                    case "0":
                    {
                        flag = false;
                        Console.WriteLine("Выход из программы");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
                }
            }
        }

        public void MenuFinder_4()
        {
            string a;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(
                    "'1' Найти файл в плейлисте\n" +
                    "'2' Найти файл во всех плейлистах\n" + // Еще не сделано
                    "'0' Выйти из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        Menu_7_FindFileInPlaylist();
                        break;
                    }
                    case "2":
                    {
                        MenuFinder_4_FindStingInAllDB();   
                        break;
                    }
                    case "0":
                    {
                        flag = false;
                        Console.WriteLine("Выход из программы");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
                }
            }

        }

        public void MenuDeleter_5()
        {
            string a;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(
                    "'1' Удалить плейлист\n" +
                    "'2' Удалить файл из плейлиста\n" +
                    "'0' Выйти из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        Menu_5_DeletePlaylist();
                        break;
                    }
                    case "2":
                    {
                        Menu_3_DeleteFiles();
                        break;
                    }
                    case "0":
                    {
                        flag = false;
                        Console.WriteLine("Выход из программы");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
                }
            }
        }

        public void MenuFinder_4_FindStingInAllDB()
        {
            bool flag = true;
            while (flag)
                {
                    Console.WriteLine(
                        "'1' Найти файл во всех плейлистах\n" +
                        "'0' Выйти из меню");

                    string a = Console.ReadLine();

                    switch (a)
                    {
                        case "1":
                            {
                                AWorkerDB.ShowPlaylistDB(true);
                                Console.WriteLine("Введите название файла,\nкоторый хотите найти во всех плейлистах\n");
                                string stringToFind = Console.ReadLine();
                                if (stringToFind != "")
                                {
                                    try
                                    {
                                        AWorkerDB.FindStringInAllFiles(stringToFind);
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Пустой путь");
                                    break;
                                }
                            }
                        case "0":
                            {
                                flag = false;
                                Console.WriteLine("Выход из меню");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверный ввод");
                                break;
                            }
                    }
                }
        }

        public void Menu_6_ShowPlaylistFiles()
        {
            string a;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine(
                    "'1' Выберите плейлист\n" +
                    "'0' Выйти из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        {
                            AWorkerDB.ShowPlaylistDB(true);
                            Console.WriteLine("Введите название плейлиста\n");
                            string playlistName = Console.ReadLine();
                            if (playlistName != "")
                            {
                                try
                                {
                                    AWorkerDB.ShowPlaylistFiles(playlistName);
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пустой путь");
                                break;
                            }
                        }
                    case "0":
                        {
                            flag = false;
                            Console.WriteLine("Выход из меню");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод");
                            break;
                        }
                }
            }
        }

        public void Menu_7_FindFileInPlaylist()
        {
            string a;
            bool flag = true;
            string playlistName = null;
            try
            {
                playlistName = Menu_7_FindFileInPlaylist_ChoosePlaylist();

                while (flag)
                {
                    Console.WriteLine(
                        "'1' Найти файл в плейлисте\n" +
                        "'0' Выйти из меню");

                    a = Console.ReadLine();

                    switch (a)
                    {
                        case "1":
                            {
                                AWorkerDB.ShowPlaylistDB(true);
                                Console.WriteLine("Введите название файла в плейлисте,\nкоторый хотите найти\n");
                                string stringToFind = Console.ReadLine();
                                if (stringToFind != "")
                                {
                                    try
                                    {
                                        AWorkerDB.FindStringInFile(playlistName, stringToFind);
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Пустой путь");
                                    break;
                                }
                            }
                        case "0":
                            {
                                flag = false;
                                Console.WriteLine("Выход из меню");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверный ввод");
                                break;
                            }
                    }
                }
            }
            catch (NoPlaylistChosenException ex)
            {
                Console.WriteLine("Не был выбран плейлист");
            }
        }
        public string Menu_7_FindFileInPlaylist_ChoosePlaylist()
        {
            string a;
            bool flag = true;
            string playlistName = "";//"ErrorNamePlayList";
            while (flag)
            {
                Console.WriteLine("Будет выбран последний выбранный или созданный плейлист\n" +
                    "'1' Выберите плейлист\n"+
                    "'0' Выход из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        AWorkerDB.ShowPlaylistDB(true);
                        Console.WriteLine("Введите название плейлиста");
                        playlistName = Console.ReadLine();
                        break;
                    }
                    case "0":
                    {
                        flag = false;
                        Console.WriteLine("Выход из меню");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
                }
            }
            if (playlistName == "")
            {
                throw new NoPlaylistChosenException("NoPlaylistChosen");
            }
            return playlistName;
        }

        public string Menu_2_AddFiles_ChoosePlaylist()
        {
            string a;
            bool flag = true;
            string playlistName = "";//"ErrorNamePlayList";
            while (flag)
            {
                Console.WriteLine("Будет выбран последний выбранный или созданный плейлист\n" +
                    "'1' Выберите плейлист\n"+
                    "'2' Создайте новый\n"+
                    "'0' Выход из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        AWorkerDB.ShowPlaylistDB(true);
                        Console.WriteLine("Введите название плейлиста");
                        playlistName = Console.ReadLine();
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("Введите название плейлиста");
                        playlistName = Console.ReadLine();
                        AWorkerDB.CreatePlaylist(playlistName);
                        break;
                    }
                    case "0":
                    {
                        flag = false;
                        Console.WriteLine("Выход из меню");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
                }
            }
            if (playlistName == "")
            {
                throw new NoPlaylistChosenException("NoPlaylistChosen");
            }
            return playlistName;
            
        }

        

        public void Menu_5_DeletePlaylist()
        {
            string a;
            bool flag = true;
            
            while (flag) 
            {
                Console.WriteLine(
                    "'1' Удалить плейлист\n"+
                    "'0' Выйти из меню");

                a = Console.ReadLine();
                
                switch(a)
                {
                    case "1":
                    {
                        AWorkerDB.ShowPlaylistDB(true);
                        Console.WriteLine("Введите название плейлиста");
                        string playlistName = Console.ReadLine();
                        AWorkerDB.DeletePlaylist(playlistName);
                        break;
                    }
                    case "0":
                    {
                        flag = false;
                        Console.WriteLine("Выход из меню");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }
                }
            }
        }

         public void Menu_4_AddDir()
         {
            string a;
            bool flag = true;
            string playlistName = null;

            try
            {
                playlistName = Menu_2_AddFiles_ChoosePlaylist();
                while (flag) 
                {
                    Console.WriteLine(
                        "'1' Добавить директорию\n" +
                        "'0' Выйти из меню");

                    a = Console.ReadLine();

                    switch (a)
                    {
                        case "1":
                            {
                                Console.WriteLine("Введите путь до директории,\nкоторую хотите добавить в плейлист\n");
                                string path = Console.ReadLine();
                                if (path != "")
                                {
                                    try
                                    {
                                        AWorkerDB.AddAllDirsToPlaylist(path, playlistName);
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Пустой путь");
                                    break;
                                }
                            }
                        case "0":
                            {
                                flag = false;
                                Console.WriteLine("Выход из меню");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверный ввод");
                                break;
                            }
                    }


                }
            }
            catch (NoPlaylistChosenException ex)
            {
                Console.WriteLine("Не был выбран плейлист");
            }

        }

        public void Menu_3_DeleteFiles()
        {
            string a;
            bool flag = true;
            string playlistName = null;

            try
            {
                playlistName = Menu_2_AddFiles_ChoosePlaylist();
                while (flag) 
                {
                    Console.WriteLine(
                        "'1' Удалить файл из плейлиста\n"+
                        "'0' Выйти из меню");

                    a = Console.ReadLine();
                    
                    switch(a)
                    {
                        case "1":
                        {
                            Console.WriteLine("Введите название файла,\nкоторый хотите удалить\n");
                            string stringToDelete = Console.ReadLine();
                            if (stringToDelete != "")
                            {
                                try
                                {
                                    AWorkerDB.DeleteFileFromPlaylist(playlistName, stringToDelete);
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пустой путь");
                                break;
                            }

                        }
                        case "0":
                        {
                            flag = false;
                            Console.WriteLine("Выход из меню");
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Неверный ввод");
                            break;
                        }
                    }
                }
            }
            catch (NoPlaylistChosenException ex)
            {
                Console.WriteLine("Не был выбран плейлист");
            }
        }

        
        public void Menu_2_AddFiles()
        {
            string a;
            bool flag = true;
            string playlistName = null;

            try
            {
                playlistName = Menu_2_AddFiles_ChoosePlaylist();
                while (flag) 
                {
                    Console.WriteLine(
                        "'1' Добавить файлы\n" +
                        "'0' Выйти из меню");

                    a = Console.ReadLine();

                    switch (a)
                    {
                        case "1":
                            {
                                Console.WriteLine("Введите путь файла,\nкоторый хотите добавить в плейлист\n");
                                string path = Console.ReadLine();
                                if (path != "")
                                {
                                    try
                                    {
                                        AWorkerDB.AddFileToPlaylist(path, playlistName);
                                        break;

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        // Сюда логер с datatime
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Пустой путь");
                                    break;
                                }

                            }
                        case "0":
                            {
                                flag = false;
                                Console.WriteLine("Выход из меню");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверный ввод");
                                break;
                            }
                    }
                }
            }
            catch (NoPlaylistChosenException ex)
            {
                Console.WriteLine("Не был выбран плейлист");
            }
        }

        public void Menu_1_PlayFiles()
        {
            try
            {
                Console.WriteLine("Выберите плейлист:");
                WorkerPlayer player = new WorkerPlayer();
                player.CurrentPlaylistName = Menu_2_AddFiles_ChoosePlaylist();
                player.PlayAllSongsInPlaylist();
            }
            catch (NoPlaylistChosenException ex)
            {
                Console.WriteLine("Не был выбран плейлист");
            }
            
        }

    }
}
