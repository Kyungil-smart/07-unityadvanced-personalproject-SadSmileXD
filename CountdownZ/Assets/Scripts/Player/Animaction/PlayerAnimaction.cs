using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimaction : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private PlayerMovement player;

    public void UpdateWalkAnimation(Vector2 input)
    {
        // 애니메이션에 대한 책임은 오직 여기에만 있음
        m_animator.SetFloat("XDir", input.x);
        m_animator.SetFloat("YDir", input.y);
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
    public void SetTrigger(string parameters)=>
      m_animator.SetTrigger(parameters);

    public void SetBool(string parameters,bool flag)=>
                m_animator.SetBool(parameters,flag);
    public void SetFloat(string parameters, float Value)=>
                m_animator.SetFloat(parameters, Value);

}
