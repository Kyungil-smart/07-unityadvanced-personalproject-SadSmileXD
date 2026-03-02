using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmptyExitAction : IPointerExitHandler
{
    MonoBehaviour m_Owner;
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log($"{m_Owner} : 할당된 Exit데이터가 없습니다.");
    }

    public EmptyExitAction(MonoBehaviour Owner)
    {
        m_Owner=Owner;
    }
}
