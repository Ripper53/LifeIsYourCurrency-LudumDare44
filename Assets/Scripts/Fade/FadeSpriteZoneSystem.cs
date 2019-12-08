using UnityEngine;
using GameEngine;

public class FadeSpriteZoneSystem : EntitySystem<FadeSpriteZone> {

    public override void Run(FadeSpriteZone entity, float deltaTime) {
        Color color = entity.SR.color;
        if (entity.Fade) {
            if (color.a > 0f) {
                color.a -= entity.Speed;
                CheckFloat(ref color.a, entity.Min, entity.Max);
            }
        } else {
            if (color.a < 1f) {
                color.a += entity.Speed;
                CheckFloat(ref color.a, entity.Min, entity.Max);
            }
        }
        entity.SR.color = color;
    }

    private void CheckFloat(ref float value, float min, float max) {
        if (value > 1f)
            value = 1f;
        else if (value < 0f)
            value = 0f;
        if (value > max)
            value = max;
        else if (value < min)
            value = min;
    }
}
