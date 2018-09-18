using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
[CustomEditor(typeof(AIwayPointNetwork))]
public class AIwayPointBehaviourEditor : Editor 
{

    public override void OnInspectorGUI()
    {
        AIwayPointNetwork network = (AIwayPointNetwork)target;
        network.DisplayMode = (PathDisplayMode)EditorGUILayout.EnumPopup("displaymode", network.DisplayMode);
        if (network.DisplayMode == PathDisplayMode.Paths)
        {
            
            
            network.UIStart = EditorGUILayout.IntSlider("waypoint start", network.UIStart, 0, network.waypoints.Count - 1);
            network.UIEnd = EditorGUILayout.IntSlider("waypoint EnD", network.UIEnd, 0, network.waypoints.Count - 1);
        }
        DrawDefaultInspector();
    }


    void OnSceneGUI()
    {

        AIwayPointNetwork network = (AIwayPointNetwork)target;
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;

        for (int i = 0; i < network.waypoints.Count; i++)
        {
            if (network.waypoints[i] != null)
                Handles.Label(network.waypoints[i].position, "waypoint: " + i.ToString(), style);
        }

        if (network.DisplayMode == PathDisplayMode.Connections)
        {
            Vector3[] linePoints = new Vector3[network.waypoints.Count + 1];
            for (int i = 0; i <= network.waypoints.Count; i++)
            {
                int index = i != network.waypoints.Count ? i : 0;
                if (network.waypoints[index] != null)
                    linePoints[i] = network.waypoints[index].position;
                else
                    linePoints[i] = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
            }
            Handles.color = Color.cyan;
            Handles.DrawPolyLine(linePoints);
        }
        else
            if (network.DisplayMode == PathDisplayMode.Paths)
            {
                NavMeshPath path = new NavMeshPath();
                Vector3 from = network.waypoints[network.UIStart].position;
                Vector3 to   = network.waypoints[network.UIEnd].position;

                NavMesh.CalculatePath(from, to, NavMesh.AllAreas, path);
                Handles.color = Color.green;
                Handles.DrawPolyLine(path.corners);
            }
    }


}
