using UnityEngine;
using GameEngine;

public class Grass : Entity<Grass> {
    public enum Type { NORMAL, FILTERED, GROWTH };
    private Type _grassType;
    public Type GrassType {
        get => _grassType;
        set {
            _grassType = value;
            ChangedType?.Invoke(this, _grassType);
        }
    }
    public Transform T;
    public event System.Action<Grass, Type> ChangedType;

    protected override void Init() {
        GrassType = Type.NORMAL;
    }

    protected override void Destroyed() { }
}
