using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static XNode.Node;
[CreateNodeMenu("ZombieAI/Node/Dead")]
public class Zombie_Dead_Node : BaseNode
{
    public Animator m_animator;
    public override void Initialize(MonoBehaviour Owner, object[] datas)
    {
        foreach (var data in datas)
        {
            if (data is GameObject obj)
            {
                m_animator=obj.GetComponentInChildren<Animator>();
            }
        }
    }
    public override void Enter()
    {
        m_animator.SetTrigger("isDead");
    }
    public override void Update()
    {
         
    }

    public override void Exit()
    {

    }
}
