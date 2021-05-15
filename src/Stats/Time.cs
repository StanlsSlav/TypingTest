using System;

namespace TypingTest.Stats
{
    internal static class Time
    {
        public static readonly TimeSpan TypingTime = TimeSpan.FromMinutes(0);
        public static double TotalTime = TypingTime.TotalSeconds;

        public static void ShowTime()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("Time: " + TotalTime);

            switch (TotalTime)
            {
                // Avoid the high time visual bug
                case 10:
                    Console.Clear();
                    break;
                case 0:
                    MainClass.Run = false;
                    break;
            }
        }
    }
}