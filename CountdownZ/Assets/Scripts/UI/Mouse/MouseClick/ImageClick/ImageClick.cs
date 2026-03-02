using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageClick : MonoBehaviour,IPointerClickHandler
{
   
    [SerializeField] private UIClickBase m_ClickBase;
    IPointerClickHandler m_PointClick;
    [SerializeField] private UnityEngine.Object[] objects;
    private void Awake()
    {
        //복제(원본 지킴용)
        m_ClickBase = m_ClickBase.Duplicate();

        var data = (m_ClickBase as Iinitialize) ?? new  EmptyInitAction(this);
        data?.Initialize(this, objects);
        m_PointClick = (m_ClickBase as IPointerClickHandler) ?? new EmptyClickAction();
    }

    public void OnPointerClick(PointerEventData eventData)=>
          m_PointClick?.OnPointerClick(eventData);

    private void OnDestroy()
    {
        if (m_ClickBase.IsNotNull())
        {
            Destroy(m_ClickBase);
        }
    }
}
