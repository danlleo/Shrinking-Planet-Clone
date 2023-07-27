using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    // Dummy class
    private class LoadingMonoBehaviour : MonoBehaviour { }

    // All available scenes
    public enum Scene
    {
        LoadingScene,
        WorkingScene,
        ManagingScene,
        InterviewScene,
        MainMenuScene
    }

    private static Action _onLoaderCallback;

    private static AsyncOperation _asyncOperation;

    public static void Load(Scene scene)
    {
        // Set the loader callback action to load the target scene
        _onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading GameObject");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if (_asyncOperation != null)
        {
            return _asyncOperation.progress;
        }

        return 1f;
    }

    public static void LoadCallback()
    {
        // This will run only once!
        // It will run the loading of target scene
        if (_onLoaderCallback != null)
        {
            _onLoaderCallback();
            _onLoaderCallback = null;
        }
    }
}
