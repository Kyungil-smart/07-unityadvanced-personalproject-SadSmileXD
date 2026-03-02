using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    
    [SerializeField] private UIClickBase m_ClickBase;
    [SerializeField] private UnityEngine.Object[] objects;
    private void Awake()
    {
        //복제(원본 지킴용)
        m_ClickBase = m_ClickBase.Duplicate();

        var data= (m_ClickBase as Iinitialize)?? new EmptyInitAction(this);
        data.Initialize(this, objects);
    }
}
