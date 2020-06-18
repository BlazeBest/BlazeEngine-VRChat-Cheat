using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Addons.Avatars
{
    public static class AvatarStatus
    {
        public static bool IsValidUrl(string url) => !string.IsNullOrEmpty(url) && url.Length < 90 && url.StartsWith("https://api.vrchat.cloud/api/1/file/file_") && url.EndsWith("/file");
        public static void OpenUrlBrowser(string url) => System.Diagnostics.Process.Start(url);
    }
}
