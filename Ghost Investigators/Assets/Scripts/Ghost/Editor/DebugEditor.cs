using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GhostView))]
public class DebugEditor : Editor
{
    GhostView ghostView;
    private void OnSceneGUI()
    {
        ghostView = target as GhostView;
        DrawFOV();
      
    }

    
    public void DrawFOV()
    {
        Vector3 fovPositionStart = ghostView.ghostController.GetDirectionFromAngle(-ghostView.ghostTrait.fieldOfView / 2);
        Vector3 fovPositionEnd = ghostView.ghostController.GetDirectionFromAngle(ghostView.ghostTrait.fieldOfView / 2);

        Handles.color = Color.red;
        Handles.DrawLine(ghostView.LOSTransform.position, ghostView.LOSTransform.position + fovPositionStart * ghostView.LOSRange);
        Handles.DrawLine(ghostView.LOSTransform.position, ghostView.LOSTransform.position + fovPositionEnd * ghostView.LOSRange);
        Handles.DrawWireArc(ghostView.LOSTransform.position, Vector3.up, Vector3.forward, 360.0f, ghostView.LOSRange);
    }
    
}
