using UnityEngine;

public class UIUtilities : MonoBehaviour {

    public void SetGameObjectActive(GameObject obj) {
        obj.SetActive(true);
    }

    public void SetGameObjectActiveOff(GameObject obj) {
        obj.SetActive(false);
    }
}
