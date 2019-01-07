using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
public class DrawCircle : MonoBehaviour {
    [Range(0, 50)]
    public int segments = 50;
    [Range(0, 50)]
    public float xradius = 5;
    [Range(0, 50)]
    public float yradius = 5;
    LineRenderer line;

    public float rotateSpeed = 1f;

    void Start() {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments;
        line.useWorldSpace = false;

    }

    private void Update() {
        CreatePoints();
        transform.Rotate(Vector3.forward, rotateSpeed);
    }

    void CreatePoints() {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < segments; i++) {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, z, 0));

            angle += (360f / segments);
        }
    }
}