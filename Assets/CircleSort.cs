using UnityEditor;
using UnityEngine;

public class CircleSort : MonoBehaviour {
    public float[] items;
    public float arcRadius = 3;
    public float arcAngle = 3;
    public Vector3 from;
    private const float TAU = 6.2831853f;

    private void OnDrawGizmos() {
        Handles.DrawWireArc(default, Vector3.forward, Vector3.up, arcAngle, arcRadius);
        Handles.DrawWireArc(default, Vector3.forward, Vector3.up, -arcAngle, arcRadius);

        var angleBetween = new float[items.Length - 1];
        for (var i = 0; i < angleBetween.Length; i++) {
            var a = items[i];
            var b = items[i + 1];
            var abLength = a + b;

            var ang = Mathf.Acos(1 - (abLength * abLength) / (2 * arcRadius * arcRadius));
            angleBetween[i] = ang;
        }
        
        var angRad = 0f;
        for (var i = 0; i < items.Length; i++) {
            var radius = items[i];
            var itemCenter = angRad.AngleToDir() * arcRadius;
            Handles.DrawWireDisc(itemCenter, Vector3.forward, radius);
            if (i < items.Length - 1)
                angRad += angleBetween[i];
        }
    }

}