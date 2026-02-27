using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button m_Button;
    private Vector3 ButtonScale;
    public float scale;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonScale = m_Button.transform.localScale;
        m_Button.transform.localScale = Vector3.one * scale; // 버튼이 커지는 효과
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Button.transform.localScale = ButtonScale;
    }
}
