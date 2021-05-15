using System;
using System.Globalization;
using static TypingTest.Stats.Time;

namespace TypingTest.Stats
{
    internal static class Wps
    {
        private static string _totalTypedText;
        public static double TypedWords = 0d;

        /// <summary>
        ///     Prints the WPF of the user
        /// </summary>
        public static void ShowWps()
        {
            _totalTypedText = Math.Round(TypedWords / TypingTime.TotalSeconds, 2)
                .ToString(CultureInfo.InvariantCulture);

            Console.CursorLeft = Console.WindowWidth - ("WPS: " + _totalTypedText).Length - 1;
            Console.Write("WPS: " + _totalTypedText);

            Console.SetCursorPosition(0, 3);
        }
    }
}