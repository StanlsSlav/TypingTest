using System.Threading.Tasks;
using static TypingTest.Timer;

namespace TypingTest
{
    internal static class MainClass
    {
        public static bool Run = true;

        private static async Task Main()
        {
            var statsTask = Task.Run(ShowStats);
            var typingTask = Task.Run(TypingProcess.StartTyping);

            await Task.WhenAll(statsTask, typingTask);
        }
    }
}