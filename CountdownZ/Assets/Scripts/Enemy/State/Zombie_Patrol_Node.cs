using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.GridLayoutGroup;
[CreateNodeMenu("ZombieAI/Node/Patrol")]
public class Zombie_Patrol_Node : BaseNode
{
    public NavMeshAgent m_agent;
    public Zombie_Patrol_Point m_PatrolPoint;
    public Transform m_CurrentPatrolPoint;
     
    public float StopDistance;
    public Animator m_animator;
    [Input(connectionType = ConnectionType.Multiple)] public bool inputPort;

    [Output(connectionType = ConnectionType.Multiple)] public bool outPort;
    
    [Header("순찰 속도")]public float moveSpeed; 
    public float viewDistance = 15f;    // 감지 거리
    public float viewAngle = 110f;     // 시야각 (좌우 합산)
    public LayerMask targetMask;        // 플레이어 레이어
    public ZombieSensor m_Sensor;
    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {
      
        foreach (var data in datas)
        {
            if(data is GameObject OBJ)
            {
                OBJ.TryGetComponent<NavMeshAgent>(out m_agent);
               
                OBJ.TryGetComponent<Animator>(out m_animator);
            }

            if(data is Zombie_Patrol_Point ZPP)
            {
                m_PatrolPoint = ZPP;
                
            }

            if(data is ZombieSensor Sensor)
            {
                m_Sensor=Sensor;
            }
        }
    }
    public override void Enter()
    {
        m_animator.SetBool("Walk", true);
        m_agent.speed = moveSpeed;
        bool flag = m_CurrentPatrolPoint.IsNotNull();
        if (flag==false)
        {
           // m_CurrentPatrolPoint = m_PatrolPoint.firstPatrolPoint;

        }
        else
        {
            m_agent?.SetDestination(m_PatrolPoint.CurrentPos.position);
        }
        //m_agent?.SetDestination(m_PatrolPoint.CurrentPos.position);
    }

    public override void Update()
    {
        if(m_CurrentPatrolPoint ==null)
        {
            m_CurrentPatrolPoint = m_PatrolPoint.GetRandomPatrolPoint;
            m_agent?.SetDestination(m_PatrolPoint.CurrentPos.position);
            return;
        }
         if (m_Sensor.IsDetected)
         {
          
            OnChanageState2("outPort", "Zombie_Chase_");
         }
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
        
           
           
        }
      
    }

    public override void Exit()
    {
        m_animator.SetBool("Walk", false);
        m_agent.ResetPath();
    }
    
}
