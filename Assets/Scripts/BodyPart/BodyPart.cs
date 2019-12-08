using UnityEngine;
using GameEngine;

public class BodyPart : Entity<BodyPart>, ICarryable {
    public enum Type {
        HEART,
        LUNGS,
        LIVER,
        INTESTINES
    }
    public GameObject OBJ;
    public SpriteRenderer SR;
    public void SetSpriteRendererActive(bool value) => SR.enabled = value;
    public event System.Action<ICarryable, Sprite> ChangedSprite;
    public void SetSprite(Sprite sprite) {
        SR.sprite = sprite;
        ChangedSprite?.Invoke(this, sprite);
    }
    public Sprite GetSprite() => SR.sprite;
    public Type Ty;
    public int SellPrice;

    protected override void Init() { }
    protected override void Destroyed() { }
}
