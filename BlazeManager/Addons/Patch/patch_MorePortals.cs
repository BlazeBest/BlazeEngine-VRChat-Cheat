using System;
using System.Linq;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;

namespace Addons.Patch
{
    public static class patch_MorePortals
    {
        public static void Start()
        {
            IL2Method[] methods = null;
            try
            {
                methods = Assemblies.a["Assembly-CSharp"].GetClass("RoomManagerBase").GetMethods().Where(x => x.GetParameters().Length == 1).Where(x => x.GetParameters()[0].typeName == "PortalInternal").ToArray();
                if (methods == null)
                    throw new Exception();

                foreach (IL2Method method in methods)
                    IL2Ch.Patch(method, typeof(patch_MorePortals).GetMethod("patch_method", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: More Portals [1]");
            }
            catch
            {
                ConSole.Error("Patch: More Portals [1]");
            }
#if (DEBUG)
            try
            {
                methods = Assemblies.a["Assembly-CSharp"].GetClass("ObjectInstantiator").GetMethods().Where(x => x.GetParameters().Length == 2).Where(x => x.GetParameters()[0].typeName == "VRC.Player" && x.GetParameters()[1].typeName.StartsWith("ObjectInstantiator.")).ToArray();
                if (methods == null)
                    throw new Exception();

                foreach (IL2Method method in methods)
                    IL2Ch.Patch(method, typeof(patch_MorePortals).GetMethod("patch_method_2", BindingFlags.Static | BindingFlags.NonPublic));
                ConSole.Success("Patch: More Portals [2]");
            }
            catch
            {
                ConSole.Error("Patch: More Portals [2]");
            }
#endif
        }

        private static void patch_method()
        {

        }

#if (DEBUG)
        private static bool patch_method_2()
        {
            return false;
        }
#endif
    }
}
