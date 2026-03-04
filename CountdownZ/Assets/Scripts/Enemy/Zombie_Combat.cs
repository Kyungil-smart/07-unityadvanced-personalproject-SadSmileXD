using UnityEngine;

public class ZombieCombat : MonoBehaviour
{
    [SerializeField] private Zombie_AttackFlag m_flag;
    public bool CanDealDamage { get; private set; }

    public void EnableDamage()   // Animation Event
    {
        CanDealDamage = true;
       
    }

    public void DisableDamage()  // Animation Event
    {
        CanDealDamage = false;
       
    }

    public void OnAttack()
    {
        m_flag.OnAttack();
    }
}