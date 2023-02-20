using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadPlayScene : MonoBehaviour
{
    [SerializeField]
    private int sceneID = 1;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneID);
    }
}
