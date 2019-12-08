using UnityEngine;
using GameEngine;

public class MovementSystem : EntitySystem<Movement> {

    public override void Run(Movement entity, float deltaTime) {
        Vector2Int dir = entity.Direction;
        Rigidbody2D rb = entity.RB;
        Vector2 pos = rb.position;
        if (dir.x > 0) {
            pos.x += entity.Speed;
        } else if (dir.x < 0) {
            pos.x -= entity.Speed;
        }
        if (dir.y > 0) {
            pos.y += entity.Speed;
        } else if (dir.y < 0) {
            pos.y -= entity.Speed;
        }
        if (dir.x != 0 || dir.y != 0)
            rb.MovePosition(pos);
    }
}
