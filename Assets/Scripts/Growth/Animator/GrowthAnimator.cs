using UnityEngine;
using GameEngine;

public class GrowthAnimator : Entity<GrowthAnimator> {
    public Growth Growth;
    public Animator Animator;
    public string GrowthFloatName = "Growth";

    protected override void Init() { }
    protected override void Destroyed() { }
}
