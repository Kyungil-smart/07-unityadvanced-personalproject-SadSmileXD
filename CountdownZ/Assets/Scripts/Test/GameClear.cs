using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
     public void Clear()
    {
        
        SceneManager.LoadScene("TitleScene");
    }
}
