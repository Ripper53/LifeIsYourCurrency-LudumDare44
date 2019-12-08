﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void Quit() {
        Application.Quit();
    }
}
