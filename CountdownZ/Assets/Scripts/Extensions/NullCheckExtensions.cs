using UnityEngine;

public static class NullCheckExtensions
{
    public static bool IsNotNull<T>(this T obj) where T : class
    {
        return obj != null;
    }
}
