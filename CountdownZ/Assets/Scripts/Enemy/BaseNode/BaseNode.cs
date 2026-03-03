using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node,IState
{
    // 각 포트별로 마지막 활성화 시간을 저장하는 딕셔너리
    // 포트 이름을 Key로 사용하여 개별 선의 상태를 관리합니다.
    private Dictionary<string, float> portActiveTimes = new Dictionary<string, float>();


    public     Action<string> OnChanageState;
    public     Action<string, string> OnChanageState2;
    // 특정 포트의 전이를 시작할 때 호출
    public void TriggerTransition(string portName)
    {
        if (portActiveTimes.ContainsKey(portName))
            portActiveTimes[portName] = Time.realtimeSinceStartup;
        else
            portActiveTimes.Add(portName, Time.realtimeSinceStartup);
    }

    // 에디터에서 특정 포트의 활성화 시간을 물어볼 때 사용
    public float GetPortActiveTime(string portName)
    {
        if (portActiveTimes.TryGetValue(portName, out float time))
            return time;
        return -100f;
    }

 
  

    public virtual void Enter()
    {
        
    }

    public virtual void Update()
    {
       
    }

    public virtual void Exit()
    {
       
    }
}