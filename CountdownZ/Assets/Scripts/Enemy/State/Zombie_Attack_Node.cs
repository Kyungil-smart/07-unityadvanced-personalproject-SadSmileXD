using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static XNode.Node;
[CreateNodeMenu("ZombieAI/Node/Attack")]
public class Zombie_Attack_Node : BaseNode
{
    public Animator m_animator;
    [Input(connectionType = ConnectionType.Multiple)] public bool inputPort;

    [Output(connectionType = ConnectionType.Multiple)] public bool outPort;

    public Transform m_Target;
    public ZombieSensor m_Sensor;
    private Transform m_Pos;
    private ZombieCombat m_ZombieCombat;
    public float AttackRange;
    public float CoolTime;
    private float lastAttackTime;
    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {
        m_Pos = Owner.transform;

        foreach (var data in datas)
        {
            if(data is GameObject obj)
            {
                obj.TryGetComponent<Animator>(out m_animator);
            }
            else if (data is ZombieSensor ZS)
            {
                m_Sensor = ZS;
            }
        }
    }

    public override void Enter()
    {
        Debug.Log("공격");
        m_animator.SetTrigger("Attack");
        
    }

    public override void Update()
    {
        m_Target = m_Sensor.DetectedTarget;
        var distance = Vector3.Distance(m_Pos.position, m_Target.position);
        if (Mathf.Abs(distance) <= AttackRange)
        {
            if (m_ZombieCombat.CanDealDamage)
            {
                m_animator.SetBool("Attack",true);
              
            }
           
        }
        else
        {
            OnChanageState("outPort");
        }
        
    }
    public override void Exit()
    {
        m_animator.SetBool("Attack", false);
    }
}