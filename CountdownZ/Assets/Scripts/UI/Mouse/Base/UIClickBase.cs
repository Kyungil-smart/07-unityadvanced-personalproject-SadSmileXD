using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIClickBase : ScriptableObject,IPointerClickHandler
{
    public abstract void Init(MonoBehaviour Owner, params object[] datas);

    public abstract void OnPointerClick(PointerEventData eventData);
     
}
