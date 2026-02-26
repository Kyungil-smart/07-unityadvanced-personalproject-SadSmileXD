using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "PlayerStatus_", menuName = "Scriptable Objects/PlayerStatus")]
public   class PlayerStatusData : ScriptableObject
{
    [SerializeField]private string m_PlayerName;
    [SerializeField]private float m_Health;
    [SerializeField]private float m_Speed;

     public string PlayerName => m_PlayerName;
     public float Health => m_Health;
     public float Speed => m_Speed;

    
}
