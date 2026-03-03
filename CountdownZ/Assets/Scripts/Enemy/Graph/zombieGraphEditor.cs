using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;
using static XNodeEditor.NodeGraphEditor;

[CustomNodeGraphEditor(typeof(ZombieGraph))] // 본인의 그래프 클래스명 확인
public class zombieGraphEditor : NodeGraphEditor
{
    public override Gradient GetNoodleGradient(NodePort output, NodePort input)
    {
        BaseNode node = output.node as BaseNode;

        if (node != null)
        {
            float lastTime = node.GetPortActiveTime(output.fieldName);
            float elapsed = Time.realtimeSinceStartup - lastTime;
            float duration = 0.8f;

            if (elapsed < duration)
            {
                float blink = Mathf.Sin(Time.realtimeSinceStartup * 40f) * 0.5f + 0.5f;
                float intensity = Mathf.Clamp01(1f - (elapsed / duration));

                Color transitionColor = Color.Lerp(Color.gray, Color.cyan * 2f, intensity * blink);

                Gradient grad = new Gradient();
                grad.SetKeys(
                    new GradientColorKey[] { new GradientColorKey(transitionColor, 0f), new GradientColorKey(transitionColor, 1f) },
                    new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) }
                );
                return grad;
            }
        }

        return base.GetNoodleGradient(output, input);
    }

    public override float GetNoodleThickness(NodePort output, NodePort input)
    {
        BaseNode node = output.node as BaseNode;

        if (node != null)
        {
            float lastTime = node.GetPortActiveTime(output.fieldName);
            float elapsed = Time.realtimeSinceStartup - lastTime;

            if (elapsed < 0.8f) return 6f; // 활성화 시 두께 6
        }

        return 2f; // 기본 두께 2
    }
}