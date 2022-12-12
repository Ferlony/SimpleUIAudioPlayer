using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dotnet
{
    class NoPlaylistChosenException : Exception
    {
        public NoPlaylistChosenException() { }

        public NoPlaylistChosenException(string message)
            : base(message)
        {
        }
    }
}
