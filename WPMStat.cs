using System;
using static TypingTest.TimeStat;

namespace TypingTest
{
	class WPSStat
	{
		private static string _TotalTypedText = default;
		public static double TypedWords = 0f;

		public static void ShowWPS()
		{
			_TotalTypedText = Math.Round(TypedWords / _TypingTime.TotalSeconds, 2).ToString();

			Console.CursorLeft = Console.WindowWidth - $"WPS: {_TotalTypedText}".Length - 1;
			Console.Write($"WPS: {_TotalTypedText}");

			Console.SetCursorPosition(0, 3);
		}
	}
}
