using UnityEngine;
using GameEngine;

public class GrassSprite : Entity<GrassSprite> {
    public Grass Grass;
    public SpriteRenderer SR;
    public Sprite NormalGrassSprite, FilteredGrassSprite;

    protected override void Init() {
        Grass.ChangedType += Grass_ChangedType;
    }

    private void Grass_ChangedType(Grass arg1, Grass.Type arg2) {
        if (arg2 == Grass.Type.NORMAL) {
            SR.sprite = NormalGrassSprite;
        } else if (arg2 == Grass.Type.FILTERED) {
            SR.sprite = FilteredGrassSprite;
        }
    }

    protected override void Destroyed() {
        Grass.ChangedType -= Grass_ChangedType;
    }
}
