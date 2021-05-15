using System;

namespace TypingTest.Stats
{
	class TimeStat
	{
		public static readonly TimeSpan TypingTime = TimeSpan.FromMinutes(1);
		public static double Time = TypingTime.TotalSeconds;

		public static void ShowTime()
		{
			Console.SetCursorPosition(0, 0);
			Console.Write($"Time: {Time}");

			//Avoid the high time visual bug
			if (Time == 10)
				Console.Clear();

			else if (Time == 0)
				MainClass.Run = false;
		}
	}
}
