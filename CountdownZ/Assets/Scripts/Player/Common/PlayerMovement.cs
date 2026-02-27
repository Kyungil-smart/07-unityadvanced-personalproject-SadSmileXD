using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private PlayerInputReader m_InputReader;
    [SerializeField] private CharacterController m_Controller;
    [SerializeField] private PlayerStatus m_PlayerStatus;

    [Header("이동 및 점프 설정")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;   // 추가됨: 바닥 판정 반경
    public LayerMask groundMask;          // 추가됨: 바닥으로 인식할 레이어 지정
    [SerializeField] private bool isGrounded;              // 추가됨: 현재 바닥에 닿아있는지 여부

    [SerializeField] private float m_JumpHeight = 1.2f; // 점프 높이(m)   
    public float gravity = -9.81f;        // 추가됨: 중력 가속도
    private Vector3 velocity;             // 추가됨: 수직(Y축) 낙하 속도를 따로 계산할 벡터

    // WASD 값은 Vector2로 받는 것이 표준입니다 (x:좌우, y:앞뒤)
    private Vector2 moveInput;
    [SerializeField] private PlayerAnimaction pa;
    [SerializeField] private bool isRunning;

    private void Awake()
    {
       // m_InputSystem = new InputSystem_Actions();
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
        // --- 1. 바닥 체크 및 중력 속도 초기화 (추가됨) ---
        // groundCheck 위치에 가상의 구를 만들어 groundMask와 충돌하는지 검사합니다.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 바닥에 닿으면 낙하 속도를 초기화 (-2f로 둬서 바닥에 밀착 유지)
        }

        // --- 2. 수평 이동 (기존 코드) ---
        Vector3 move = isRunning ? (transform.right * moveInput.x + transform.forward * moveInput.y) * 2f :
                                   transform.right * moveInput.x + transform.forward * moveInput.y;

        // 수평 이동 적용
        m_Controller.Move(move * 5f * Time.deltaTime);

        // --- 3. 수직 이동 및 중력 적용 (추가됨) ---
        velocity.y += gravity * Time.deltaTime; // 매 프레임 중력 가속도를 더함
        m_Controller.Move(velocity * Time.deltaTime); // 수직 낙하 적용

        // --- 4. 애니메이션 파라미터 전달 (기존 코드) ---
        float x = isRunning ? moveInput.x * 2f : moveInput.x;
        float y = isRunning ? moveInput.y * 2f : moveInput.y;
        pa.SetMove(x, y);
    }

    private void OnMoveInput(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            isRunning = ctx.ReadValueAsButton();
            // Debug.Log("Dash: " + isRunning);
        }
        else if (ctx.canceled)
        {
            isRunning = ctx.ReadValueAsButton();
            // Debug.Log("DashCancel: " + isRunning);
        }
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        // 바닥에 닿아있을 때만 점프 가능하도록 체크
        if (isGrounded)
        {
            // 물리 공식: 속도 = 루트(높이 * -2 * 중력)
            // 설정한 m_JumpHeight(1.2m)만큼 정확히 뛰어오르게 만드는 계산식입니다.
         

            // 만약 점프 애니메이션이 있다면 여기서 트리거를 작동시키면 됩니다.
            // 예: pa.SetJump();
            pa.OnJump();
        }
    }
    public void Jump()
    {
        velocity.y = Mathf.Sqrt(m_JumpHeight * -2f * gravity);
    }
}