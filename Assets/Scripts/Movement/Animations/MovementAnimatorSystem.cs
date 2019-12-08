using UnityEngine;
using GameEngine;

public class MovementAnimatorSystem : EntitySystem<MovementAnimator> {

    public override void Run(MovementAnimator entity, float deltaTime) {
        Vector2Int dir = entity.Movement.Direction;
        entity.Anim.SetInteger(entity.DirectionX, dir.x);
        entity.Anim.SetInteger(entity.DirectionY, dir.y);
    }
}
