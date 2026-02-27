using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private bool m_isJumping = false;
    [SerializeField] private bool m_isGrounded = false;
    [SerializeField] private float m_gravity = -9.81f;
    [SerializeField] private float m_JumpHeight = 1.2f;

    public float gravity => m_gravity; 
    public bool isGrounded
    {
        get { return m_isGrounded; }
        set { m_isGrounded = value;}
    }
    public bool isJumping
    {
        get { return m_isJumping; }
        set { m_isJumping = value;}
    }
    public Vector3 velocity;

     
    public event Action OnJumpAnimaction;
    public void OnJump(InputAction.CallbackContext ctx)
    {
        bool CanJump = isGrounded && !isJumping;
        if (CanJump)
        {
            m_isJumping = true;
            OnJumpAnimaction.Invoke();
           
        }
    }
    public void Jump()
    {
        velocity.y = Mathf.Sqrt(m_JumpHeight * -2f * gravity);
    }

    public void Init_Animaction(Action data)
    {
        OnJumpAnimaction=data;
    }

}
