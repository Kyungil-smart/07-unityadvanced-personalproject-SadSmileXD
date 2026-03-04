using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
[CreateNodeMenu("ZombieAI/Node/Awake")]
public class Zombie_Awake_Node : BaseNode
{
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
