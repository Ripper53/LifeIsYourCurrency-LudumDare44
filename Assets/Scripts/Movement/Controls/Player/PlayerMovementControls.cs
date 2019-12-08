using UnityEngine;
using GameEngine;

public class PlayerMovementControls : Entity<PlayerMovementControls> {
    public PlayerControls PlayerControls;
    public MovementControls MovementControls;

    protected override void Init() {
        PlayerControls.Enable();
        PlayerControls.Movement.Direction.performed += Direction_performed;
        PlayerControls.Movement.Direction.cancelled += Direction_cancelled;
    }

    private void Direction_cancelled(UnityEngine.Experimental.Input.InputAction.CallbackContext obj) {
        MovementControls.Control = MovementControls.Controls.NONE;
    }
    private void DirCan() {
        if (MovementControls.Control.HasFlag(MovementControls.Controls.UP))
            MovementControls.Control ^= MovementControls.Controls.UP;
        if (MovementControls.Control.HasFlag(MovementControls.Controls.RIGHT))
            MovementControls.Control ^= MovementControls.Controls.RIGHT;
        if (MovementControls.Control.HasFlag(MovementControls.Controls.DOWN))
            MovementControls.Control ^= MovementControls.Controls.DOWN;
        if (MovementControls.Control.HasFlag(MovementControls.Controls.LEFT))
            MovementControls.Control ^= MovementControls.Controls.LEFT;
    }

    private void Direction_performed(UnityEngine.Experimental.Input.InputAction.CallbackContext obj) {
        DirCan();
        Vector2 vec = obj.ReadValue<Vector2>();
        if (vec.x > 0f) {
            MovementControls.Control |= MovementControls.Controls.RIGHT;
        } else if (vec.x < 0f) {
            MovementControls.Control |= MovementControls.Controls.LEFT;
        }
        if (vec.y > 0f) {
            MovementControls.Control |= MovementControls.Controls.UP;
        } else if (vec.y < 0f) {
            MovementControls.Control |= MovementControls.Controls.DOWN;
        }
    }

    protected override void Destroyed() {
        PlayerControls.Disable();
        PlayerControls.Movement.Direction.performed -= Direction_performed;
        PlayerControls.Movement.Direction.cancelled -= Direction_cancelled;
    }
}
