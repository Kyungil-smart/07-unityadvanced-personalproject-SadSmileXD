using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Title_Scene_Opction_GameExit", menuName = "Scriptable Objects/UI/ButtonClick/Options/gameExit")]

public class Title_Scene_GameExit : UIClickBase
{
    private Button m_Button;
    public override void Initialize(MonoBehaviour Owner, params object[] datas)
    {
        foreach(var item in datas)
        {
            if(item is Button btn)
            {
                m_Button=btn;
            }
        }
        ApplyButtonFun();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
       
    }
    private void ApplyButtonFun()
    {
        m_Button.onClick.AddListener(GameExit);
    }
    private void GameExit()
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
