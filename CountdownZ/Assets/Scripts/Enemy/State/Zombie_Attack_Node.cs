using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static XNode.Node;
[CreateNodeMenu("ZombieAI/Node/Attack")]
public class Zombie_Attack_Node : BaseNode
{
    [Input(connectionType = ConnectionType.Multiple)] public bool inputPort;

    [Output(connectionType = ConnectionType.Multiple)] public bool outPort;
    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {
         
    }

    public override void Enter()
    {
        Debug.Log("공격");
        OnChanageState("outPort");
    }

    public override void Update()
    {
         
    }
    public override void Exit()
    {

    }
}