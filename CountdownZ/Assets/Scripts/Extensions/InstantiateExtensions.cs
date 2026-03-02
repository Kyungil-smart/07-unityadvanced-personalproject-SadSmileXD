using UnityEngine;

public static class InstantiateExtensions
{
    public static T Duplicate<T>(this T obj) where T : ScriptableObject
    {
        return Object.Instantiate(obj);
    }
}
