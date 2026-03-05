using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private PlayerInputReader m_InputSystem;
    [SerializeField] private PlayerAnimaction m_PlayerAnimaction;
    [SerializeField] private GameObject CrossObj;
    [SerializeField] private LayerMask m_LayerMask;

    [Header("사격 설정")]
  
    [SerializeField] private float m_FireRate = 0.1f;
    [SerializeField] private float m_Damage = 10f;
    [SerializeField] private GameObject m_zomcam;
    private bool m_IsShooting; // shootflag 이름 변경
    private float m_LastShootTime = 0f; // 마지막으로 총을 쏜 시간을 기억할 변수
    bool flag ;

    public BulletStatus m_bst;
    [SerializeField] private AudioSource AudioSource;
    private void Awake()
    {
        flag = false;
        m_InputSystem ??= PlayerInputReader.Instance;
    }

    private void OnEnable()
    {
       
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
    }

    private void Update()
    {
        // 1. 마우스를 누르고 있는 상태인가?
        // 2. 현재 시간이 '마지막으로 쏜 시간 + 쿨타임'을 지났는가?
        if (m_IsShooting && Time.time >= m_LastShootTime + m_FireRate)
        {
            // 쿨타임 초기화
            m_LastShootTime = Time.time;

            // 실제 사격 로직 호출
            PerformRaycastShoot();
        }
    }

    private void PerformRaycastShoot()
    {
        if (!m_bst.CanShoot) return;
        m_bst.OnShoot();
        AudioSource.Play();
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // 디버그 레이가 너무 빨리 사라져서 안 보일까 봐 1초간 유지되도록(시간 매개변수) 추가했습니다.
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, m_LayerMask))
        {
            // [중요 최적화] TryGetComponent를 사용하여 에러 방지
            // 맞은 오브젝트에 IDamage 인터페이스가 없다면 쿨하게 무시합니다.
            var damage = hit.transform.gameObject.GetComponentInChildren<IDamage>();
            damage?.OnDamage(m_Damage);
        }
    }

    // --- 아래는 이전 답변에서 알려드렸던 최적화된(if문 없는) 인풋 로직 적용 ---
    private void OnAim(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            m_zomcam.SetActive(true);
        }
        else if(context.canceled)
        {
            m_zomcam.SetActive(false);
        }
        bool isAiming = context.ReadValueAsButton();
        m_PlayerAnimaction.OnAim(isAiming);
        CrossObj.SetActive(isAiming);
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (!m_bst.CanShoot) return;
        
       
        m_IsShooting = context.ReadValueAsButton();
        m_PlayerAnimaction.OnShoot(m_IsShooting);
    }

    private void ReLoad(InputAction.CallbackContext context)
    {
        m_PlayerAnimaction.ReLoad();
    }
  
     
}