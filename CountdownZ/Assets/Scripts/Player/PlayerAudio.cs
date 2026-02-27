using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("사용할 오디오 소스")][SerializeField]private AudioSource m_AudioSource;
    [Header("사용할 오디오 클립들")][SerializeField] private AudioClip[] m_clips;
    public void OnPlay()
    {
        if(m_AudioSource.IsNotNull())
        {
            var index = Random.Range(0, m_clips.Length);
            m_AudioSource.clip = m_clips[index];
            m_AudioSource.Play();
        }
    }
    
}
