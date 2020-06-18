using System;
using System.Linq;
using BlazeIL.il2cpp;
using VRC.Core;

public class RoomManagerBase
{
    private static IL2Method methodGetCurrentOwnerId = null;
    public static string currentOwnerId
    {
        get
        {
            if (methodGetCurrentOwnerId == null)
            {
                foreach (IL2Method method in Instance_Class.GetMethods().Where(x => x.GetReturnType().Name == "System.String" && x.GetParameters().Length == 0))
                {
                    string result = method.Invoke().Unbox<string>();
                    if (result.Length == 40)
                    {
                        if (result.Contains("usr_"))
                        {
                            methodGetCurrentOwnerId = method;
                            break;
                        }
                    }
                }
                if (methodGetCurrentOwnerId == null)
                    return string.Empty;
            }

            return methodGetCurrentOwnerId.Invoke()?.Unbox<string>();
        }
    }

    public static string CreatorInstanceId
    {
        get
        {
            if (currentRoom == null)
                return null;

            ApiWorldInstance apiWorldInstance = new ApiWorldInstance(currentRoom, currentRoom.currentInstanceIdWithTags, 0);
            return apiWorldInstance.GetInstanceCreator();
        }
    }

    private static IL2Field fieldCurrentRoom = null;
    public static ApiWorld currentRoom
    {
        get
        {
            if (fieldCurrentRoom == null)
            {
                fieldCurrentRoom = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "VRC.Core.ApiWorld");
                if (fieldCurrentRoom == null)
                    return null;
            }
            return fieldCurrentRoom.GetValue()?.Unbox<ApiWorld>();
        }
    }

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("RoomManagerBase");
}