using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Patrol_Point : MonoBehaviour
{
    [SerializeField]private Transform[] m_PatrolPoints;
    public Transform firstPatrolPoint;
    public Transform  GetRandomPatrolPoint
    {
        get
        {
            return m_PatrolPoints[Random.Range(0, m_PatrolPoints.Length-1)]; 
        }
    }
}
