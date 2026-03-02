using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.GridLayoutGroup;
[CreateAssetMenu(fileName = "Title_Scene_OnButtonClick", menuName = "Scriptable Objects/UI/ButtonClick/Exit")]
public class Title_Scene_OnClick_Exit : UIClickBase
{
    private MonoBehaviour OWner;
    private Button m_Button;
    public override void Initialize(MonoBehaviour Owner, params object[] datas)
    {
        this.OWner = OWner;
        foreach (var data in datas)
        {
            if(data  is Button btn)
            {
                m_Button=btn;
            }
        }

        BindEvents();   
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
         
    }
    private void BindEvents()
    {
        if(m_Button.IsNotNull())
        {
            m_Button.onClick.AddListener(ClickAction);
        }
        else
        {
            Debug.Log($"{OWner} : 버튼 데이터 초기화 실패");
        }
        
    }

    private void ClickAction()
    {
        // 1. 유니티 에디터에서 실행 중일 때
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        // 2. 실제 빌드된 게임(PC, 모바일 등)에서 실행 중일 때
#else
            Application.Quit();
#endif
    }

}
