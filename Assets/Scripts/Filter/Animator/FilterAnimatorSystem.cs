using GameEngine;

public class FilterAnimatorSystem : EntitySystem<FilterAnimator> {

    public override void Run(FilterAnimator entity, float deltaTime) {
        entity.Filter.OnChangedSprite();
    }
}
