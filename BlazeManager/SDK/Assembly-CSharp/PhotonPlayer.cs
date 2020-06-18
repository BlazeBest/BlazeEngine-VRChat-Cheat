using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using ExitGames.Client.Photon;

public class PhotonPlayer : IL2Base
{
    public PhotonPlayer(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Method methodGetPhotonID = null;
    public int ID
    {
        get
        {
            if (methodGetPhotonID == null)
            {
                methodGetPhotonID = Instance_Class.GetMethods().Where(
                    x =>
                        x.Name.Length > 16 &&
                        x.GetReturnType().Name == "System.Int32" &&
                        x.GetParameters().Length == 0
                ).First(x => x.Invoke(ptr).Unbox<int>() > 0);
                if (methodGetPhotonID == null)
                    return default;
            }
                
            IL2Object result = methodGetPhotonID.Invoke(ptr);
            if (result == null)
                return default;

            return result.Unbox<int>();
        }
    }

    private static IL2Method methodGetPhotonUserId = null;
    public string UserId
    {
        get
        {
            if (methodGetPhotonUserId == null)
            {
                methodGetPhotonUserId = Instance_Class.GetMethods().First(
                    x =>
                        x.Name != "ToString" &&
                        x.GetReturnType().Name == "System.String" &&
                        x.GetParameters().Length == 0 &&
                        x.Invoke(ptr).Unbox<string>().Length == 36
                );
                if (methodGetPhotonUserId == null)
                    return null;
            }

            IL2Object result = methodGetPhotonUserId.Invoke(ptr);
            if (result == null)
                return null;

            return result.Unbox<string>();
        }
    }

    public static PhotonPlayer Find(int ID)
    {
        /*if (PhotonNetwork.networkingPeer != null)
        {
            return PhotonNetwork.networkingPeer.GetPlayerWithId(ID);
        }*/
        return null;
    }

    public PhotonPlayer Get(int id)
    {
        return PhotonPlayer.Find(id);
    }

    private static IL2Method methodGetNext = null;
    public PhotonPlayer GetNext()
    {
        if (methodGetNext == null)
        {
            methodGetNext = Instance_Class.GetMethods().FirstOrDefault(
                x =>
                    x.GetReturnType().Name == Instance_Class.Name &&
                    x.GetParameters().Length == 0
            );
            if (methodGetNext == null)
                return null;
        }

        IL2Object result = methodGetNext.Invoke(ptr);
        if (result == null)
            return null;
        
        return result.Unbox<PhotonPlayer>();
    }

    private static IL2Method methodGetNextFor = null;
    public PhotonPlayer GetNextFor(PhotonPlayer currentPlayer) => GetNextFor(currentPlayer.ID);
    public PhotonPlayer GetNextFor(int currentPlayer)
    {
        if (methodGetNextFor == null)
        {
            string tempMethod = Instance_Class.GetMethods().Where(
                x =>
                    x.GetParameters().Length == 1 &&
                    !x.HasFlag(IL2BindingFlags.METHOD_STATIC)
            ).First(
                x =>
                    x.GetReturnType().Name == Instance_Class.Name &&
                    IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == Instance_Class.Name
            ).Name;
            methodGetNextFor = Instance_Class.GetMethods().Where(
                x =>
                    x.Name == tempMethod &&
                    x.GetParameters().Length == 1 &&
                    !x.HasFlag(IL2BindingFlags.METHOD_STATIC)
            ).First(
                x =>
                    x.GetReturnType().Name == Instance_Class.Name &&
                    IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == "System.Int32"
            );
            if (methodGetNextFor == null)
                return null;
        }

        IL2Object result = methodGetNextFor.Invoke(ptr);
        if (result == null)
            return null;

        return result.Unbox<PhotonPlayer>();
    }

    private static IL2Field fieldHashtable = null;
    public Hashtable hashtable
    {
        get
        {
            if (fieldHashtable == null)
            {
                fieldHashtable = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "ExitGames.Client.Photon.Hashtable");
                if (fieldHashtable == null)
                    return null;
            }

            return fieldHashtable.GetValue(ptr)?.Unbox<Hashtable>();
        }
        set
        {
            if (fieldHashtable == null)
            {
                fieldHashtable = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "ExitGames.Client.Photon.Hashtable");
                if (fieldHashtable == null)
                    return;
            }

            fieldHashtable.SetValue(ptr, value.ptr);
        }
    }

    private static IL2Field fieldIsLocal = null;
    public bool isLocal
    {
        get
        {
            if (fieldIsLocal == null)
            {
                fieldIsLocal = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "System.Boolean" && x.HasFlag(IL2BindingFlags.FIELD_PUBLIC));
                if (fieldIsLocal == null)
                    return default;
            }

            return fieldIsLocal.GetValue(ptr).Unbox<bool>();
        }
    }

    private static IL2Method methodToString = null;
    public override string ToString()
    {
        if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
            return default;

        return methodToString.Invoke(ptr)?.Unbox<string>();
    }

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(VRC.Player.Instance_Class.GetFields().First(x => x.GetReturnType().Name.Length > 64).GetReturnType().Name);
}