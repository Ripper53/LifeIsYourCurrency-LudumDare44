using UnityEngine;
using GameEngine;

public class GrowthSystem : EntitySystem<Growth> {

    public override void Run(Growth entity, float deltaTime) {
        if (entity.Timer > 0f)
            entity.Timer -= deltaTime;
        else {
            entity.OnGrowed();
            Object.Instantiate(entity.BodyPartPrefab, entity.T.position, Quaternion.identity);
            Object.Destroy(entity.OBJ);
        }
    }
}
