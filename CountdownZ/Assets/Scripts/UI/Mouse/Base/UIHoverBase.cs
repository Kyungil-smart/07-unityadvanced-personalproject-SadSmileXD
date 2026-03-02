using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIHoverBase : ScriptableObject, IPointerEnterHandler, IPointerExitHandler,Iinitialize
{
    /*
     마우스가 UI 요소 위에 올라갔을 때와 벗어났을 때의 행동을 정의하는 추상 클래스
     */
    public abstract void Initialize(MonoBehaviour Owner, params object[] datas);
     public abstract void OnPointerEnter(PointerEventData eventData);
     public abstract void OnPointerExit(PointerEventData eventData);
}
