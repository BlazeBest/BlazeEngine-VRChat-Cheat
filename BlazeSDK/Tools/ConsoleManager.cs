using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BlazeSDK.Tools
{
    public class ConsoleManager
    {
        [DllImport("kernel32.dll")]
        private static extern int AllocConsole();

        [DllImport("user32.dll")]
        [return: MarshalAs(2)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        internal static void Create()
        {
            if (!IL2Console)
                return;

            AllocConsole();
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.Clear();
            Console.Title = "[ VRChat ] BlazeBest loader is running...";
            SetForegroundWindow(GetConsoleWindow());
        }

        public static void Message(ConsoleColor Color, string Msg1, string Msg2)
        {
            if (!IL2Console)
                return;

            Console.ForegroundColor = Color;
            Console.Write(Msg1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Msg2);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static bool IL2Console = false;
    }
}
