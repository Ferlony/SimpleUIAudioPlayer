using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dotnet
{
    internal partial class Modules
    {
        public static void Logo(string logoname)
        {
            string dirPath = @$".{Path.DirectorySeparatorChar}modules{Path.DirectorySeparatorChar}logos";

            FileInfo logofile = new FileInfo(dirPath + Path.DirectorySeparatorChar + logoname);
            WorkerFiles.ReadFile(logofile, false);
        }
    }
}
