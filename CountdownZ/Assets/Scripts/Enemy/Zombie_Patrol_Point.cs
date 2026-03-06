using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Patrol_Point : MonoBehaviour
{
    [SerializeField]private List<Transform> m_PatrolPoints=new List<Transform>();
    public Transform firstPatrolPoint;
    public Transform CurrentPos;

    private void Awake()
    {
     
    }
    public Transform  GetRandomPatrolPoint
    {
        get
        {
            CurrentPos = m_PatrolPoints[Random.Range(0, m_PatrolPoints.Count - 1)];
            return CurrentPos;
        }
        set
        {
            m_PatrolPoints.Add(value);
        }
    }
   
}
