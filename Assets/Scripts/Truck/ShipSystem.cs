using UnityEngine;
using GameEngine;

public class ShipSystem : EntitySystem<Ship> {

    public override void Run(Ship entity, float deltaTime) {
        if (entity.CanPickUp) {
            if (entity.Placeable.Inventory.Carrying is BodyPart bodyPart && bodyPart.Ty == entity.Type) {
                entity.CanPickUp = false;
                entity.PlayerData.Money += bodyPart.SellPrice;
                entity.Inventory.Remove();
                entity.Anim.SetTrigger(entity.TriggerName);
                Object.Destroy(bodyPart.gameObject);
            } else if (entity.ShipWaitTimer > 0f) {
                entity.ShipWaitTimer -= deltaTime;
            } else {
                entity.CanPickUp = false;
                entity.PlayerData.Money -= entity.MissCost;
                entity.Anim.SetTrigger(entity.TriggerName);
            }
        }
    }
}
