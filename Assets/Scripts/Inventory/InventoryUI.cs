using UnityEngine;
using GameEngine;
using UnityEngine.UI;

public class InventoryUI : Entity<InventoryUI> {
    public Inventory Inventory;
    public Image Image;

    protected override void Init() {
        Inventory.Added += Inventory_Added;
        Inventory.Removed += Inventory_Removed;
    }

    private void Inventory_Added(Inventory arg1, ICarryable arg2) {
        if (arg2 != null) {
            Image.sprite = arg2.GetSprite();
            Image.enabled = true;
            arg2.SetSpriteRendererActive(false);
            arg2.ChangedSprite += ChangedSprite;
        }
    }

    private void ChangedSprite(ICarryable source, Sprite sprite) {
        Image.sprite = sprite;
    }

    private void Inventory_Removed(Inventory arg1, ICarryable arg2) {
        Image.enabled = false;
        if (arg2 != null)
            arg2.ChangedSprite -= ChangedSprite;
    }

    protected override void Destroyed() {
        if (Inventory.Carrying != null)
            Inventory.Carrying.ChangedSprite -= ChangedSprite;
        Inventory.Added -= Inventory_Added;
        Inventory.Removed -= Inventory_Removed;
    }
}
