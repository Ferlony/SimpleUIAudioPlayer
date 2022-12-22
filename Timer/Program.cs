using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;


namespace Dotnet
{
    class Timers
    {
        static void Main()
        {
            // Create an AutoResetEvent to signal the timeout threshold in the
            // timer callback has been reached.
            AutoResetEvent autoEvent = new AutoResetEvent(true);
            
            StatusChecker statusChecker = new StatusChecker(10);

            // Create a timer that invokes CheckStatus after one second, 
            // and every 1/4 second thereafter.
            Console.WriteLine("time");
            Timer stateTimer = new Timer(statusChecker.CheckStatus, autoEvent, 1000, 250);

            // // When autoEvent signals, change the period to every half second.
            // autoEvent.WaitOne();
            // stateTimer.Change(0, 500);
            // Console.WriteLine("\nChanging period to .5 seconds.\n");

            // // When autoEvent signals the second time, dispose of the timer.
            // autoEvent.WaitOne();
            // stateTimer.Dispose();
            // Console.WriteLine("\nDestroying timer.");
        }
    }
    class StatusChecker
{
    private int invokeCount;
    private int  maxCount;

    public StatusChecker(int count)
    {
        invokeCount  = 0;
        maxCount = count;
    }

    // This method is called by the timer delegate.
    public void CheckStatus(Object stateInfo)
    {
        AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
        Console.WriteLine("time");

        if(invokeCount == maxCount)
        {
            // Reset the counter and signal the waiting thread.
            invokeCount = 0;
            autoEvent.Set();
        }
    }
}

}