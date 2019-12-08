using UnityEngine;
using GameEngine;

public class DNASpawnerSystem : EntitySystem<DNASpawner> {

    public override void Run(DNASpawner entity, float deltaTime) {
        if (entity.SpawnTimer > 0f) {
            if (entity.DNA == null)
                entity.SpawnTimer -= deltaTime;
        } else if (entity.DNA == null) {
            entity.SpawnTimer = entity.SpawnTime;
            entity.DNA = Object.Instantiate(entity.DNAPrefab, entity.T.position, Quaternion.identity);
        }
    }
}
