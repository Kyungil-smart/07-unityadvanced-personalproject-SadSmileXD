using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
     
    [SerializeField] private PlayerStatus m_Status;
    [SerializeField] private Vector2 m_moveInput;
    private bool m_isDash;
    public bool isDash
    {
        get => m_isDash;
        set
        {
            if (m_isDash == value) return; // 값이 같으면 무시
            m_isDash = value;
            UpdateMoveState(); // 상태 변경 시 호출
        }
    }
    public Vector2 moveInput
    {
        get { return m_moveInput; }
        set { m_moveInput=value;  }
    }
    private Vector2  m_moveInputInt;
    public event Action<Vector2> OnMoveInputChanged;

    private void Awake()
    {
        m_moveInput = new Vector2();
        OnMoveInputChanged?.Invoke(m_moveInput);
    }

    
    public void OnMove(InputAction.CallbackContext ctx)
    {
        m_moveInput = ctx.ReadValue<Vector2>();
        m_moveInputInt = isDash? m_moveInput*2f : m_moveInput;

        UpdateMoveState();
    }

    private void UpdateMoveState()
    {
        // 걷기(1배), 대쉬(2배) 계산
        Vector2 finalInput = isDash ? m_moveInput * 2f : m_moveInput;

        // 값이 바뀔 때만 "딱 한 번" 알림
        OnMoveInputChanged?.Invoke(finalInput);
    }
}
