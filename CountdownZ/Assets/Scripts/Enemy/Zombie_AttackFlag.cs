using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AttackFlag : MonoBehaviour
{
  
    [SerializeField] private int damage = 10;
    [SerializeField] private float radius;
    

    [SerializeField] private LayerMask targetLayer;
    private Collider[] results = new Collider[1]; // 최대 10명 맞는다고 가정
    public void OnAttack()
    {
        Vector3 origin = transform.position ;

        int hitCount = Physics.OverlapSphereNonAlloc(
            origin,
            radius,
            results,
            targetLayer
        );

        for (int i = 0; i < hitCount; i++)
        {
            Collider hit = results[i];

            if (hit == null) continue;

            var damageTarget = hit.GetComponentInChildren<IDamage>();
            if (damageTarget != null)
            {
                damageTarget.OnDamage(damage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 origin = transform.position;
        Gizmos.DrawWireSphere(origin, radius);
    }
}
