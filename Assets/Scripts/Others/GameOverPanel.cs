using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("sceneIndex")]
    private int _sceneIndex = 0;

    [SerializeField]
    [FormerlySerializedAs("gameObjectToEnable")]
    private GameObject _gameObjectToEnable;

    [SerializeField]
    [FormerlySerializedAs("showUpDelay")]
    private float _showUpDelay = 2f;

    [SerializeField]
    [FormerlySerializedAs("resultText")]
    private ResultText _resultText;

    public void ShowUp()
    {
        Invoke(nameof(ShowUpPanel), _showUpDelay);
    }

    private void ShowUpPanel()
    {
        _gameObjectToEnable.SetActive(true);
    }
 
    public void ReloadScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
