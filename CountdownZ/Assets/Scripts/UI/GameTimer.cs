using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public event Action<string> OnChanageTime;
    [SerializeField] private float m_currentTime;

   
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

    }
}
