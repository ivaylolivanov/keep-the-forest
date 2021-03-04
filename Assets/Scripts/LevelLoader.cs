using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] float splashScreenDisplayTime = 3f;

    private int currentSceneIndex = 0;
    void Start () {
        Scene scene = SceneManager.GetActiveScene();
        currentSceneIndex = scene.buildIndex;

        if (currentSceneIndex == 0) {
            StartCoroutine(StartMenuSceneDelayed());
        }
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(++currentSceneIndex);
    }

    private IEnumerator StartMenuSceneDelayed() {
        yield return new WaitForSeconds(splashScreenDisplayTime);
        LoadNextScene();
    }
}
