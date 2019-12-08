using UnityEngine;
using GameEngine;

public class MovementAnimator : Entity<MovementAnimator> {
    public Movement Movement;
    public Animator Anim;
    public string DirectionX = "DirectionX", DirectionY = "DirectionY";

    protected override void Init() { }

    protected override void Destroyed() { }
}
