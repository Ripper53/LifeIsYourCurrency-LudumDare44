using UnityEngine;
using GameEngine;

public class Garbage : Entity<Garbage> {
    public Animator Anim;
    public string TriggerName = "Burn";

    public void UseGarbage(Inventory inventory) {
        ICarryable carryable = inventory.Carrying;
        if (!(inventory.Carrying is Filter) && inventory.Remove() != null) {
            Destroy(((MonoBehaviour)carryable).gameObject);
            Anim.SetTrigger(TriggerName);
        }
    }

    protected override void Init() { }
    protected override void Destroyed() { }
}
