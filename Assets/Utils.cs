using UnityEngine;

public static class Utils {
    public static Vector3 AngleToDir(this float angle) {
        return new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
    }
}