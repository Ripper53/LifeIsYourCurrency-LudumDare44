using UnityEngine;
using GameEngine;

public class DNA : Entity<DNA>, ICarryable {
    public SpriteRenderer SR;
    public void SetSpriteRendererActive(bool value) => SR.enabled = value;
    public event System.Action<ICarryable, Sprite> ChangedSprite;
    public void SetSprite(Sprite sprite) {
        SR.sprite = sprite;
        ChangedSprite?.Invoke(this, sprite);
    }
    public Sprite GetSprite() => SR.sprite;
    public Growth GrowthPrefab;

    public void Use(Inventory inventory, Grass grass) {
        grass.GrassType = Grass.Type.GROWTH;
        inventory.Remove();
        Growth growth = Instantiate(GrowthPrefab, grass.T.position, Quaternion.identity);
        void SetGrowthBackToNormal(Growth g) {
            growth.Growed -= SetGrowthBackToNormal;
            grass.GrassType = Grass.Type.NORMAL;
        }
        growth.Growed += SetGrowthBackToNormal;
    }

    protected override void Init() { }
    protected override void Destroyed() { }
}
