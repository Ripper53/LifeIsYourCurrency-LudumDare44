using System.Collections.Generic;
using GameEngine;

public class GameEntitySystemManager : EntitySystemManager {
    public override IEnumerable<EntitySystem> UpdateSystems { get; protected set; }
    public override IEnumerable<EntitySystem> LateUpdateSystems { get; protected set; }
    public override IEnumerable<EntitySystem> FixedUpdateSystems { get; protected set; }

    private void Awake() {
        UpdateSystems = new EntitySystem[] {
            
        };
        LateUpdateSystems = new EntitySystem[] {

        };
        FixedUpdateSystems = new EntitySystem[] {
            new GrowthSystem(),
            new GrowthAnimatorSystem(),
            new FilterChargeSystem(),
            new FilterAnimatorSystem(),
            new DNASpawnerSystem(),
            new DNASpawnerAnimatorSystem(),

            new MovementControlsSystem(),

            new MovementSystem(),
            new MovementAnimatorSystem(),

            new HarvestSystem(),
            new ShipSystem(),
            new ShipUISystem(),

            new CameraFollowManySystem(),
            new FadeSpriteZoneSystem()
        };
    }
}
