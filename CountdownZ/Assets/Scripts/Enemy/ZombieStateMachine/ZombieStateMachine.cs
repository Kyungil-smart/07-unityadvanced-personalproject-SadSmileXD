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
    public BaseNode DeadNode;
    [SerializeField]private Object[] objects;

    [SerializeField] private EnemyStatus m_status;
    /// <summary>
    ///void Awake()
    ///{
    ///    m_status.OnDeath += OnDeath;
    ///    m_RunTimeGraph = Instantiate(m_graph);
    ///     
    ///    InitializeNodes();
    ///    foreach (var node in m_RunTimeGraph.nodes)
    ///    {
    ///        if (node is BaseNode baseNode)
    ///        {
    ///            baseNode.OnChanageState += SetNextState;
    ///            baseNode.OnChanageState2 += SetNextState;
    ///            var init = (node as Iinitialize) ?? new EmptyInitAction(this);
    ///            init.Initialize(this, objects);
    ///        }
    ///    }
    ///}
    /// </summary>
    void Awake()
    {
        if (m_graph == null) return;
        m_status.OnDeath += OnDeath;

        m_RunTimeGraph = Instantiate(m_graph);
        List<XNode.Node> originalNodes = new List<XNode.Node>(m_RunTimeGraph.nodes);
        List<XNode.Node> duplicatedNodes = new List<XNode.Node>();

        for (int i = 0; i < originalNodes.Count; i++)
        {
            XNode.Node newNode = Instantiate(originalNodes[i]);
            newNode.graph = m_RunTimeGraph;

            // 중요: 이름 뒤의 (Clone)을 제거해야 SetNextState에서 이름으로 찾을 때 버그가 안 생깁니다.
            newNode.name = originalNodes[i].name;

            duplicatedNodes.Add(newNode);
        }

        m_RunTimeGraph.nodes = duplicatedNodes;

        foreach (var node in m_RunTimeGraph.nodes)
        {
            foreach (var port in node.Ports)
            {
                port.Redirect(originalNodes, m_RunTimeGraph.nodes);
            }
        }

        InitializeNodes();

        foreach (var node in m_RunTimeGraph.nodes)
        {
            if (node is BaseNode baseNode)
            {
                // 기존 등록된 이벤트가 있을지 모르니 한 번 빼주고 등록 (중복 방지)
                baseNode.OnChanageState -= SetNextState;
                baseNode.OnChanageState2 -= SetNextState;
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
        m_status.OnDeath -= OnDeath;
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
            CurrentState.Enter();
        }
    }
    //public void SetNextState(string portName, string targetNodeName)
    //{
    //    if (CurrentState == null) return;

    //    var port = CurrentState.GetOutputPort(portName);
    //    if (port != null && port.IsConnected)
    //    {
    //        foreach (var connection in port.GetConnections())
    //        {
    //            var nextNode = connection.node as BaseNode;
    //            if (nextNode != null && nextNode.name == targetNodeName)
    //            {
    //                CurrentState.TriggerTransition(targetNodeName);
    //                CurrentState.Exit();
    //                CurrentState = nextNode;
    //                CurrentState.Enter();

    //                return;
    //            }
    //        }
    //        CurrentState?.Exit( );
    //        CurrentState = defaultNode;
    //        CurrentState?.Enter();
    //    }
    //}
    public void SetNextState(string portName, string targetNodeName)
    {
        if (CurrentState == null) return;

        var port = CurrentState.GetOutputPort(portName);
        if (port != null && port.IsConnected)
        {
            foreach (var connection in port.GetConnections())
            {
                var nextNode = connection.node as BaseNode;
                // 이름 비교 시 공백이나 (Clone) 문제 방지를 위해 Equals 사용 권장
                if (nextNode != null && nextNode.name.Equals(targetNodeName))
                {
                    CurrentState.Exit();
                    CurrentState = nextNode;
                    CurrentState.Enter();
                    return;
                }
            }

            // 만약 특정 노드 이름을 찾지 못했다면 기본 노드로 전환 (예비책)
            Debug.LogWarning($"{targetNodeName} 노드를 찾지 못해 기본 노드로 전환합니다.");
            CurrentState.Exit();
            CurrentState = defaultNode;
            CurrentState?.Enter();
        }
    }
    private void InitializeNodes()
    {
        CurrentState = m_RunTimeGraph.nodes.OfType<Zombie_Awake_Node>().FirstOrDefault();
        defaultNode  = m_RunTimeGraph.nodes.OfType<Zombie_Idle_Node>().FirstOrDefault();
        DeadNode= m_RunTimeGraph.nodes.OfType<Zombie_Dead_Node>().FirstOrDefault();
    }

    private void OnDeath()
    {
        CurrentState.Exit();
        CurrentState = DeadNode;
        CurrentState.Enter();
    }
 }
