using System;
using UnityEditor;
using UnityEngine;

public class Coil : MonoBehaviour {
    public float height;
    public float radius;
    public int turnCount;

    private const int POINT_PER_EACH_COUNT = 30;
    private const float TAU = 6.2831853f;
    
    private void OnDrawGizmos() {
        var pCount = POINT_PER_EACH_COUNT * turnCount;
        var points = new Vector3[pCount];

        for (var i = 0; i < pCount; i++) {
            var tHeight = i / (pCount - 1f);
            var tWinding = tHeight * turnCount;
            var angle = tWinding * TAU;
            var pos = AngleToDir(angle) * radius + Vector3.up * tHeight * height;
            points[i] = pos;
        }

        Handles.DrawPolyLine(points);
    }

    private Vector3 AngleToDir(float angle) {
        return new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
    }
}