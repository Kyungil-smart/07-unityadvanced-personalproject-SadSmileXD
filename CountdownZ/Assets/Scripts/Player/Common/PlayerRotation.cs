using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private GameObject m_PlayerObject;
    [SerializeField]private Transform m_CarmerRotation;
    public float mouseSensitivity ; // 마우스 좌우 회전 속도

    private void Update()
    {
        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity;
        m_PlayerObject.transform.Rotate(mouseX * Vector3.up);
    }
}
