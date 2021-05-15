using System;
using System.Threading.Tasks;
using static TypingTest.Timer;
using static TypingTest.Stats.Wps;

namespace TypingTest
{
	internal static class MainClass
	{
		public static bool Run = true;

		static async Task Main()
		{
			var statsTask = Task.Run(() => ShowStats());
			var typingTask = Task.Run(() => TypingProcess.StartTyping());

			await Task.WhenAll(statsTask, typingTask);
		}
	}

	internal static class TypingProcess
	{
		public static readonly string _LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ";
		private static readonly char[] CharsToType = _LoremText.ToCharArray();

		private static int _currentIndex;
		public static int Row = 3, Column;

		public static Task StartTyping()
		{
			while (_currentIndex < CharsToType.Length)
			{
				var keyPress = Console.ReadKey(true).KeyChar;

				//Instant turn off or increment typed keys
				switch ((ConsoleKey)keyPress)
				{
					case ConsoleKey.Escape: MainClass.Run = false; break;
					case ConsoleKey.Spacebar: TypedWords++; break;
				}

				if (keyPress == CharsToType[_currentIndex])
				{
					_currentIndex++;
					Column++;

					if (Column >= Console.WindowWidth)
					{
						Column %= Console.WindowWidth;
						Row++;
					}

					Console.SetCursorPosition(Column, Row);
				}
			}

			return Task.CompletedTask;
		}
	}
}
