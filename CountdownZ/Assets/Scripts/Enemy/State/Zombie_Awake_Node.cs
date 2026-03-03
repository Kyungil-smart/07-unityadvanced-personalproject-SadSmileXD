using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
[CreateNodeMenu("ZombieAI/Node/Awake")]
public class Zombie_Awake_Node : BaseNode
{
    [Output(connectionType = ConnectionType.Multiple)] public bool outPort;

 
   
     

    public override void Enter()
    {
        Debug.Log("Awake 진입");
     
       
    }

    public override void Update()
    {
         
    }
    public override void Exit()
    {
         
    }
   
}
