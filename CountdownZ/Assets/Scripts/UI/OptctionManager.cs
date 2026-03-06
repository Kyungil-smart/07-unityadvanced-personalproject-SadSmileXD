using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptctionManager : Singleton<OptctionManager>,IAudioVolumeHandler
{
    public event Action<float> OnValueChanageActions;
    [SerializeField] private Scrollbar m_slider;
    private float m_volume;
    [SerializeField]
    public float volume
    {
        get => m_volume;
        set
        {
            m_volume = value;
            OnValueChanageActions?.Invoke(m_volume);
        }
    }
    private void Awake()
    {
        Time.timeScale = 1f;
        base.Awake();
        m_slider.value = 0.5f;
        volume = m_slider.value;
        m_slider.onValueChanged.AddListener(val => volume = val);
       
    }
    public void OnEnable()
    {
        var flag = (SceneManager.GetActiveScene().name) == "TitleScene";
        if (flag == false)
        {
            CursorManager.Instance.OnEnableCursor();
        }
     
         SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnDisable()
    {
        var flag = (SceneManager.GetActiveScene().name) == "TitleScene";
        if (flag == false)
        {
            CursorManager.Instance.OndisableCursor();

            
        }
      
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      
        this.gameObject.SetActive(false);
    }
}
