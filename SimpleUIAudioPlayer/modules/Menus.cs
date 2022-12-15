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
        /*
        Console.WriteLine(
                "Выберите действие\n" +
                "'1' Проиграть файлы в плейлисте\n" +
                "'2' Добавить файлы в плейлист\n" +
                "'3' Удалить файлы из плейлиста\n" +
                "'4' Добавить папку в плейлист\n" +
                "'5' Удалить папку из плейлиста\n" +
                "'0' Выйти из программы");
        */
        //Объявления
        // public static void MainMenu();
        // private static void Menu_1_PlayFiles();
        // private static void Menu_2_AddFiles();
        //private static void Menu_2_AddFiles_ChoosePlaylist();
        // private static void Menu_3_DeleteFiles();
        // private static void Menu_4_AddDir();
        // private static void Menu_5_DeletePlaylist();

        public void MainMenu()
        {
            string a;
            bool flag = true;
            while (flag) // Заменить
            {
                Console.WriteLine(
                "Выберите действие\n" +
                "'1' Проиграть файлы в плейлисте\n" +
                "'2' Показать плейлисты\n" +
                "'3' Добавить файлы в плейлист\n" +
                "'4' Удалить файлы из плейлиста\n" +
                "'5' Добавить папку в плейлист\n" +
                "'6' Удалить плейлист\n" +
                "'0' Выйти из программы\n"+
                "'t' test");
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
                            WorkerDB.ShowPlaylistDB(true);
                            break;
                        }
                    case "3":
                        {
                            Menu_2_AddFiles();
                            break;
                        }
                    case "4":
                        {
                            Menu_3_DeleteFiles();
                            break;
                        }
                    case "5":
                        {
                            Menu_4_AddDir();
                            break;
                        }
                    case "6":
                        {
                            Menu_5_DeletePlaylist();
                            break;
                        }
                    case "0":
                        {
                            flag = false;
                            Console.WriteLine("Выход из программы");
                            break;
                        }
                    case "t":
                        {
                            string dirPath = "/home/theuser/Programms/Cs/SimpleUIAudioPlayer/Test/Music/TestMus/";
                            string playlistName = "testdir";
                            WorkerDB.AddAllDirsToPlaylist(dirPath, playlistName);
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

        public string Menu_2_AddFiles_ChoosePlaylist()
        {
            string a;
            bool flag = true;
            string playlistName = "";//"ErrorNamePlayList";
            while (flag)
            {
                Console.WriteLine("Будет выбран последний выбранный или созданный плейлист\n" +
                    "'1' Выберете плейлист\n"+
                    "'2' Создайте новый\n"+
                    "'0' Выход из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        WorkerDB.ShowPlaylistDB(true);
                        Console.WriteLine("Введите название плейлиста");
                        playlistName = Console.ReadLine();
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("Введите название плейлиста");
                        playlistName = Console.ReadLine();
                        WorkerDB.CreatePlaylist(playlistName);
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
            
            while (flag) // Заменить
            {
                Console.WriteLine(
                    "'1' Удалить плейлист\n"+
                    "'0' Выйти из меню");

                a = Console.ReadLine();
                
                switch(a)
                {
                    case "1":
                    {
                        WorkerDB.ShowPlaylistDB(true);
                        Console.WriteLine("Введите название плейлиста");
                        string playlistName = Console.ReadLine();
                        WorkerDB.DeletePlaylist(playlistName);
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
                while (flag) // Заменить
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
                                        WorkerDB.AddAllDirsToPlaylist(path, playlistName);
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
            while (flag) // Заменить
            {
                Console.WriteLine(
                    "'1' Удалить файлы\n"+
                    "'0' Выйти из меню");

                a = Console.ReadLine();
                
                switch(a)
                {
                    case "1":
                    {
                        Console.WriteLine("Выберите файлы\n");
                        try
                        {
                            // Вписать путь? Массивом?
                            // Здесь должна быть функция
                            // foo(path)
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Какая-то ошибка");
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

        
        public void Menu_2_AddFiles()
        {
            string a;
            bool flag = true;
            string playlistName = null;

            try
            {
                playlistName = Menu_2_AddFiles_ChoosePlaylist();
                while (flag) // Заменить
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
                                        WorkerDB.AddFileToPlaylist(path, playlistName);
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
            string a;
            bool flag = true;
            while (flag) // Заменить
            {
                Console.WriteLine("Выберите плейлист:");
                // Здесь должен быть вывод списка файлов плейлиста
                // Работа с файлами
                // Выбор проигрывания
                Console.WriteLine("'0' Выход из меню");
                a = Console.ReadLine();
                //if a == playlistValue {}
                //else 
                if (a == "0")
                {
                    flag = false;
                    Console.WriteLine("Выход из меню");
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                }
            }
        }

    }
}
