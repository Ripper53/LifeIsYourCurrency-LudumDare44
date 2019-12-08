using GameEngine;

public class HarvestPlayerControls : Entity<HarvestPlayerControls> {
    public PlayerControls Controls;
    public Harvest Harvest;

    protected override void Init() {
        Controls.Harvest.Grab.performed += Grab_performed;
    }

    private void Grab_performed(UnityEngine.Experimental.Input.InputAction.CallbackContext obj) {
        Harvest.Do = true;
    }

    protected override void Destroyed() {
        Controls.Harvest.Grab.performed -= Grab_performed;
    }
}
