using GameEngine;

public class ShipUISystem : EntitySystem<ShipUI> {

    public override void Run(ShipUI entity, float deltaTime) {
        entity.WaitImage.fillAmount = entity.Ship.ShipWaitTimer / entity.Ship.ShipWaitTime;
    }
}
