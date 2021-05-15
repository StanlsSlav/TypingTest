using System;
using System.Threading;
using System.Threading.Tasks;
using static TypingTest.TypingProcess;
using static TypingTest.Stats.Time;
using static TypingTest.Stats.Wps;
using static System.Console;

namespace TypingTest
{
    internal static class Timer
    {
        private static int _consoleWidth = WindowWidth;

        /// <summary>
        ///     Prints the stats of the current session
        /// </summary>
        public static async Task ShowStats()
        {
            while (MainClass.Run)
            {
                ShowTime();
                ShowWps();

                CheckWidth();

                WriteLine(LoremText);
                SetCursorPosition(Column, Row);

                await Task.Delay(TimeSpan.FromSeconds(1));
                TotalTime -= 1;
            }

            Clear();
            WriteLine(
                $@"Typed {Math.Round(TypedWords / TypingTime.TotalSeconds, 2)} words per second
                   {TypedWords} words per minute
                   Possibly {TypedWords * TypingTime.TotalSeconds} words per hour"
            );

            // Avoid console exit if user keeps typing
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Environment.Exit(1);
        }

        /// <summary>
        ///     Redraws the stats in case the console was resized
        /// </summary>
        private static void CheckWidth()
        {
            if (_consoleWidth == WindowWidth) return;

            _consoleWidth = WindowWidth;
            Clear();

            ShowTime();
            ShowWps();

            Write(LoremText);
            SetCursorPosition(0, 3);
        }
    }
}