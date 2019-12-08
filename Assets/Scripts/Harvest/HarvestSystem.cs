using UnityEngine;
using GameEngine;

public class HarvestSystem : EntitySystem<Harvest> {

    public override void Run(Harvest entity, float deltaTime) {
        // This is DISGUSTING!
        if (entity.Do) {
            entity.Do = false;
            Collider2D col = Physics2D.Raycast(entity.T.position, entity.T.up, entity.Distance, entity.CollisionLayer).collider;
            if (col != null) {
                int layer = 1 << col.gameObject.layer;
                if ((layer & entity.TargetLayer) == layer) {
                    BodyPart bodyPart = col.GetComponent<BodyPart>();
                    if (bodyPart != null) {
                        if (entity.Inventory.Add(bodyPart))
                            bodyPart.OBJ.SetActive(false);
                    } else {
                        Grass grass = col.GetComponent<Grass>();
                        if (grass != null) {
                            switch (grass.GrassType) {
                                case Grass.Type.NORMAL:
                                    if (entity.Inventory.Carrying is Filter filter && filter.Use())
                                        grass.GrassType = Grass.Type.FILTERED;
                                    break;
                                case Grass.Type.FILTERED:
                                    if (grass.GrassType == Grass.Type.FILTERED && entity.Inventory.Carrying is DNA dna)
                                        dna.Use(entity.Inventory, grass);
                                    break;
                            }
                        } else {
                            DNASpawner dnaSpawner = col.GetComponent<DNASpawner>();
                            if (dnaSpawner != null) {
                                dnaSpawner.PickUp(entity.Inventory);
                            } else {
                                Garbage garbage = col.GetComponent<Garbage>();
                                if (garbage != null) {
                                    garbage.UseGarbage(entity.Inventory);
                                } else {
                                    Placeable placeable = col.GetComponent<Placeable>();
                                    if (placeable != null) {
                                        FilterCharge filterCharge = placeable.GetComponent<FilterCharge>();
                                        if (filterCharge != null) {
                                            if (entity.Inventory.Carrying is Filter filter) {
                                                if (placeable.Inventory.Add(filter)) {
                                                    entity.Inventory.Remove();
                                                    filterCharge.Filter = filter;
                                                }
                                            } else if (entity.Inventory.Add(placeable.Inventory.Carrying)) {
                                                placeable.Inventory.Remove();
                                                filterCharge.Filter = null;
                                            }
                                        } else if (placeable.CompareTag("Ship")) {
                                            if (entity.Inventory.Carrying == null) {
                                                entity.Inventory.Add(placeable.Inventory.Remove());
                                            } else if (entity.Inventory.Carrying is BodyPart) {
                                                ICarryable carryable = placeable.Inventory.Remove();
                                                placeable.Inventory.Add(entity.Inventory.Remove());
                                                entity.Inventory.Add(carryable);
                                            }
                                        } else {
                                            ICarryable carryable = placeable.Inventory.Remove();
                                            placeable.Inventory.Add(entity.Inventory.Remove());
                                            entity.Inventory.Add(carryable);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
