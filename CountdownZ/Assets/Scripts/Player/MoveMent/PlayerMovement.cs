using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputReader m_InputReader;
    [SerializeField] private CharacterController m_Controller;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] private PlayerAnimaction Player_Animator;
     
    private Vector3 currentMoveVelocity;

    [Header("이동/대쉬/점프")]
    [SerializeField]private PlayerMove m_PlayerMove;
    [SerializeField]private PlayerDash m_PlayerDash;
    [SerializeField]private PlayerJump m_PlayerJump;
    private void Awake()
    {
        if (m_Controller == null)
            m_Controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
      //움직임
        m_InputReader.InputActions.Player.Move.performed += m_PlayerMove.OnMove;
        m_InputReader.InputActions.Player.Move.canceled += m_PlayerMove.OnMove;
        //대쉬
        m_InputReader.InputActions.Player.Dash.performed += m_PlayerDash.OnDash;
        m_InputReader.InputActions.Player.Dash.canceled += m_PlayerDash.OnDash;
        //점프
        m_InputReader.InputActions.Player.Jump.performed += m_PlayerJump.OnJump;
    }

    private void OnDisable()
    {
        //점프
        m_InputReader.InputActions.Player.Jump.performed -= m_PlayerJump.OnJump;
        //대쉬
        m_InputReader.InputActions.Player.Dash.canceled -= m_PlayerDash.OnDash;
        m_InputReader.InputActions.Player.Dash.performed -= m_PlayerDash.OnDash;
       
        //움직임
        m_InputReader.InputActions.Player.Move.performed -= m_PlayerMove.OnMove;
        m_InputReader.InputActions.Player.Move.canceled  -= m_PlayerMove.OnMove;
       
    }

    private void Update()
    {
        UpdateGroundStatus();
        UpdateHorizontalMovement();
        UpdateVerticalMovement();
        UpdateDashState();
    } 
    private void UpdateVerticalMovement()
    {
        // --- 3. 수직 이동 및 중력 적용 ---
        m_PlayerJump.velocity.y += m_PlayerJump.gravity * Time.deltaTime;
        m_Controller.Move(m_PlayerJump.velocity * Time.deltaTime);
    }
    private void UpdateGroundStatus()
    {
        // 1. 바닥 체크
        m_PlayerJump.isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // 바닥에 닿으면 수직 속도 초기화
        bool isLanding = m_PlayerJump.isGrounded && m_PlayerJump.velocity.y < 0f;
        if (isLanding)
        {
            m_PlayerJump.velocity.y = -2f;
            m_PlayerJump.isJumping = false;
        }
    }
    private void UpdateDashState()
    {
        m_PlayerMove.isDash = m_PlayerDash.isRunning;
    }
    private void UpdateHorizontalMovement()
    { 
        // --- 2. 수평 이동 (수정됨) ---
        // 땅에 있을 때만 키보드 입력값을 실제 이동할 방향으로 갱신합니다.
        // 공중일 때는 이 if문이 무시되므로, 땅에서 마지막으로 달렸던 방향(currentMoveVelocity)이 유지됩니다.
        bool canUpdateMoveDirection = m_PlayerJump.isGrounded && !m_PlayerJump.isJumping;
        if (canUpdateMoveDirection)
        {
            currentMoveVelocity = m_PlayerDash.isRunning ? (transform.right * m_PlayerMove.moveInput.x + transform.forward * m_PlayerMove.moveInput.y) * 2f :
                                              transform.right * m_PlayerMove.moveInput.x + transform.forward * m_PlayerMove.moveInput.y;
        }
        m_Controller.Move(currentMoveVelocity * 5f * Time.deltaTime);
    }
}