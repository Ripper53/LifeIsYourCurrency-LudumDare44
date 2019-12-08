using UnityEngine;
using GameEngine;

public class Ship : Entity<Ship> {
    private bool _canPickUp;
    public bool CanPickUp {
        get => _canPickUp;
        set {
            _canPickUp = value;
            ShipWaitTimer = _canPickUp ? ShipWaitTime : 0f;
        }
    }
    public PlayerData PlayerData;
    public Inventory Inventory;
    public event System.Action<Ship, BodyPart.Type> ChangedType;
    private BodyPart.Type _type;
    public BodyPart.Type Type {
        get => _type;
        set {
            _type = value;
            ChangedType?.Invoke(this, _type);
        }
    }
    public Animator Anim;
    public string TriggerName = "DropOff";
    public Placeable Placeable;
    public int MissCost;
    public float ShipWaitTime;
    [System.NonSerialized]
    public float ShipWaitTimer;

    protected override void Init() {
        CanPickUp = false;
        PickRandomToPickUp();
    }

    public void SetCanPickUpToTrueViaAnimation() {
        CanPickUp = true;
    }

    public void PickRandomToPickUp() {
        PlayerData.CurrentHighest++;
        Type = (BodyPart.Type)Random.Range(0, 4);
    }

    protected override void Destroyed() { }
}
