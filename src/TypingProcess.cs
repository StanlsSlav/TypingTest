using System;
using System.Threading.Tasks;
using TypingTest.Stats;

namespace TypingTest
{
    internal static class TypingProcess
    {
        public const string LoremText =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ";

        private static readonly char[] CharsToType = LoremText.ToCharArray();

        private static int _currentIndex;
        public static int Row = 3, Column;

        /// <summary>
        ///     Processes the user input while the test is running
        /// </summary>
        /// <returns>A complete task when the user reached the end of the test</returns>
        public static Task StartTyping()
        {
            while (_currentIndex < CharsToType.Length)
            {
                var keyPress = Console.ReadKey(true).KeyChar;

                // Instant turn off or increment typed keys
                switch ((ConsoleKey) keyPress)
                {
                    case ConsoleKey.Escape:
                        MainClass.Run = false;
                        break;
                    case ConsoleKey.Spacebar:
                        Wps.TypedWords++;
                        break;
                }

                if (keyPress != CharsToType[_currentIndex]) continue;

                _currentIndex++;
                Column++;

                if (Column >= Console.WindowWidth)
                {
                    Column %= Console.WindowWidth;
                    Row++;
                }

                Console.SetCursorPosition(Column, Row);
            }

            return Task.CompletedTask;
        }
    }
}