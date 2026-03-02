using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Title_Scene_UI_Hover_", menuName = "Scriptable Objects/UI/ButtonHover")]
public class Title_Scene_UI_Hover : UIHoverBase
{
    public MonoBehaviour Onwer;
    public Button m_Button;
    public Vector3 ButtonScale;
    public float scale;
    override public void Initialize(MonoBehaviour Owner, params object[] datas)
    {
        // 초기화 로직이 필요한 경우 여기에 작성
        Onwer= Owner;
        foreach (var data in datas)
        {
            if(data is Button button)
            {
                m_Button= button;
            }
        }
    }

    override public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        // 마우스가 UI 요소 위에 올라갔을 때의 행동을 정의
        ButtonScale = m_Button.transform.localScale;
        m_Button.transform.localScale = Vector3.one * scale; // 버튼이 커지는 효과
    }

    override public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        // 마우스가 UI 요소에서 벗어났을 때의 행동을 정의
        m_Button.transform.localScale = ButtonScale;
    }
}
