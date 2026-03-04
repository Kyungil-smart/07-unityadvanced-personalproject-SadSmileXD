using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Title_Scene_Options_Click", menuName = "Scriptable Objects/UI/ButtonClick/Opction")]

public class Title_Scene_Options_Click : UIClickBase
{
    private MonoBehaviour m_Owner;
    private GameObject m_canvasobject;
 
    private Button m_button;
    public override void Initialize(MonoBehaviour Owner, params object[] datas)
    {
        m_Owner = Owner;
        foreach (var data in datas)
        {
             if(data is GameObject obj)
            {
                m_canvasobject = obj;
            }
             if(data is Button btn)
            {
                m_button = btn;
            }
        }
        BindingAction();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        
    }
    private void BindingAction()
    {
        if(m_button.IsNotNull())
        {
            m_button.onClick.AddListener(ButtonAction);
        }
        else
        {
            Debug.Log($"{m_Owner}: m_button 확인 바람 ");
        }
    }
    private void ButtonAction()
    {
        
        var flgs = m_canvasobject.activeSelf;
        m_canvasobject.SetActive(!flgs);
    }
}
