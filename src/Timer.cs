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

		public static async Task ShowStats()
		{
			while (MainClass.Run)
			{
				ShowTime();
				ShowWPS();

				CheckWidth();

				WriteLine(_LoremText);
				SetCursorPosition(Column, Row);

				await Task.Delay(TimeSpan.FromSeconds(1));
				TotalTime -= 1;
			}

			Clear();
			WriteLine($"Test finished" +
				$"\n\nTyped {Math.Round(TypedWords / TypingTime.TotalSeconds, 2)} words per second " +
				$"- {TypedWords} words per minute " +
				$"- Possibly {TypedWords * TypingTime.TotalSeconds} words per hour");

			//Avoid console exit if user keeps typing
			Thread.Sleep(TimeSpan.FromSeconds(2));
			Environment.Exit(1);
		}

		private static void CheckWidth()
		{
			if (_consoleWidth != WindowWidth)
			{
				_consoleWidth = WindowWidth;
				Clear();

				ShowTime();
				ShowWPS();

				Write(_LoremText);
				SetCursorPosition(0, 3);
			}
		}
	}
}
