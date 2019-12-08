using UnityEngine;
using GameEngine;

public class Filter : Entity<Filter>, ICarryable {
    public SpriteRenderer SR;
    public void SetSpriteRendererActive(bool value) => SR.enabled = value;
    public event System.Action<ICarryable, Sprite> ChangedSprite;
    public void OnChangedSprite() {
        ChangedSprite?.Invoke(this, SR.sprite);
    }
    public void SetSprite(Sprite sprite) {
        SR.sprite = sprite;
        OnChangedSprite();
    }
    public Sprite GetSprite() => SR.sprite;
    private int _amount;
    public int Amount {
        get => _amount;
        set {
            _amount = value;
            ChangedAmount?.Invoke(this, _amount);
        }
    }
    public int MaxAmount;
    public event System.Action<Filter, int> ChangedAmount;

    private bool CheckAmount() {
        if (Amount < 0) {
            Amount = 0;
            return false;
        } else if (Amount > MaxAmount) {
            Amount = MaxAmount;
        }
        return true;
    }

    public bool Use(int amount = 1) {
        Amount -= amount;
        return CheckAmount();
    }

    public void Add(int amount) {
        Amount += amount;
        CheckAmount();
    }

    public void Remove(int amount) {
        Amount -= amount;
        CheckAmount();
    }

    protected override void Init() {
        Amount = MaxAmount;
    }
    protected override void Destroyed() { }
}
