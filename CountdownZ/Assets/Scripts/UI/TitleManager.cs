using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]private Button StartButton;
    [SerializeField] private Button OpctionButton;
    [SerializeField] private Button ExittButton;
    [SerializeField] private string LoadScene;

    private void Awake()
    {
        StartButton.onClick.AddListener(LoadGameScene);
        OpctionButton.onClick.AddListener(Options);
        ExittButton.onClick.AddListener(QuitGame);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(LoadScene);
    }
    public void Options()
    {

    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        // 1. 유니티 에디터에서 실행 중일 때: 플레이 모드(재생)를 끔
        EditorApplication.isPlaying = false;
#else
            // 2. 실제 빌드된 게임일 때: 어플리케이션 자체를 종료
            Application.Quit();
#endif
    }
}
