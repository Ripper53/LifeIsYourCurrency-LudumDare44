using UnityEngine;
using GameEngine;

public class Growth : Entity<Growth> {
    public GameObject OBJ;
    public Transform T;
    public BodyPart BodyPartPrefab;
    public float Time;
    [System.NonSerialized]
    public float Timer;
    public event System.Action<Growth> Growed;
    public void OnGrowed() {
        Growed?.Invoke(this);
    }

    protected override void Init() {
        Timer = Time;
    }

    protected override void Destroyed() { }
}
