using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimactionEvent : MonoBehaviour
{
     
    [SerializeField] PlayerAudio m_Audio;
    [SerializeField]private PlayerJump m_Jump;
    public void Jump()
    {
        m_Jump.Jump();
    }
    public void MoveSound()
    {
        m_Audio.OnPlay();
    }
   
}
