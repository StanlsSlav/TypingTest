using System;

namespace TypingTest.Stats
{
	internal static class TimeStat
	{
		public static readonly TimeSpan TypingTime = TimeSpan.FromMinutes(1);
		public static double TotalTime = TypingTime.TotalSeconds;

		public static void ShowTime()
		{
			Console.SetCursorPosition(0, 0);
			Console.Write($"Time: {TotalTime}");

			//Avoid the high time visual bug
			if (TotalTime == 10)
				Console.Clear();

			else if (TotalTime == 0)
				MainClass.Run = false;
		}
	}
}
