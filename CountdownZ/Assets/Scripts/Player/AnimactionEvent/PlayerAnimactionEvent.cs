using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimactionEvent : MonoBehaviour
{
    [SerializeField]PlayerMovement m_movement;
   
    public void Jump()
    {
        m_movement.Jump();
    }
}
