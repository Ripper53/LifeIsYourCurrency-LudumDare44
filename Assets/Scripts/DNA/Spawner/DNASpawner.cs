using UnityEngine;
using GameEngine;

public class DNASpawner : Entity<DNASpawner> {
    public DNA DNAPrefab;
    public ICarryable DNA;
    public Transform T;
    public float SpawnTime;
    [System.NonSerialized]
    public float SpawnTimer;

    public void PickUp(Inventory inventory) {
        if (inventory.Add(DNA))
            DNA = null;
    }

    protected override void Init() {
        SpawnTimer = SpawnTime;
        DNA = null;
    }

    protected override void Destroyed() { }
}
