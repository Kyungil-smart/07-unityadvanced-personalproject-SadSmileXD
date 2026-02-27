using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIClick : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]private GameObject Object;
    [SerializeField] private UIClickBase Click;
    private void Awake()
    {
        Click.Init(this, Object);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Click.OnPointerClick(eventData);
    }
}
