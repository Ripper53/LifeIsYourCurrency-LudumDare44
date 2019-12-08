using GameEngine;

public class GrowthAnimatorSystem : EntitySystem<GrowthAnimator> {

    public override void Run(GrowthAnimator entity, float deltaTime) {
        entity.Animator.SetFloat(entity.GrowthFloatName, 1f - (entity.Growth.Timer / entity.Growth.Time));
    }
}
