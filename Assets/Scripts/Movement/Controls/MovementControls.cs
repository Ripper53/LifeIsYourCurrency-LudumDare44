using GameEngine;

public class MovementControls : Entity<MovementControls> {
    [System.Flags]
    public enum Controls { NONE = 0, UP = 1, RIGHT = 2, DOWN = 4, LEFT = 8 };

    public Movement Movement;
    [System.NonSerialized]
    public Controls Control;

    protected override void Init() {
        Control = Controls.NONE;
    }

    protected override void Destroyed() { }
}
