using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputReader m_InputReader;
    [SerializeField] private CharacterController m_Controller;
    [SerializeField] private PlayerStatus m_PlayerStatus;

    [Header("이동 및 점프 설정")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] private bool isGrounded;

    [SerializeField] private float m_JumpHeight = 1.2f;
    public float gravity = -9.81f;
    private Vector3 velocity;

    private Vector2 moveInput;
    [SerializeField] private PlayerAnimaction pa;
    [SerializeField] private bool isRunning;

    // --- 추가됨: 땅에서 뛴 방향(관성)을 공중에서도 유지하기 위한 변수 ---
    private Vector3 currentMoveVelocity;
    private bool isJumping = false;
    private void Awake()
    {
        if (m_Controller == null) m_Controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        m_InputReader.InputActions.Player.Move.performed += OnMoveInput;
        m_InputReader.InputActions.Player.Move.canceled += OnMoveInput;
        m_InputReader.InputActions.Player.Dash.performed += OnDash;
        m_InputReader.InputActions.Player.Dash.canceled += OnDash;
        m_InputReader.InputActions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        m_InputReader.InputActions.Player.Jump.performed -= OnJump;
        m_InputReader.InputActions.Player.Dash.canceled -= OnDash;
        m_InputReader.InputActions.Player.Dash.performed -= OnDash;
        m_InputReader.InputActions.Player.Move.performed -= OnMoveInput;
        m_InputReader.InputActions.Player.Move.canceled -= OnMoveInput;
    }

    private void Update()
    {
        // 1. 바닥 체크
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // 바닥에 닿으면 수직 속도 초기화
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isJumping = false;
        }

        // --- 2. 수평 이동 (수정됨) ---
        // 땅에 있을 때만 키보드 입력값을 실제 이동할 방향으로 갱신합니다.
        // 공중일 때는 이 if문이 무시되므로, 땅에서 마지막으로 달렸던 방향(currentMoveVelocity)이 유지됩니다.
        if (isGrounded && !isJumping)
        {
            currentMoveVelocity = isRunning ? (transform.right * moveInput.x + transform.forward * moveInput.y) * 2f :
                                              transform.right * moveInput.x + transform.forward * moveInput.y;
        }

        // 갱신된(혹은 유지된) 방향으로 이동 적용
        m_Controller.Move(currentMoveVelocity * 5f * Time.deltaTime);

        // --- 3. 수직 이동 및 중력 적용 ---
        velocity.y += gravity * Time.deltaTime;
        m_Controller.Move(velocity * Time.deltaTime);

        // --- 4. 애니메이션 파라미터 전달 (수정됨) ---
        // 공중에서는 걷기/뛰기 애니메이션이 재생되지 않도록 파라미터를 0으로 줍니다.
        float x = isGrounded ? (isRunning ? moveInput.x * 2f : moveInput.x) : 0f;
        float y = isGrounded ? (isRunning ? moveInput.y * 2f : moveInput.y) : 0f;
        pa.SetMove(x, y);
    }

    private void OnMoveInput(InputAction.CallbackContext ctx)
    {
        // 최신 입력값은 무조건 받아서 저장만 해둡니다. (키 씹힘 방지)
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            isRunning = ctx.ReadValueAsButton();
        }
        else if (ctx.canceled)
        {
            isRunning = ctx.ReadValueAsButton();
        }
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (isGrounded && !isJumping)
        {
            isJumping = true;
            pa.OnJump();
        }
    }
    public void Jump()
    {
        velocity.y = Mathf.Sqrt(m_JumpHeight * -2f * gravity);
    }
}