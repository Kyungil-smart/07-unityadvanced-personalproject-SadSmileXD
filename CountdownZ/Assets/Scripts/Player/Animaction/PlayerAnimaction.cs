using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimaction : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private PlayerMovement player;

    
    public void SetMove(float x,float y)
    {
        m_animator.SetFloat("XDir", x);
        m_animator.SetFloat("YDir", y);
    }

    public void OnJump( )
    {
        m_animator.SetTrigger("OnJump");
    }
    public void OnAim(bool flag)
    {
        m_animator.SetBool("IsAiming", flag);
    }
    public void OnShoot(bool flag)
    {
        m_animator.SetBool("IsShooting", flag);
    }
    public void ReLoad()
    {
        m_animator.SetTrigger("ReLoad");
    }
}
