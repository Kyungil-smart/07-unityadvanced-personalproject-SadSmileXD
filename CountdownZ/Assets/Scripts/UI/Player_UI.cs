using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  m_text;
   
    public void UpdateUI(string text)
    {
        m_text.text = text;
    }
    
}
