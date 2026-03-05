using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] private PlayerStatus m_status;
    [SerializeField] private Player_UI m_HP;
    [Header("총알")]
    [SerializeField] private BulletStatus m_bullet;
    [SerializeField] private Player_UI m_Magazine;
    void Awake()
    {
        m_status.OnChangeHealth += m_HP.UpdateUI;
        m_bullet.OnChangeHealth += m_Magazine.UpdateUI;
    }
   

    private void OnDisable()
    {
        m_status.OnChangeHealth -= m_HP.UpdateUI;
        m_bullet.OnChangeHealth -= m_Magazine.UpdateUI;
    }
}
