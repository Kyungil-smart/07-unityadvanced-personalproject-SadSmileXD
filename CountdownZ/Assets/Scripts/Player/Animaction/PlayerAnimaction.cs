using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimaction : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private PlayerMovement player;

    private void Update()
    {
        //SetMove(player.RawInput.x, player.RawInput.y);
    }
    public void SetMove(float x,float y)
    {
        m_animator.SetFloat("XDir", x);
        m_animator.SetFloat("YDir", y);
    }
}
