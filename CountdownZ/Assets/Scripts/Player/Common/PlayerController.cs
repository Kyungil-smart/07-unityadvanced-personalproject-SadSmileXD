using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private PlayerJump m_PlayerJump;
    [SerializeField]private PlayerMove m_PlayerMove;
    [SerializeField]private PlayerAnimaction m_playerAnimaction;

    public void Awake()
    {
        m_PlayerMove.OnMoveInputChanged += m_playerAnimaction.UpdateWalkAnimation;
        m_PlayerJump.Init_Animaction(m_playerAnimaction.OnJump);
    }
    public void OnEnable()
    {
        
    }
    public void OnDisable()
    {

    }
}
