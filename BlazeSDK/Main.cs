using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Security.Policy;
using BlazeSDK.Tools;

namespace BlazeSDK
{
    public class Main
    {
        public static void Init()
        {
            ReadCommandLine();
            ConsoleManager.Create();
            if (ConsoleManager.IL2Console)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.OutputEncoding = Encoding.UTF8;

                int i = 40000;
                Random rand = new Random();
                while (--i > 0)
                {
                    Console.Write($"{rand.Next(9)} ");
                }
                Console.Clear();
                Console.WriteLine("============ [ BlazeManager is loaded ] ============");

                // Console.SetCursorPosition(0, Console.CursorTop - 1);
                // Console.WriteLine("Over previous line!!!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            _dirMods = Path.Combine(Environment.CurrentDirectory, "Mods");
            if (!Directory.Exists(_dirMods))
                Directory.CreateDirectory(_dirMods);
        }

        public static void ReadCommandLine()
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            foreach (string text in commandLineArgs)
            {
                if (text.CompareTo("--dev-console") == 0)
                {
                    ConsoleManager.IL2Console = true;
                }
            }
        }

        public static void onStart()
        {
            //if (File.Exists(Environment.CurrentDirectory + "\\BlazeEngine\\MonoLib\\SharpDisasm.dll"))
            //    LoadModule(Environment.CurrentDirectory + "\\BlazeEngine\\MonoLib\\SharpDisasm.dll", null, null, true);

            // Loader.Init();

            string[] files = Directory.GetFiles(_dirMods, "*.dll");
            if (ConsoleManager.IL2Console)
                Console.WriteLine($"Found dll files: {files.Length}");
            foreach (string file in files)
            {
                if (!file.EndsWith(".dll", true, null))
                    return;

                LoadModule(file, unsafeMode: false);
            }
            if (ConsoleManager.IL2Console)
                Console.WriteLine($"Loaded mod's: {listAssembly.Count}");

        }


        public static bool LoadModule(byte[] bytes, string type = "Bootloader", string method = "Init")
        {
            try
            {
                Assembly assembly = Assembly.Load(bytes);
                if (assembly == null)
                    throw new Exception();

                if (!string.IsNullOrEmpty(method) && !string.IsNullOrEmpty(type))
                    assembly.GetType(type).GetMethod(method).Invoke(null, new object[0]);

                listAssembly.Add(assembly);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
        public static bool LoadModule(string file, string type = "Bootloader", string method = "Init", bool unsafeMode = false, bool debugMsg = true)
        {
            if (!File.Exists(file))
                file = _dirMods + "\\" + file;

            string fileName = file.Split('\\').LastOrDefault();
            try
            {
                if (!File.Exists(file))
                    throw new Exception();

                Assembly assembly = null;
                if (unsafeMode)
                {
                    assembly = Assembly.LoadFrom(file);
                }
                else
                {
                    byte[] data = File.ReadAllBytes(file);
                    assembly = AppDomain.CurrentDomain.Load(data);
                }

                if (assembly == null)
                    throw new Exception();
                if (!string.IsNullOrEmpty(method) && !string.IsNullOrEmpty(type))
                    assembly.GetType(type).GetMethod(method).Invoke(null, new object[0]);
                listAssembly.Add(assembly);
                if (ConsoleManager.IL2Console && debugMsg)
                    ConsoleManager.Message(ConsoleColor.Green, "Module is Load: ", fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                if (ConsoleManager.IL2Console && debugMsg)
                    ConsoleManager.Message(ConsoleColor.Red, "Module bad load: ", fileName);
                return false;
            }
            return true;
        }


        private static string _dirMods;
        public static List<Assembly> listAssembly = new List<Assembly>();
    }
}