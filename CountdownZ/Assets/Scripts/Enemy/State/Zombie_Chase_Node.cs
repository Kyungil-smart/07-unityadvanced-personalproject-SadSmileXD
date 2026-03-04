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
    [Input(connectionType = ConnectionType.Multiple)] public bool inputPort;
    [Output(connectionType = ConnectionType.Multiple)] public bool outPort;

    private Transform m_Pos;
    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {
        m_Pos = Owner.transform;
         foreach (var data in datas)
        {
            if(data is GameObject NMA)
            {

                NMA.TryGetComponent<NavMeshAgent>(out m_Agent);
            }
            else if(data is ZombieSensor ZS)
            {
                m_Sensor= ZS;
            }
        }
    }
    public override void Enter()
    {
        Debug.Log("플레이어를 발견하여 추적합니다.");
    }

    public override void Update()
    {
        if(m_Sensor.IsDetected)
        {
            m_Target = m_Sensor.DetectedTarget;
            var distance = Vector3.Distance(m_Pos.position, m_Target.position);
            if (Mathf.Abs(distance) <= 2f)
            {
                m_Agent.ResetPath();
                OnChanageState2("outPort", "Zombie_Attack_");
            }
            m_Agent?.SetDestination(m_Target.position);
           
        }
        else
        {
            OnChanageState2("outPort", "Zombie_Patrol_");
        }
      
    }

    public override void Exit()
    {
         
    }
}
