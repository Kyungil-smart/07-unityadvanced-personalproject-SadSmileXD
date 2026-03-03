using UnityEngine;

public static class NullCheckExtensions
{
    public static bool IsNotNull<T>(this T obj) where T : UnityEngine.Object
    {
        if(obj == null)
        {
            Debug.Log("IsNotNull null");
            return false;

        }
        else
        {
            return true;
        }
 
    }
}
