using GameEngine;

public class DNASpawnerAnimatorSystem : EntitySystem<DNASpawnerAnimator> {

    public override void Run(DNASpawnerAnimator entity, float deltaTime) {
        entity.Anim.SetBool(entity.BoolName, entity.DNASpawner.DNA == null);
    }
}
