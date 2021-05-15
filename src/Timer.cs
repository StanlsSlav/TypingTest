using System;
using System.Threading;
using System.Threading.Tasks;
using static TypingTest.TypingProcess;
using static TypingTest.Stats.TimeStat;
using static TypingTest.Stats.WPSStat;
using static System.Console;

namespace TypingTest
{
	class Timer
	{
		private static int _ConsoleWidth = WindowWidth;

		public static async Task ShowStats()
		{
			while (MainClass._Run)
			{
				ShowTime();
				ShowWPS();

				CheckWidth();

				WriteLine(_LoremText);
				SetCursorPosition(Column, Row);

				await Task.Delay(TimeSpan.FromSeconds(1));
				_Time -= 1;
			}

			Clear();
			WriteLine($"Test finished" +
				$"\n\nTyped {Math.Round(TypedWords / _TypingTime.TotalSeconds, 2)} words per second " +
				$"- {TypedWords} words per minute " +
				$"- Possibly {TypedWords * _TypingTime.TotalSeconds} words per hour");

			//Avoid console exit if user keeps typing
			Thread.Sleep(TimeSpan.FromSeconds(2));
			Environment.Exit(1);
		}

		private static void CheckWidth()
		{
			if (_ConsoleWidth != WindowWidth)
			{
				_ConsoleWidth = WindowWidth;
				Clear();

				ShowTime();
				ShowWPS();

				Write(_LoremText);
				SetCursorPosition(0, 3);
			}
		}
	}
}
