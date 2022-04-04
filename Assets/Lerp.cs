using System;
using System.Net;
using UnityEngine;

public class Lerp : MonoBehaviour {

    public Transform[] points;

    public float moveDuration=3;
    private float _elapsedTime;

    private void Update() {
            
        var movePoint = (points[1].position - points[0].position) * (_elapsedTime / moveDuration);
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= moveDuration) {
            var tempPoint = points[0];
            points[0] = points[1];
            points[1] = tempPoint;
            _elapsedTime = 0;
        }

        transform.position =points[0].position +  movePoint;
    }

    private void OnDrawGizmos() {
        if (points.Length == 0) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(points[1].position, .5f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(points[0].position, .5f);
        Gizmos.DrawLine(points[0].position, points[1].position);
    }
}