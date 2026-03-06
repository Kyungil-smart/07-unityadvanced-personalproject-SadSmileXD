using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public event Action<string> OnChanageTime;
    [SerializeField] private float m_currentTime;
    [SerializeField]private GameObject m_gameObject;
    [SerializeField] private GameObject canvas;
    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while(m_currentTime > 0)
        {
            int minutes = Mathf.FloorToInt(m_currentTime / 60);
            int seconds = Mathf.FloorToInt(m_currentTime % 60);
            string formatted = string.Format("{0:00}:{1:00}", minutes, seconds);
            OnChanageTime.Invoke(formatted);
            yield return null;
         
            m_currentTime-=Time.deltaTime;
        }
        Time.timeScale = 0f;
        CursorManager.Instance.OnEnableCursor();
        canvas.SetActive(false);
        m_gameObject.SetActive(true);
    }
}
