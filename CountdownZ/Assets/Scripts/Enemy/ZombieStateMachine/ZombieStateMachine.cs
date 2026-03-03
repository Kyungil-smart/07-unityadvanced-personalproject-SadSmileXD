using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.UI.Image;

public class ZombieStateMachine : MonoBehaviour
{
    [SerializeField]private  ZombieGraph m_graph;
    [SerializeField] private ZombieGraph m_RunTimeGraph;
    public BaseNode CurrentState;
    public BaseNode defaultNode;
    [SerializeField]private Object[] objects;
    void Awake()
    {
        m_RunTimeGraph= m_graph.Duplicate();
        InitializeNodes();
        foreach (var node in m_RunTimeGraph.nodes)
        {
            if (node is BaseNode baseNode)
            {
                baseNode.OnChanageState += SetNextState;
                baseNode.OnChanageState2 += SetNextState;
                var init = (node as Iinitialize) ?? new EmptyInitAction(this);
                init.Initialize(this, objects);
            }
        }
    }
    private void OnEnable()
    {
        CurrentState.Enter();
    }
    private void OnDisable()
    {
        foreach (var node in m_RunTimeGraph.nodes)
        {
            if (node is BaseNode baseNode)
            {
                baseNode.OnChanageState -= SetNextState;
                baseNode.OnChanageState2 -= SetNextState;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CurrentState?.Update();
         
    }

    public void SetNextState(string portName)
    {
        var port = CurrentState.GetOutputPort(portName);
        if (port != null && port.IsConnected)//값을 가지고 있으면 
        {
            CurrentState.TriggerTransition(portName);
            CurrentState.Exit();
            CurrentState = port.Connection.node as BaseNode;
            CurrentState?.Enter();
        }
    }
    public void SetNextState(string portName, string targetNodeName)
    {
        if (CurrentState == null) return;

        var port = CurrentState.GetOutputPort(portName);
        if (port != null && port.IsConnected)
        {
            foreach (var connection in port.GetConnections())
            {
                var nextNode = connection.node as BaseNode;
                if (nextNode != null && nextNode.name == targetNodeName)
                {
                    CurrentState.TriggerTransition(targetNodeName);
                    CurrentState.Exit();
                    CurrentState = nextNode;
                    CurrentState.Enter();
                   
                    return;
                }
            }
            CurrentState?.Exit( );
            CurrentState = defaultNode;
            CurrentState?.Enter();
        }
    }

    private void InitializeNodes()
    {
        CurrentState = m_RunTimeGraph.nodes.OfType<Zombie_Awake_Node>().FirstOrDefault();
        defaultNode  = m_RunTimeGraph.nodes.OfType<Zombie_Idle_Node>().FirstOrDefault();
    }
 }
