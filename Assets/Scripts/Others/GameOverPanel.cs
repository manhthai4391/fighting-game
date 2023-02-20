using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    int sceneIndex = 0;

    [SerializeField]
    GameObject gameObjectToEnable;

    [SerializeField]
    float showUpDelay = 2f;

    [SerializeField]
    ResultText resultText;

    public void ShowUp()
    {
        Invoke(nameof(ShowUpPanel), showUpDelay);
    }

    void ShowUpPanel()
    {
        gameObjectToEnable.SetActive(true);
    }
 
    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
