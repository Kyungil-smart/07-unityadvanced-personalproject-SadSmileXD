#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class FanShapeDetector : MonoBehaviour
{
    public float viewRadius = 5f;
    [Range(0, 360)]
    public float viewAngle = 90f;

    // ... (이전에 작성한 타겟 감지 로직) ...

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // 1. 기즈모 색상 설정 (반투명한 빨간색)
        Handles.color = new Color(1f, 0f, 0f, 0.2f);
        Gizmos.color = Color.red;

        // 2. 부채꼴의 시작점(왼쪽 경계선) 각도 계산
        // 내 정면(forward)을 기준으로 왼쪽(-y축 회전)으로 시야각의 절반만큼 회전시킵니다.
        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2f, 0) * transform.forward;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2f, 0) * transform.forward;

        // 3. 부채꼴 모양의 면 그리기 (SolidArc)
        // (중심점, 회전축(위쪽), 시작방향, 전체각도, 반지름)
        Handles.DrawSolidArc(transform.position, Vector3.up, leftBoundary, viewAngle, viewRadius);

        // 4. 부채꼴의 양쪽 경계선(테두리) 그리기
        Gizmos.DrawRay(transform.position, leftBoundary * viewRadius);
        Gizmos.DrawRay(transform.position, rightBoundary * viewRadius);
    }
#endif
}