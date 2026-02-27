using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]private bool m_isRunning;
    public bool isRunning=> m_isRunning;
    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            m_isRunning = ctx.ReadValueAsButton();
        }
        else if (ctx.canceled)
        {
            m_isRunning = ctx.ReadValueAsButton();
        }
    }
}
