using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Animaction_Event : MonoBehaviour
{
   [SerializeField]private ZombieStateMachine m_Machine;
    [SerializeField] private string m_NextOutputName;
    public void NextNode()
    {
        m_Machine.SetNextState(m_NextOutputName);
    }
}
