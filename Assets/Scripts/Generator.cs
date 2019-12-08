using UnityEngine;

[ExecuteInEditMode]
public class Generator : MonoBehaviour {
    public Transform[] Prefab;
    public Vector2Int Size;
    public Vector2 Interval;

    private void OnEnable() {
        for (int y = 0, i = 0; y < Size.y; y++) {
            for (int x = 0; x < Size.x; x++, i++) {
                Prefab[i].position = new Vector2(x * Interval.x, y * Interval.y);
            }
        }
    }
}
