using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStatus : MonoBehaviour,IDamage
{
    public float hp;
    
    public void OnDamage(float damage)
    {
        hp -= damage;
        Debug.Log($"enemy hp : {hp}");
    }
}
