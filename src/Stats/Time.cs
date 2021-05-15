using System;

namespace TypingTest.Stats
{
	class TimeStat
	{
		public static readonly TimeSpan _TypingTime = TimeSpan.FromMinutes(1);
		public static double _Time = _TypingTime.TotalSeconds;

		public static void ShowTime()
		{
			Console.SetCursorPosition(0, 0);
			Console.Write($"Time: {_Time}");

			//Avoid the high time visual bug
			if (_Time == 10)
				Console.Clear();

			else if (_Time == 0)
				MainClass._Run = false;
		}
	}
}
