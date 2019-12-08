using GameEngine;

public class Placeable : Entity<Placeable> {
    public Inventory Inventory;

    protected override void Init() { }
    protected override void Destroyed() { }
}
