using UnityEngine;
using GameEngine;

public class FadeSpriteZone : Entity<FadeSpriteZone> {
    public SpriteRenderer SR;
    public string TargetTag = "Player";
    [Range(0f, 1f)]
    public float Speed = 0.1f, Min = 0f, Max = 1f;
    [System.NonSerialized]
    public bool Fade;

    protected override void Init() {
        Fade = false;
    }
    protected override void Destroyed() { }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(TargetTag))
            Fade = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag(TargetTag))
            Fade = false;
    }
}
