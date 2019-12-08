using UnityEngine;

public interface ICarryable {
    void SetSpriteRendererActive(bool value);
    void SetSprite(Sprite sprite);
    Sprite GetSprite();
    event System.Action<ICarryable, Sprite> ChangedSprite;
}
