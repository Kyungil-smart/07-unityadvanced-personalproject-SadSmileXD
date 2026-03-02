using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
     
    
    [SerializeField] private UIHoverBase m_UIHover;
    [SerializeField] private UnityEngine.Object[] objects;
    private IPointerEnterHandler m_PointEnter; 
    private IPointerExitHandler m_PointExit;
    private void Awake()
    {
        dataReplication();
        Init();
    }

    public void OnPointerEnter(PointerEventData eventData)=>
        m_PointEnter?.OnPointerEnter(eventData);

    public void OnPointerExit(PointerEventData eventData)=>
         m_PointExit?.OnPointerExit(eventData);


    private void dataReplication()=>
        m_UIHover = m_UIHover.Duplicate();

    private void Init()
    {
        m_PointEnter = (m_UIHover as IPointerEnterHandler)?? new EmptyEnterAction(this);
        m_PointExit = (m_UIHover as IPointerExitHandler) ?? new EmptyExitAction(this);
        var data = (m_UIHover as Iinitialize) ?? new EmptyInitAction(this);
        data?.Initialize(this, objects);
    }

    private void OnDestroy()
    {
        if(m_UIHover.IsNotNull())
        {
            Destroy(m_UIHover);
        }
    }
}
