using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateNodeMenu("ZombieAI/Node/idle")]
public class Zombie_Idle_Node : BaseNode
{
    [Input(connectionType = ConnectionType.Multiple)] public bool inputPort;
    [Output(connectionType = ConnectionType.Multiple)] public bool outPort;
    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {

    }
    public override void Enter()
    {
       
        OnChanageState("outPort");
    }

    public override void Update()
    {

    }
    public override void Exit()
    {

    }
}
