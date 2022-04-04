using System;
using UnityEditor;
using UnityEngine;

public class Torus : MonoBehaviour {

    public float circumference = 5;
    public int roundCount = 20;
    public float roundRadius = 1;

    private const int ROUND_POINT_COUNT = 30;
    private const float TAU = 6.27f;
    
    
    private void OnDrawGizmos() {
        var totalPoint = roundCount * ROUND_POINT_COUNT;
        var points = new Vector3[totalPoint];

        for (var i = 0; i < totalPoint; i++) {
            var t = i / (totalPoint - 1f);
            var tWinding = t * roundCount;
            
            var angle = t * TAU;
            var majorRadius = circumference / TAU;
            var corePoint = angle.AngleToDir() * majorRadius;

            var localAngle = tWinding * TAU;
            var localPoint = localAngle.AngleToDir() * roundRadius;
            
            var xLocalDir = corePoint.normalized;
            var yLocalDir = Vector3.forward;

            points[i] = corePoint + xLocalDir * localPoint.x + yLocalDir * localPoint.y;
        }
        
        Handles.DrawPolyLine(points);
    }
}