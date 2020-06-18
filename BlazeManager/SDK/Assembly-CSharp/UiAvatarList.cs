using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2reflection;
using BlazeIL.il2generic;
using BlazeIL.il2cpp;

unsafe public class UiAvatarList : UiVRCList
{
    public UiAvatarList(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;


    public enum Category
    {
        Internal,
        Public,
        Mine,
        Favorite,
        SpecificList,
        PublicQuest,
        Classic,
        Licensed
    }

    private static IL2Field fieldSpecificListIds = null;
    public string[] specificListIds
    {
        get
        {
            if (!IL2Get.Field("specificListIds", Instance_Class, ref fieldSpecificListIds))
                return default;

            return fieldSpecificListIds.GetValue(ptr).UnboxArray<string>();
        }
        set
        {
            if (!IL2Get.Field("specificListIds", Instance_Class, ref fieldSpecificListIds))
                return;

            List<IntPtr> list = new List<IntPtr>();
            foreach(string text in value)
                list.Add(IL2Import.il2cpp_string_new(text));

            fieldSpecificListIds.SetValue(ptr, list.ToArray().ArrayToIntPtr());
        }
    }

    private static IL2Field fieldCategory = null;
    public Category category
    {
        get
        {
            if (!IL2Get.Field("category", Instance_Class, ref fieldCategory))
                return default;

            return fieldCategory.GetValue(ptr).Unbox<Category>();
        }
        set
        {
            if (!IL2Get.Field("category", Instance_Class, ref fieldCategory))
                return;

            fieldCategory.SetValue(ptr, new IntPtr(&value));
        }
    }

    private static IL2Field fieldCacheSpecificList = null;
    public IL2Dictionary cacheSpecificList
    {
        get
        {
            if (fieldCacheSpecificList == null)
            {
                fieldCacheSpecificList = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "System.Collections.Generic.Dictionary<System.String,VRC.Core.ApiAvatar>");
                if (fieldCacheSpecificList == null)
                    return default;
            }
            return fieldCacheSpecificList.GetValue(ptr)?.MonoCast<IL2Dictionary>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiAvatarList");
}