using UnityEngine;

public class ZombieSensor : MonoBehaviour
{
    [Header("탐지 설정")]
    public float viewDistance = 15f;    // 탐지 거리
    [Range(0, 360)]
    public float viewAngle = 110f;     // 시야각
    public LayerMask targetMask;        // 플레이어 레이어
    public LayerMask obstacleMask;      // 장애물 레이어

    private Transform target;           // 찾은 플레이어의 참조
    private bool m_IsDetected;
    public bool IsDetected 
    { get
        {
            m_IsDetected = CheckDetection();
            return m_IsDetected;
        }
       
    }
    public Transform DetectedTarget => target;

  

    public bool CheckDetection()
    {
        // 1. 범위 내 플레이어 탐색
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewDistance, targetMask);

        foreach (var col in targetsInViewRadius)
        {
            Transform candidate = col.transform;
            Vector3 dirToTarget = (candidate.position - transform.position).normalized;

            // 2. 시야각 체크
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, candidate.position);

                // 3. 장애물 체크 (눈높이 보정)
                Vector3 eyePos = transform.position + Vector3.up * 1.5f;
                if (!Physics.Raycast(eyePos, dirToTarget, dstToTarget, obstacleMask))
                {
                    target = candidate;
                    return true;
                }
            }
        }

        target = null;
        return false;
    }

    // 에디터에서 시야 범위를 그리는 기즈모
    private void OnDrawGizmos()
    {
        // 못 찾으면 파란색, 찾으면 빨간색
        Gizmos.color = IsDetected ? Color.red : Color.blue;

        // 1. 탐지 거리 원 그리기
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        // 2. 시야각 부채꼴 라인 그리기
        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward;

        Gizmos.DrawRay(transform.position + Vector3.up * 1.5f, leftBoundary * viewDistance);
        Gizmos.DrawRay(transform.position + Vector3.up * 1.5f, rightBoundary * viewDistance);

        // 3. 타겟이 있다면 연결선 그리기
        if (IsDetected && target != null)
        {
            Gizmos.DrawLine(transform.position + Vector3.up * 1.5f, target.position);
        }
    }
}