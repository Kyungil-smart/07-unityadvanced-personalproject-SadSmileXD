using UnityEngine;
using UnityEngine.InputSystem;
 
public class PlayerMovement : MonoBehaviour
{
    private InputSystem_Actions m_InputSystem;
    [SerializeField] private CharacterController m_Controller;
    [SerializeField]private PlayerStatus m_PlayerStatus;
    [Header("이동 설정")]
    [SerializeField] private float m_Gravity = -15f;
    private bool m_IsGrounded;
    private Vector3 m_Velocity;
    // WASD 값은 Vector2로 받는 것이 표준입니다 (x:좌우, y:앞뒤)
    private Vector2 moveInput;
    [SerializeField] private float m_JumpHeight = 1.2f; // 점프 높이(m)   
    [SerializeField] private PlayerAnimaction pa;
    private void Awake()
    {
        m_InputSystem = new InputSystem_Actions();
        if (m_Controller == null) m_Controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        m_InputSystem.Enable();
        m_InputSystem.Player.Move.performed += OnMoveInput;
        m_InputSystem.Player.Move.canceled += OnMoveInput;

        //m_InputSystem.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        //m_InputSystem.Player.Jump.performed -= OnJump;
        m_InputSystem.Player.Move.performed -= OnMoveInput;
        m_InputSystem.Player.Move.canceled -= OnMoveInput;
        m_InputSystem.Disable();
    }

    private void Update()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        m_Controller.Move(move * 5f * Time.deltaTime);
        pa.SetMove(moveInput.x, moveInput.y);
    }

 
    private void OnMoveInput(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
}
