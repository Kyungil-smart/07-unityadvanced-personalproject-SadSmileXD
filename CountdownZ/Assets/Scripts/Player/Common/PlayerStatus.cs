using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour,IDamage,IHealable
{
    [SerializeField]private PlayerStatusData m_PlayerStatusData;
#region 플레이어 정보
    [SerializeField]private string m_PlayerName;
    [SerializeField]private float m_Health;
    [SerializeField]private float m_Speed;
#endregion
     public string PlayerName => m_PlayerName;
     public float Health => m_Health;
     public float Speed => m_Speed;

    public bool IsDead => m_Health <= 0;
    void Awake()
    {
        Init_Player_Status();
    }

    //플레이어 Status 초기화 함수
    private void Init_Player_Status()
    {
        
        m_PlayerName = m_PlayerStatusData.PlayerName;
        m_Health = m_PlayerStatusData.Health;
        m_Speed = m_PlayerStatusData.Speed;
    }

    //데미 받는 인터페이스 함수
    public void OnDamage(float damage) => m_Health -= damage;
    //힐 받는 인터페이스 함수
    public void OnHeal(float heal) => m_Health += heal;

}
