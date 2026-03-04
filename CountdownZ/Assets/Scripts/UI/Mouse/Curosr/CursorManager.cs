using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    private void Awake()
    {
        base.Awake();
    }
  
    public void OnEnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void OndisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
