using System;
using BlazeSDK.Tools;

namespace BlazeTools
{
    public enum ConSoleStatus
    {
        Message = -1,
        Success,
        Error,
        Debug
    }

    public class ConSole
    {
        internal static bool Message(string text) => Print(ConSoleStatus.Message, text);
        internal static bool Success(string text) => Print(ConSoleStatus.Success, text);
        internal static bool Error(string text) => Print(ConSoleStatus.Error, text);
        internal static bool Debug(string text) => Print(ConSoleStatus.Debug, text);

        internal static bool Print(ConSoleStatus status, string message)
        {
            if (!ConsoleManager.IL2Console)
                return false;

            ConsoleColor consoleColor = default;
            string prefix = null;
            switch(status)
            {
                case ConSoleStatus.Success:
                    {
                        consoleColor = ConsoleColor.Green;
                        prefix = "[+] ";
                        break;
                    }
                case ConSoleStatus.Error:
                    {
                        consoleColor = ConsoleColor.Red;
                        prefix = "[-] ";
                        break;
                    }
                case ConSoleStatus.Debug:
                    {
                        consoleColor = ConsoleColor.Yellow;
                        prefix = "[->] ";
                        break;
                    }
                case ConSoleStatus.Message:
                    {
                        consoleColor = ConsoleColor.White;
                        prefix = "@ ";
                        break;
                    }
            }
            return Print(consoleColor, prefix, message);
        }

        internal static bool Print(ConsoleColor color, string coloredText, string text)
        {
            if (!ConsoleManager.IL2Console)
                return false;

            Console.ForegroundColor = color;
            Console.Write(coloredText + " ");
            Print(text);
            return true;
        }

        internal static bool Print(ConsoleColor color, string text)
        {
            if (!ConsoleManager.IL2Console)
                return false;

            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
            return true;
        }

        internal static bool Print(string text)
        {
            if (!ConsoleManager.IL2Console)
                return false;

            Console.ResetColor();
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
            return true;
        }
    }
}
