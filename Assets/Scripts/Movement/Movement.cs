using UnityEngine;
using GameEngine;

public class Movement : Entity<Movement> {
    public Rigidbody2D RB;
    public float Speed;
    [System.NonSerialized]
    public Vector2Int Direction;

    protected override void Init() {
        Direction = new Vector2Int(0, 0);
    }
    protected override void Destroyed() { }
}
