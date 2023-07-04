using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
    [SerializeField]
    private int sceneID;

    public UnityEvent<float> onSceneLoading;

    public void StartLoadingSceneAsync()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneID);
        sceneLoadingOperation.allowSceneActivation = false;
        while (!sceneLoadingOperation.isDone)
        {
            if (sceneLoadingOperation.progress >= 0.9f)
            {
                sceneLoadingOperation.allowSceneActivation = true;
            }
            else
            {
                onSceneLoading?.Invoke(sceneLoadingOperation.progress);
            }
            yield return null;
        }
    }
}
