using System;

namespace BlazeTools
{
    public class Types
    {
        internal static Type[] unmanagedTypes = {
            typeof(sbyte),
            typeof(byte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(char),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(bool)
        };

        internal static Type[] otherUnmanagedTypes =
        {
            typeof(UnityEngine.Color),
            typeof(UnityEngine.Mathf),
            typeof(UnityEngine.Quaternion),
            typeof(UnityEngine.Ray),
            typeof(UnityEngine.RaycastHit),
            typeof(UnityEngine.Rect),
            typeof(UnityEngine.Vector2),
            typeof(UnityEngine.Vector3),
            typeof(UnityEngine.Vector4)
        };

    }
}
