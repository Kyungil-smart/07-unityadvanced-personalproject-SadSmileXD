using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [Header("연결 설정")]
    [SerializeField] private Transform m_PlayerBody;    // Player 최상위 오브젝트
    [SerializeField] private Transform m_CameraTarget;  // Cinemachine Camera 오브젝트
    [SerializeField] private Transform m_SpineBone;     // mixamorig:Spine1 또는 Spine2

    [Header("회전 설정")]
    public float mouseSensitivity = 0.1f;
    public float upperLookLimit = -80f; // 위로 보는 제한
    public float lowerLookLimit = 80f;  // 아래로 보는 제한
    [Range(0, 1)] public float bendIntensity = 0.5f; // 허리 꺾임 강도

    private float m_VerticalRotation = 0f;

    void Start()
    {
        // 마우스 커서 고정
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // 애니메이션이 끝난 후 뼈를 수정해야 하므로 반드시 LateUpdate 사용
    void LateUpdate()
    {
        if (Mouse.current == null) return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue() * mouseSensitivity;

        // 1. 좌우 회전 (몸통 전체를 돌림)
        m_PlayerBody.Rotate(Vector3.up * mouseDelta.x);

        // 2. 상하 회전 (카메라만 돌림)
        m_VerticalRotation -= mouseDelta.y;
        m_VerticalRotation = Mathf.Clamp(m_VerticalRotation, upperLookLimit, lowerLookLimit);
        m_CameraTarget.localRotation = Quaternion.Euler(m_VerticalRotation, 0, 0);

        // 3. 서든어택 식 허리 꺾기 (Aim Offset)
        if (m_SpineBone != null)
        {
            // 카메라가 숙여진 각도만큼 허리 뼈를 로컬 X축으로 꺾어줌
            // 믹사모 리깅 기준: 보통 -m_VerticalRotation * bendIntensity
            m_SpineBone.localRotation = Quaternion.Euler(m_VerticalRotation * bendIntensity, 0, 0);
        }
    }
}