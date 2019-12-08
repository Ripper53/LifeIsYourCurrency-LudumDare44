using UnityEngine;
using GameEngine;

public class Harvest : Entity<Harvest> {
    public Transform T;
    public Inventory Inventory;
    public LayerMask CollisionLayer, TargetLayer;
    public float Distance;
    [System.NonSerialized]
    public bool Do;

    protected override void Init() {
        Do = false;
    }

    protected override void Destroyed() { }
}
