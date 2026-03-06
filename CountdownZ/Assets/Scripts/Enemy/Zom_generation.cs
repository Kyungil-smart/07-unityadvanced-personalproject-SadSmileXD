using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zom_generation : MonoBehaviour
{
    public GameObject m_generation;
    private WaitForSeconds seconds;
    [SerializeField]private float m_time;
    [SerializeField] private Transform m_startPatrolPoint;
    [SerializeField]private List<Transform> m_endPatrolPoints=new List<Transform>();

     
    void Awake()
    {
        seconds = new WaitForSeconds(m_time);
        StartCoroutine(generation());
    }

    private IEnumerator generation()
    {
        while(true)
        {
            var data=Instantiate(m_generation, this.transform.position, Quaternion.identity);
            var patrol=data.GetComponentInChildren<Zombie_Patrol_Point>();
            patrol.firstPatrolPoint = m_startPatrolPoint;
            foreach (var point in m_endPatrolPoints)
            {
                patrol.GetRandomPatrolPoint=point;
            }
            yield return seconds;
        }
    }
}
