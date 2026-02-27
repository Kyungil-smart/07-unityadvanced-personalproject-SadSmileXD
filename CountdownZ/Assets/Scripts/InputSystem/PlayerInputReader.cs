using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    // 다른 스크립트들이 가져다 쓸 수 있도록 프로퍼티로 열어둡니다.
    // get은 누구나 할 수 있지만, set은 이 스크립트 안에서만 가능하게 막습니다(안전성).
    public InputSystem_Actions InputActions { get; private set; }

    private void Awake()
    {
        // 여기서 딱 한 번만 생성합니다.
        InputActions = new InputSystem_Actions();
    }
    private void OnEnable()
    {
      InputActions.Enable();
    }
    private void OnDisable()
    {
        InputActions.Disable();
    }
}