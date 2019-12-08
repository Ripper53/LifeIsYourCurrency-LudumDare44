using UnityEngine;
using GameEngine;

public class MovementControlsSystem : EntitySystem<MovementControls> {

    public override void Run(MovementControls entity, float deltaTime) {
        MovementControls.Controls c = entity.Control;
        Vector2Int dir = new Vector2Int(0, 0);
        if (c.HasFlag(MovementControls.Controls.UP)) {
            dir.y += 1;
        }
        if (c.HasFlag(MovementControls.Controls.DOWN)) {
            dir.y -= 1;
        }
        if (c.HasFlag(MovementControls.Controls.RIGHT)) {
            dir.x += 1;
        }
        if (c.HasFlag(MovementControls.Controls.LEFT)) {
            dir.x -= 1;
        }
        entity.Movement.Direction = dir;
    }
}
