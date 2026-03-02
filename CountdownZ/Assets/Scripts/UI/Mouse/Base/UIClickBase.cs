using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIClickBase : ScriptableObject,IPointerClickHandler,Iinitialize
{
    public abstract void Initialize(MonoBehaviour Owner, params object[] datas);

    public abstract void OnPointerClick(PointerEventData eventData);
     
}
