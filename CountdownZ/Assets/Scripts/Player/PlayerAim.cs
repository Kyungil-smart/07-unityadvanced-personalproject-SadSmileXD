using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAim : MonoBehaviour
{
    [SerializeField] private PlayerInputReader m_InputSystem;
    [SerializeField]private PlayerAnimaction m_PlayerAnimaction;
    private void OnEnable()
    {
        m_InputSystem.InputActions.Enable();
        m_InputSystem.InputActions.Player.Aim.performed += OnAim;
        m_InputSystem.InputActions.Player.Aim.canceled += OnAim;
        m_InputSystem.InputActions.Player.Shoot.performed += OnShoot;
        m_InputSystem.InputActions.Player.Shoot.canceled += OnShoot;
        m_InputSystem.InputActions.Player.ReLoad.performed += ReLoad;
    }
    private void OnDisable()
    {
        m_InputSystem.InputActions.Player.ReLoad.performed -= ReLoad;
        m_InputSystem.InputActions.Player.Aim.performed -= OnAim;
        m_InputSystem.InputActions.Player.Aim.canceled -= OnAim;
        m_InputSystem.InputActions.Player.Shoot.performed -= OnShoot;
        m_InputSystem.InputActions.Player.Shoot.canceled -= OnShoot;
    
        m_InputSystem.InputActions.Disable();
    }

    private void OnAim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var flag=context.ReadValueAsButton();
            m_PlayerAnimaction.OnAim(flag);
        }
        else if (context.canceled)
        {
            var flag = context.ReadValueAsButton();
            m_PlayerAnimaction.OnAim(flag);
        }
    }
    private void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var flag = context.ReadValueAsButton();
            m_PlayerAnimaction.OnShoot(flag);
        }
        else if (context.canceled)
        {
            var flag = context.ReadValueAsButton();
            m_PlayerAnimaction.OnShoot(flag);
        }
    }
    private void ReLoad(InputAction.CallbackContext context)
    {
        var flag = context.ReadValueAsButton();
        m_PlayerAnimaction.ReLoad();
    }
}
