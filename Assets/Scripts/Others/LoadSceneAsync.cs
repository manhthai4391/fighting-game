using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LoadSceneAsync : MonoBehaviour
{
    [FormerlySerializedAs("sceneID")]
    [SerializeField]
    private int _sceneID;

    [FormerlySerializedAs("onSceneLoading")]
    public UnityEvent<float> OnSceneLoading;

    public void StartLoadingSceneAsync()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(_sceneID);
        sceneLoadingOperation.allowSceneActivation = false;
        while (!sceneLoadingOperation.isDone)
        {
            if (sceneLoadingOperation.progress >= 0.9f)
            {
                sceneLoadingOperation.allowSceneActivation = true;
            }
            else
            {
                OnSceneLoading?.Invoke(sceneLoadingOperation.progress);
            }
            yield return null;
        }
    }
}
