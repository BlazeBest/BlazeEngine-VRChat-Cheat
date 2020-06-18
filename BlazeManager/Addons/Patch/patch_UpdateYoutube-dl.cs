using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Diagnostics;
using BlazeTools;
using UnityEngine;

namespace Addons.Patch
{
    public static class patch_UpdateYoutube_dl
    {
        public static void Start()
        {
            string srcYoutubeDL = Application.streamingAssetsPath + "/youtube-dl.exe";
            if (File.Exists(srcYoutubeDL))
                currentVersion = FileVersionInfo.GetVersionInfo(srcYoutubeDL).ProductVersion;
            Uri uri = new Uri(apiGitHub);
            
            ServicePointManager.SecurityProtocol = WebTools.SecureProtocol.SSL;
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12");
                webClient.Headers.Add("Accept", "*/*");
                webClient.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
                webClient.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");

                Stream stream = webClient.OpenRead(uri);
                StreamReader streamReader = new StreamReader(stream);
                try
                {
                    string _result = streamReader.ReadToEnd();
                    string[] args = _result.Split('\n').Where(x => x.Contains("\"tag_name\"")).ToArray();
                    if (args.Length > 0)
                    {
                        foreach (string arg in args)
                        {
                            string[] templist = arg.Split(new char[] { ':' }, 2);
                            if (templist.Length == 2)
                            {
                                string[] temparg = templist[1].Split('"');
                                if (temparg.Length == 3)
                                {
                                    apiVersion = temparg[1];

                                    if (apiVersion == currentVersion)
                                    {
                                        ConSole.Success("You use last version Youtube-dl! [" + apiVersion + "]");
                                        return;
                                    }
                                }
                            }
                        }

                    }
                    else
                        throw new Exception("Not found a tag_name");
                }
                catch
                {
                    ConSole.Error("Patch: Youtube-dl");
                }
                finally
                {
                    streamReader.Close();
                    stream.Close();
                }


            }

            ServicePointManager.SecurityProtocol = WebTools.SecureProtocol.SSL;

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12");
                webClient.Headers.Add("Accept", "*/*");
                webClient.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
                webClient.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");

                try
                {
                    webClient.DownloadFile("https://github.com/ytdl-org/youtube-dl/releases/download/" + apiVersion + "/youtube-dl.exe", srcYoutubeDL);
                    ConSole.Success("Downloaded! You are installed last version Youtube-dl! [" + apiVersion + "]");
                }
                catch
                {
                    ConSole.Error("Patch: Bad download!");
                }
            }
        }

        private static string apiGitHub = "https://api.github.com/repos/ytdl-org/youtube-dl/releases/latest";
        private static string apiVersion = "0";

        private static string currentVersion = "0";
    }
}
