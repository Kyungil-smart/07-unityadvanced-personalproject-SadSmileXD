using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateNodeMenu("ZombieAI/Node/Patrol")]
public class Zombie_Patrol_Node : BaseNode
{
    public NavMeshAgent m_agent;
    public Zombie_Patrol_Point m_PatrolPoint;
    public Transform m_CurrentPatrolPoint;
    public float StopDistance;
    [Input(connectionType = ConnectionType.Multiple)] public bool inputPort;

    [Output(connectionType = ConnectionType.Multiple)] public bool outPort;


    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {
        foreach (var data in datas)
        {
            if(data is GameObject isNavMesh)
            {
                isNavMesh.TryGetComponent<NavMeshAgent>(out m_agent);
                Debug.Log("찾음");
            }

            if(data is Zombie_Patrol_Point ZPP)
            {
                m_PatrolPoint = ZPP;
                Debug.Log("Zombie_Patrol_Point찾음");
            }
        }
    }
    public override void Enter()
    {
        bool flag = m_CurrentPatrolPoint.IsNotNull();
        if (flag==false)
        {
            m_CurrentPatrolPoint = m_PatrolPoint.firstPatrolPoint;

        }
        m_agent?.SetDestination(m_CurrentPatrolPoint.position);
    }

    public override void Update()
    {
        var distance = Vector3.Distance(m_agent.gameObject.transform.position, m_CurrentPatrolPoint.position);
     
        if (Mathf.Abs(distance) < StopDistance)
        {
            m_agent.ResetPath();
            m_CurrentPatrolPoint = m_PatrolPoint.GetRandomPatrolPoint;
            m_agent?.SetDestination(m_CurrentPatrolPoint.position);
            Debug.Log("탐색종료");
        }
        else
        {
       
            Debug.Log($"거림 {distance}");
           
        }
       
    }

    public override void Exit()
    {
         
    }
}
