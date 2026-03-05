using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static XNode.Node;
[CreateNodeMenu("ZombieAI/Node/Chase")]
public class Zombie_Chase_Node : BaseNode
{
    public NavMeshAgent m_Agent;
    public Transform m_Target;
    public ZombieSensor m_Sensor;
    public Animator m_Animator;
    [Input(connectionType = ConnectionType.Multiple)] public bool inputPort;
    [Output(connectionType = ConnectionType.Multiple)] public bool outPort;

    public float ChanageDistance;
    private Transform m_Pos;
    [Header("순찰 속도")] public float moveSpeed;
    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {
        m_Pos = Owner.transform;
         foreach (var data in datas)
        {
            if(data is GameObject NMA)
            {
                NMA.TryGetComponent<NavMeshAgent>(out m_Agent);
                NMA.TryGetComponent<Animator>(out m_Animator);
            }
            else if(data is ZombieSensor ZS)
            {
                m_Sensor= ZS;
            }
          
        }
    }
    public override void Enter()
    {
        m_Agent.speed = moveSpeed;
        m_Animator.SetBool("Run", true);
      
    }

    public override void Update()
    {
        if(m_Sensor.IsDetected)
        {
            m_Target = m_Sensor.DetectedTarget;
            var distance = Vector3.Distance(m_Pos.position, m_Target.position);
            if (Mathf.Abs(distance) <= ChanageDistance)
            {
             
                OnChanageState2("outPort", "Zombie_Attack_");
                return;
            }
            m_Agent?.SetDestination(m_Target.position);
           
        }
        else
        {
            m_Animator.SetBool("Run", false);
            OnChanageState2("outPort", "Zombie_Patrol_");
        }
      
    }

    public override void Exit()
    {
        
        m_Agent.ResetPath();
    }
}
