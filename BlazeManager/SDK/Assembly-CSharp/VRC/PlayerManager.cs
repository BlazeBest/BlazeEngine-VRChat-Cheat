using System;
using System.Linq;
using BlazeIL.il2cpp;


namespace VRC
{
    public class PlayerManager
    {
        private static IL2Method methodGetAllPlayers;
        public static Player[] GetAllPlayers()
        {
            if(methodGetAllPlayers == null)
            {
                methodGetAllPlayers = Instance_Class.GetMethods().First(x => x.GetReturnType().Name == "VRC.Player[]" && x.HasFlag(IL2BindingFlags.METHOD_STATIC));
                if (methodGetAllPlayers == null)
                    return null;
            }

            return methodGetAllPlayers.Invoke().UnboxArray<Player>();
        }
        public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PlayerManager", "VRC");
    }
}