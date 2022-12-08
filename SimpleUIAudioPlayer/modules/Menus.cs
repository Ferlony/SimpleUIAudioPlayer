using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;


namespace Dotnet
{
    public static class Menus
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

        private static string Menu_2_AddFiles_ChoosePlaylist()
        {
            string a;
            bool flag = true;
            string playlistName = "ErrorNamePlayList";
            while (flag)
            {
                Console.WriteLine(
                    "'1' Выберете плейлист\n"+
                    "'2' Создайте новый\n"+
                    "'0' Выход из меню");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                    {
                        WorkerDB.ShowPlayListDB();
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
            return playlistName;
            
        }

        public static void MainMenu()
        {
            string a;
            bool flag = true;
            while (flag) // Заменить
            {
                Console.WriteLine(
                "Выберите действие\n" +
                "'1' Проиграть файлы в плейлисте\n" +
                "'2' Добавить файлы в плейлист\n" +
                "'3' Удалить файлы из плейлиста\n" +
                "'4' Добавить папку в плейлист\n" +
                "'5' Удалить плейлист\n" +
                "'0' Выйти из программы");
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
                            Menu_2_AddFiles();
                            break;
                        }
                    case "3":
                        {
                            Menu_3_DeleteFiles();
                            break;
                        }
                    case "4":
                        {
                            Menu_4_AddDir();
                            break;
                        }
                    case "5":
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
                    default:
                        {
                            Console.WriteLine("Неверный ввод");
                            break;
                        }
                }
            }
        }

        private static void Menu_5_DeletePlaylist()
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
                        WorkerDB.ShowPlayListDB();
                        Console.WriteLine("Введите название плейлиста");
                        string playlistName = Console.ReadLine();
                        WorkerDB.DeletePlayList(playlistName);
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

         private static void Menu_4_AddDir()
         {
            string a;
            bool flag = true;
            while (flag) // Заменить
            {
                Console.WriteLine(
                    "'1' Добавить директорию\n"+
                    "'0' Выйти из меню");

                a = Console.ReadLine();
                
                switch(a)
                {
                    case "1":
                    {
                        Console.WriteLine("Выберите директорию\n");
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

        private static void Menu_3_DeleteFiles()
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

        
        private static void Menu_2_AddFiles()
        {
            string a;
            bool flag = true;

            string playlistName = Menu_2_AddFiles_ChoosePlaylist();

            while (flag) // Заменить
            {
                Console.WriteLine(
                    "'1' Добавить файлы\n"+
                    "'0' Выйти из меню");

                a = Console.ReadLine();
                
                switch(a)
                {
                    case "1":
                    {
                        Console.WriteLine("Введите путь файла,\nкоторый хотите добавить в плейлисть\n");
                        string path = Console.ReadLine();
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

        private static void Menu_1_PlayFiles()
        {
            string a;
            bool flag = true;
            while (flag) // Заменить
            {
                Console.WriteLine("Выберите плейлист:");
                // Здесь должен быть вывод списка файлов плейлиста
                // Работа с файлами
                // Выбор проигрывания по порядку цифрами
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
