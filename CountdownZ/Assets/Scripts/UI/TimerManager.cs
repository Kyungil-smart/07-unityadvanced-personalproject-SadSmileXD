using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Player_UI m_timerui;
    [SerializeField] private GameTimer m_timer;
    private void Awake()
    {
        m_timer.OnChanageTime += m_timerui.UpdateUI;
    }
    public void OnDisable()
    {
        m_timer.OnChanageTime -= m_timerui.UpdateUI;
    }

}
