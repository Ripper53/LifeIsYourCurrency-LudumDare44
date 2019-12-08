using UnityEngine;

public class Inventory : MonoBehaviour {
    public ICarryable Carrying { get; private set; }
    public event System.Action<Inventory, ICarryable> Added, Removed;

    public bool Add(ICarryable carryable) {
        if (Carrying != null || carryable == null) return false;
        Carrying = carryable;
        Added?.Invoke(this, Carrying);
        return true;
    }

    public ICarryable Remove() {
        ICarryable wasCarrying = Carrying;
        Carrying = null;
        Removed?.Invoke(this, wasCarrying);
        return wasCarrying;
    }
}
