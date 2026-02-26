using UnityEngine;
using UnityEngine.InputSystem;

public class BodyBender : MonoBehaviour
{
    public Transform spineBone;     // 캐릭터의 허리 뼈 (Spine1, Spine2 등)
    public Transform cameraTransform; // 시네머신 카메라 혹은 메인 카메라
    public float bendIntensity = 0.5f; // 몸을 얼마나 꺾을지 (0~1 사이)
    public float mouseSensitivity;
    void LateUpdate()
    {
        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity;
        spineBone.Rotate(mouseX * Vector3.up);
    }
}