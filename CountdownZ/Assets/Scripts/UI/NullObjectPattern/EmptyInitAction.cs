using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyInitAction : Iinitialize
{
    MonoBehaviour m_Owner;
    public void Initialize(MonoBehaviour Owner, object[] datas)
    {
        Debug.Log($"{m_Owner} : 할당된 init이 없습니다");
    }
    public EmptyInitAction(MonoBehaviour Owner)
    {
        m_Owner=Owner;
    }
}
