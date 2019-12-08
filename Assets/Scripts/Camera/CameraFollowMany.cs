using System.Collections.Generic;
using UnityEngine;
using GameEngine;

public class CameraFollowMany : Entity<CameraFollowMany> {
    public Transform T;
    public Camera Cam;
    public float SmoothTime;
    public Vector2 Offset;
    public List<Transform> Follow;
    [System.NonSerialized]
    public Vector2 Velo;

    protected override void Init() { }
    protected override void Destroyed() { }
}
