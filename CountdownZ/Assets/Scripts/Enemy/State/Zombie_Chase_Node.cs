using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static XNode.Node;
[CreateNodeMenu("ZombieAI/Node/Chase")]
public class Zombie_Chase_Node : BaseNode
{
    public NavMeshAgent m_Agent;

    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {
         
    }
    public override void Enter()
    {
         
    }

    public override void Update()
    {
       // m_Agent?.destination();
    }

    public override void Exit()
    {
         
    }
}
