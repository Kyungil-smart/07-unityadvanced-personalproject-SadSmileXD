using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouseLook : MonoBehaviour
{
    [Header("회전 속도 설정")]
    [SerializeField] private float m_MouseSensitivity = 0.1f;

    [Header("카메라 타겟 연결")]
    [Tooltip("플레이어의 자식으로 만든 빈 오브젝트(CameraTarget)를 넣으세요.")]
    [SerializeField] private Transform m_CameraTarget; // 여기 이름이 바뀌었습니다!

    [SerializeField] private PlayerInputReader m_InputSystem;

    private float m_XRotation = 0f;

    private void Awake()
    {
        m_InputSystem ??= PlayerInputReader.Instance;
    }

    private void Start()
    {
        CursorManager.Instance.OndisableCursor();
    }

    private void Update()
    {
        Vector2 lookInput = m_InputSystem.InputActions.Player.Look.ReadValue<Vector2>();

        float mouseX = lookInput.x * m_MouseSensitivity;
        float mouseY = lookInput.y * m_MouseSensitivity;

        // 1. 카메라 타겟 상하(위아래) 회전 처리
        m_XRotation -= mouseY;
        m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);

        // 메인 카메라가 아니라, '카메라 타겟(빈 오브젝트)'의 고개를 꺾어줍니다!
        m_CameraTarget.localRotation = Quaternion.Euler(m_XRotation, 0f, 0f);

        // 2. 플레이어 좌우 회전 처리 (몸통 회전)
        transform.Rotate(Vector3.up * mouseX);
    }
}