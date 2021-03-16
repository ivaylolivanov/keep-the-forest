using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] float splashScreenDisplayTime = 3f;

    private int currentSceneIndex = 0;
    void Start () {
        GetCurrentSceneIndex();

        if (currentSceneIndex == 0) {
            StartCoroutine(StartMenuSceneDelayed());
        }
    }

    public void LoadCurrentScene() {
        Time.timeScale = 1;

        GetCurrentSceneIndex();
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene() {
        GetCurrentSceneIndex();
        SceneManager.LoadScene(++currentSceneIndex);
    }

    public void LoadMainMenuScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScreen");
    }

    public void LoadOptionsScene() {
        SceneManager.LoadScene("OptionsScreen");
    }

    public void Quit() {
        Application.Quit();
    }

    private IEnumerator StartMenuSceneDelayed() {
        yield return new WaitForSeconds(splashScreenDisplayTime);
        LoadMainMenuScene();
    }

    private void GetCurrentSceneIndex() {
        Scene scene = SceneManager.GetActiveScene();
        currentSceneIndex = scene.buildIndex;
    }
}
