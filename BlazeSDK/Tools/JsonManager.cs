using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeSDK.Tools.JsonMini;

namespace BlazeSDK.Tools
{
    public class JsonManager
    {
        public static T ReadData<T>(JsonData data) => data.ReadData<T>();

        public static void Create(string file, Dictionary<string, JsonData> data)
        {
            string buffer = "{";
            foreach (var arg in data)
            {
                if (buffer.Length > 1)
                    buffer += ",";

                buffer += "\"" + arg.Key + "\":";
                if (arg.Value.type == JsonType.String)
                    buffer += "\"" + arg.Value.data + "\"";
                else if (arg.Value.type == JsonType.Double)
                    buffer += arg.Value.data.ToString().Replace(",",".");
                else
                    buffer += arg.Value.data;
            }
            buffer += "}";
            File.WriteAllText(file, buffer, Encoding.UTF8);
        }

        public static Dictionary<string, JsonData> Reader(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException();

            Dictionary<string, JsonData> result = new Dictionary<string, JsonData>();

            string readText = File.ReadAllText(file);
            string source = WorkingOnHead(readText);

            string[] args = source.Split(',');
            foreach(string arg in args)
            {
                string buffer = arg.Trim();
                string[] content = buffer.Split(new char[] { ':' }, 2);
                if (content.Length < 2)
                    continue;

                if (content[0].Length < 1 && content[1].Length < 1)
                    continue;

                content[0] = content[0].Trim(new char[] { '"', ' ' });
                
                if (!UnboxText(content[1], out JsonData data))
                    continue;

                result.Add(content[0], data);
            }

            return result;
        }

        internal static string WorkingOnHead(string text)
        {
            string result = text;
            result = result.Trim(new char[] { '{', '}', ' ' });
            return result;
        }

        internal static bool UnboxText(string text, out JsonData data)
        {
            text = text.Trim();
            data = new JsonData();
            data.type = JsonType.None;
            if (text.Contains("null"))
            {
                data.type = JsonType.Object;
                data.data = null;
            }
            else if (text.Contains("True"))
            {
                data.type = JsonType.Boolean;
                data.data = true;
            }
            else if (text.Contains("False"))
            {
                data.type = JsonType.Boolean;
                data.data = false;
            }
            else if (text[0] == '"' && text[text.Length - 1] == '"' && text.Length > 1)
            {
                text = text.Remove(0, 1);
                text = text.Remove(text.Length - 1, 1);

                data.type = JsonType.String;
                data.data = text;
            }
            else if (text.IndexOf('.') == -1)
            {
                data.type = JsonType.Int;
                data.data = int.Parse(text);
            }
            else if (text.IndexOf('.') < text.Length)
            {
                data.type = JsonType.Double;
                data.data = double.Parse(text.Replace(".",","));
            }
            return data.type != JsonType.None;
        }
    }
}
