using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    // All available scenes
    public enum Scene
    {
        LoadingScene,
        WorkingScene,
        ManagingScene,
        InterviewScene,
        MainMenuScene,
        EndGameScene,
    }

    // Dummy class
    private class LoadingMonoBehaviour : MonoBehaviour { }

    private static Action s_onLoaderCallback;

    private static AsyncOperation s_asyncOperation;

    public static void Load(Scene scene)
    {
        // Set the loader callback action to load the target scene
        s_onLoaderCallback = () =>
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
        return s_asyncOperation?.progress ?? 1f;
    }

    public static void LoadCallback()
    {
        // This will run only once!
        // It will run the loading of target scene
        if (s_onLoaderCallback == null) return;
        
        s_onLoaderCallback();
        s_onLoaderCallback = null;
    }
}
