using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Title_scene_GoNextScene", menuName = "Scriptable Objects/UI/ButtonClick/GameStart")]

public class Title_scene_GoNextScene : UIClickBase
{
    MonoBehaviour m_onwer;
    private Button m_Button;
    [SerializeField]private string SceneName;
    public override void Initialize(MonoBehaviour Owner, params object[] datas)
    {
        m_onwer= Owner;

        foreach (var data in datas)
        {
            if(data is Button btn)
            {
                m_Button=btn;
            }
        }

        AddButonAction();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
       
    }


    private void AddButonAction()
    {
        m_Button.onClick.AddListener(GoNextScene);
    }
    private void GoNextScene()
    {
        SceneManager.LoadScene(SceneName);
    }

}
