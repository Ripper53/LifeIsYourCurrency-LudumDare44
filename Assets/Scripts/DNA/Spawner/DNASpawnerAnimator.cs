using UnityEngine;
using GameEngine;

public class DNASpawnerAnimator : Entity<DNASpawnerAnimator> {
    public DNASpawner DNASpawner;
    public Animator Anim;
    public string BoolName = "DNASpawnerOn";

    protected override void Init() { }
    protected override void Destroyed() { }
}
