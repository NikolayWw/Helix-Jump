using CodeBase.Platform;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(PlatformGroupBreak))]
    public class PlatformGroupBreakEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var platformBreak = (PlatformGroupBreak)target;

            if (GUILayout.Button("Collect Platform Segment Destroy"))
            {
                platformBreak.SetPlatformSegmentDestroy(platformBreak.GetComponentsInChildren<PlatformSegmentDestroy>());
                EditorUtility.SetDirty(platformBreak);
            }
        }
    }
}