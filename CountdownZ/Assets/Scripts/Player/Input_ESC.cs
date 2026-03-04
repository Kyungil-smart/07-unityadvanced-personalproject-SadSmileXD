using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_ESC : MonoBehaviour
{
    private  PlayerInputReader m_input;
    [SerializeField] private GameObject canvasobj;
   
    private void OnEnable()
    {
       
        m_input = PlayerInputReader.Instance;
     
    }
    private void Start()
    {
        m_input.InputActions.Player.ESC.performed += OnCanvasActive;
    }
    private void OnDisable()
    {
        m_input.InputActions.Player.ESC.performed -= OnCanvasActive;
    }

    private void OnCanvasActive(InputAction.CallbackContext ctx)
    {
        
        var flag = canvasobj.activeSelf;
        canvasobj.SetActive(!flag);
    }
}
