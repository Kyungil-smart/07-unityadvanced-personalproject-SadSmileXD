using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SoundController : MonoBehaviour
{
    [SerializeField]private AudioSource m_audio;
    IAudioVolumeHandler m_VolumeHandler;
    private void Start()
    {
        m_VolumeHandler = OptctionManager.Instance.GetComponent<IAudioVolumeHandler>();
        m_VolumeHandler.OnValueChanageActions += SetVolume;
    }
    public void SetVolume(float Value)
    {
        m_audio.volume = Value; 
    }

    private void OnDestroy()
    {
        m_VolumeHandler.OnValueChanageActions-= SetVolume;
    }
}
