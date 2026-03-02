using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmptyEnterAction : IPointerEnterHandler
{
    MonoBehaviour m_Owner;
    public void OnPointerEnter(PointerEventData eventData) =>
        Debug.Log($"{m_Owner} : 할당된 Enter가 없습니다.");

    public EmptyEnterAction(MonoBehaviour Owner)
    {
        m_Owner=Owner;
    }
}
