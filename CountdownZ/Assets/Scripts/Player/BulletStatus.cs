using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatus : MonoBehaviour
{
    public int m_CurrentMagazine;

    public  const int MAXBULLETS = 200;
    public int CurrentMagazine
    {
        get => m_CurrentMagazine;
        set
        {
            m_CurrentMagazine = Mathf.Clamp(value,0, MAXBULLETS);
            if (m_CurrentMagazine > 0)
                CanShoot = true;
            else
                CanShoot = false;

            OnChangeHealth.Invoke(UpdateBulletsInfo());
        }
    }
    public int holdingBullets;
    public event Action<string> OnChangeHealth;
    public bool CanShoot;
    private void Awake()
    {
        CanShoot = true;
    }
    private void Start()
    {
        OnChangeHealth.Invoke(UpdateBulletsInfo());
    }
    public void OnShoot()
    {
        CurrentMagazine-=1;
    }

    private string UpdateBulletsInfo()
    {
        var text ="Bullets:"+m_CurrentMagazine.ToString() + '/' + holdingBullets.ToString();
        return text;
    }
    public void ReLoadData()
    {
        var count = MAXBULLETS - m_CurrentMagazine;
        if((holdingBullets-count)<0)
        {
            m_CurrentMagazine += holdingBullets;
            holdingBullets = 0;
        }
        else
        {
           holdingBullets-=count;
           m_CurrentMagazine += count;
        }
        OnChangeHealth.Invoke(UpdateBulletsInfo());
    }

}
