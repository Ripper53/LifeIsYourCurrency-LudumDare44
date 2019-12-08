using GameEngine;

public class FilterCharge : Entity<FilterCharge> {
    public PlayerData PlayerData;
    [System.NonSerialized]
    public Filter Filter;
    public int Charge, Cost;
    public float StartDelay, IntervalDelay;
    [System.NonSerialized]
    public float StartTimer, IntervalTimer;

    protected override void Init() {
        Filter = null;
    }
    protected override void Destroyed() { }
}
