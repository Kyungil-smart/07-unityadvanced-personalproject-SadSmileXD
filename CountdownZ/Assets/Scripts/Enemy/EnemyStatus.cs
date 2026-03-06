using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStatus : MonoBehaviour,IDamage
{
    [SerializeField]private float m_hp;
    [SerializeField]private float MaxHp;
    public event Action OnDeath;
    public bool isDeath;
     
    public float hp
    {
        get => m_hp;
        set
        {
            m_hp = Mathf.Clamp(value, 0, MaxHp);
            if(m_hp<=0)
            {
                isDeath = true;
                
                OnDeath.Invoke();
            }
            else
            {
                isDeath=false;
            }
        }
    }
    public void OnDamage(float damage)
    {
        if (isDeath) return;
        hp -= damage;
        Debug.Log($"enemy hp : {hp}");
    }
}
