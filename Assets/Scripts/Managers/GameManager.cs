using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    Character[] characters;

    [SerializeField]
    SlowMotion slowMo;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Character character in characters)
        {
            character.onCharacterDieEvent += GameOver;
        }
    }

    void GameOver()
    {
        foreach(Character character in characters)
        {
            Debug.Log(character.IsDead);
            if(!character.IsDead)
            {
                character.Win();
            }
            character.onCharacterDieEvent -= GameOver;
        }

        slowMo.StartSlowMotion();
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
