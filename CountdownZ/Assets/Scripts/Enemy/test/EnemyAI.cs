using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target.IsNotNull())
        {
            agent.SetDestination(target.position);
        }
    }
}