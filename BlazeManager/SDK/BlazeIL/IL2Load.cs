using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
/*
 * NET for Web
 */
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace BlazeIL
{
    public class IL2Load
    {
#if (!DEBUG)
        public static void LoadOffset()
        {
            var \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 = AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.GetName().Name == "BlazeManager")
                .GetType("BlazeLoad")
                .GetMethod("Load_0ff", BindingFlags.Static | BindingFlags.NonPublic);
            if (\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 == null)
                return;

            AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.GetName().Name == "BlazeIL")
                .GetType("BlazeIL.IL2Load")
                .GetProperty("\u01C5Ǆ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5Ǆ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5")
                .GetSetMethod()
                .Invoke(null, new object[] {
                    \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5.Invoke(null, new object[] { AppDomain.CurrentDomain.GetAssemblies()
                        .First(a => a.GetName().Name == "BlazeIL")
                        .GetType("BlazeIL.IL2Load")
                        .GetProperty("\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5")
                        .GetGetMethod().Invoke(null, null) })
                    });
        }

        public static int[] FindOffset(string \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5)
        {
            if ((bool)AppDomain.CurrentDomain.GetAssemblies()
                            .First(a => a.GetName().Name == "BlazeIL")
                            .GetType("BlazeIL.IL2Load")
                            .GetMethod("\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5")
                            .Invoke(null, new object[]
                            {
                                AppDomain.CurrentDomain.GetAssemblies()
                                    .First(a => a.GetName().Name == "BlazeIL")
                                    .GetType("BlazeIL.IL2Load")
                                    .GetProperty("\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5")
                                    .GetGetMethod().Invoke(null, null)
                            }))
                return null;

            List<int> \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 = new List<int>();
            foreach(string \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 in ((Dictionary<string, string>)AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.GetName().Name == "BlazeIL")
                .GetType("BlazeIL.IL2Load")
                .GetProperty("\u01C5Ǆ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5Ǆ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5")
                .GetGetMethod()
                .Invoke(null, null)).First(x => x.Key == \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5).Value.Split(' '))
                \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5.Add(int.Parse(\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5));
            return \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5.ToArray();
        }

        public static void SendPrivateKey(string \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5)
        {
            if ((bool)AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.GetName().Name == "BlazeIL")
                .GetType("BlazeIL.IL2Load")
                .GetMethod("\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5")
                .Invoke(null, new object[] { \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 }))
            AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.GetName().Name == "BlazeIL")
                .GetType("BlazeIL.IL2Load")
                .GetProperty("\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5")
                .GetSetMethod()
                .Invoke(null, new object[] { \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 });
        }
        public static object \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5(object \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5) => \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 == null || (string)\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 == string.Empty;
        public static object \u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 { get; private set; }
        public static object \u01C5Ǆ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5Ǆ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5 { get; private set; }
#else
        public static void LoadOffset()
        {
            MethodInfo method = AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.GetName().Name == "BlazeManager")
                .GetType("BlazeLoad")
                .GetMethod("Load_0ff", BindingFlags.Static | BindingFlags.NonPublic);
            if (method == null)
                return;

            keyValues = (Dictionary<string, string>)method.Invoke(null, new object[] { private_key });
            // if (keyValues.)
        }

        public static int[] FindOffset(string keyname)
        {
            if (string.IsNullOrEmpty(private_key))
                return null;

            List<int> result = new List<int>();
            foreach(string v in keyValues.First(x => x.Key == keyname).Value.Split(' '))
                result.Add(int.Parse(v));
            return result.ToArray();
        }

        public static void SendPrivateKey(string keycode)
        {
            if (string.IsNullOrEmpty(keycode))
                return;

            private_key = keycode;
        }

        public static void AddPrivateKey(string KeyName, string tokens)
        {
            keyValues.Add(KeyName, tokens);
        }


        internal static string private_key = string.Empty;
        internal static Dictionary<string, string> keyValues = new Dictionary<string, string>();
#endif

        public static string IL2URL_Reader(string uri)
        {
            string result = default;
            Uri newURI = new Uri(httpRequestBase, uri);

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(MyRemoteCertificateValidationCallback);
            using (WebClient webClient = new WebClient())
            {
                Stream stream = webClient.OpenRead(newURI);
                StreamReader reader = new StreamReader(stream);
                try
                {
                    if (stream == null)
                        throw new Exception();

                    if (reader == null)
                        throw new Exception();

                    result = reader.ReadToEnd();
                }
                catch
                {
                    result = "{\"Error\":\"499 Closed Request\"}";
                }
                finally
                {
                    if (reader != null)
                        reader.Close();

                    if (stream != null)
                        stream.Close();
                }
            }
            return result;
        }

        static bool MyRemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors > SslPolicyErrors.None)
            {
                for (int i = 0; i < chain.ChainStatus.Length; i++)
                {
                    if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                        continue;

                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                    if (!chain.Build((X509Certificate2)certificate))
                        return false;
                }
            }
            return true;
        }
        private static Uri httpRequestBase = new Uri("http://icefrag.ru");

        public static string buildVersion = "a1";
    }
}
