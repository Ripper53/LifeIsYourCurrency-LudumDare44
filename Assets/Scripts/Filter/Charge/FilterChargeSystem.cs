using GameEngine;

public class FilterChargeSystem : EntitySystem<FilterCharge> {

    public override void Run(FilterCharge entity, float deltaTime) {
        if (entity.Filter == null) {
            entity.StartTimer = 0f;
            entity.IntervalTimer = 0f;
            return;
        }
        if (entity.StartTimer > 0f) {
            entity.StartTimer -= deltaTime;
            if (entity.StartTimer <= 0f && Charge(entity)) {
                entity.IntervalTimer = entity.IntervalDelay;
            }
        } else if (entity.IntervalTimer > 0f) {
            entity.IntervalTimer -= deltaTime;
            if (entity.IntervalTimer <= 0f && Charge(entity)) {
                entity.IntervalTimer = entity.IntervalDelay;
            }
        } else {
            entity.StartTimer = entity.StartDelay;
            if (entity.StartTimer <= 0f && Charge(entity)) {
                entity.IntervalTimer = entity.IntervalDelay;
            }
        }
    }

    private bool Charge(FilterCharge filterCharge) {
        if (filterCharge.PlayerData.Use(filterCharge.Cost)) {
            filterCharge.Filter.Add(filterCharge.Charge);
            return true;
        }
        return false;
    }
}
