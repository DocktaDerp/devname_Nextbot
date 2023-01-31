using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(E_PredictZone))]
public class PredictZoneEditor : Editor
{
    private void OnSceneGUI()
    {
        E_PredictZone fov = (E_PredictZone)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);
    }
}