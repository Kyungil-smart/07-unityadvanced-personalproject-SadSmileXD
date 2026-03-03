using UnityEditor;
using UnityEngine;
using XNodeEditor;

// [InitializeOnLoad]를 붙이면 유니티 에디터가 켜질 때 자동으로 이 클래스가 실행됩니다.
[InitializeOnLoad]
public static class XNodeRepainter
{
    static XNodeRepainter()
    {
        // 에디터 매 프레임 업데이트 루프에 리페인트 함수 등록
        EditorApplication.update += UpdateRepaint;
    }

    private static void UpdateRepaint()
    {
        // 게임이 플레이 중이고, 현재 화면에 띄워진 xNode 창이 있다면?
        if (Application.isPlaying && NodeEditorWindow.current != null)
        {
            // 그 창을 매 프레임 강제로 새로고침(Repaint) 해라!
            NodeEditorWindow.current.Repaint();
        }
    }
}