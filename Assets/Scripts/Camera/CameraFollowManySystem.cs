using System.Collections.Generic;
using UnityEngine;
using GameEngine;

public class CameraFollowManySystem : EntitySystem<CameraFollowMany> {

    public override void Run(CameraFollowMany entity, float deltaTime) {
        if (entity.Follow.Count > 0) {
            Vector2 pos = new Vector2(0f, 0f);
            List<Transform> f = entity.Follow;
            for (int i = 0; i < f.Count; i++) {
                pos += (Vector2)f[i].position;
            }
            pos /= f.Count;
            pos += entity.Offset;
            pos = Vector2.SmoothDamp(entity.T.position, new Vector2(pos.x, pos.y), ref entity.Velo, entity.SmoothTime);
            entity.T.position = new Vector3(pos.x, pos.y, entity.T.position.z);
        }
    }
}
