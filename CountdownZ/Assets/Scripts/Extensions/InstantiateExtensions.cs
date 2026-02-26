using UnityEngine;

public static class InstantiateExtensions
{
    public static T CopyData<T>(this T obj) where T : ScriptableObject
    {
        return Object.Instantiate(obj);
    }
}
