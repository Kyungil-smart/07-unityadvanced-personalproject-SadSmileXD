using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UI_", menuName = "Scriptable Objects/UI/Click_")]
public class UI_Off : UIClickBase
{
    [SerializeField] private bool flag;
    private MonoBehaviour Owner;
    private GameObject Object;
    public override void Init(MonoBehaviour Owner, params object[] datas)
    {
        this.Owner = Owner;
        Object= datas[0] as GameObject;
    }
    public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {

        Object.SetActive(flag);
    }
}
