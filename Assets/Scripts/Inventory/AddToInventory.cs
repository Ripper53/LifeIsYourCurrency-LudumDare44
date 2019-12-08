using UnityEngine;

public class AddToInventory : MonoBehaviour {
    public Inventory Inventory;
    public Filter Filter;

    private void Start() {
        Inventory.Add(Filter);
        Destroy(this);
    }
}
