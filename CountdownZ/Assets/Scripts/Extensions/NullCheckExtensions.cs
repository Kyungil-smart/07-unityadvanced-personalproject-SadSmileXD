using UnityEngine;

public static class NullCheckExtensions
{
    public static bool IsNotNull<T>(this T obj) where T : UnityEngine.Object
    {
        if(obj == null)
        {
            
            return false;

        }
        else
        {
            return true;
        }
 
    }
}
