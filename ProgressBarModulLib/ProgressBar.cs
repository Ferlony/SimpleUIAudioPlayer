namespace ProgressBarModulLib;

public class ProgressBar
{
    private static int barWidth = 20;

    private static string back = "\n";
    private static string block = "#";
    private static string blockempt = "=";
    private static int currentPosition = 0;

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


    public static string DrawProgressBar(int currentLength, int maxLength, bool update = false)
    {
        string bar = "";
        bar += "[";

        currentPosition = ((currentLength * barWidth) / maxLength);

        for (int i = 0; i < barWidth; i++)
        {
            if (i > currentPosition)
            {
                bar += blockempt;
            }
            else
            {
                bar += block;
            }
        }

        bar += $"] {TurnToMenute(currentLength)} / {TurnToMenute(maxLength)}";
        return bar;
    }

    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.SetCursorPosition(0, Console.CursorLeft);
        Console.Write(new string(' ', Console.WindowWidth));
    }


    public static string TurnToMenute(int length)
    {
        return MakeBeauty(length);
    }

    private static string MakeBeauty(int arg)
    {
        return (arg / 60000).ToString() + "." + ((arg % 60000) / 1000).ToString();
    }

    //internal static void DeleteFile(FileInfo file)
    //{
    //    if (file.Exists)
    //    {
    //        Console.WriteLine(file.FullName);
    //        file.Delete();
    //        Console.WriteLine($"Файл {file.Name} успешно удален");
    //    }
    //    else
    //    {
    //        Console.WriteLine($"Файл {file.Name} не существует");
    //    }
    //}

    //internal static void CreateFile(FileInfo file)
    //{
    //    if (file.Exists)
    //    {
    //        Console.WriteLine($"Файл {file.Name} уже существует");
    //    }
    //    else
    //    {
    //        Console.WriteLine(file.FullName);
    //        file.Create().Dispose();
    //        Console.WriteLine($"Файл {file.Name} создан");
    //    }
    //}

    //public static FileInfo ProgressBarCreateFile()
    //{
        
    //    string filePath = @$".{Path.DirectorySeparatorChar}modules{Path.DirectorySeparatorChar}progbar.txt";
    //    FileInfo file = new FileInfo(filePath);
    //    try
    //    {
    //        DeleteFile(file);
    //    }
    //    catch
    //    {
    //        Console.Write("");
    //    }
    //    CreateFile(file);
    //    return file;

        
    //}
}
