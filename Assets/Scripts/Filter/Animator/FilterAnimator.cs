using UnityEngine;
using GameEngine;

public class FilterAnimator : Entity<FilterAnimator> {
    public Filter Filter;
    public Animator Anim;
    public string IntName = "Charge";

    protected override void Init() {
        Filter.ChangedAmount += Filter_ChangedAmount;
    }

    private void Filter_ChangedAmount(Filter arg1, int arg2) {
        Anim.SetInteger(IntName, arg2);
    }

    protected override void Destroyed() {
        Filter.ChangedAmount -= Filter_ChangedAmount;
    }
}
