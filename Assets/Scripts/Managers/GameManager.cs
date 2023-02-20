using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    Character[] characters;

    public UnityEvent onGameOverEvent; 

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
            if(!character.IsDead)
            {
                character.Win();
            }
            character.onCharacterDieEvent -= GameOver;
        }
        onGameOverEvent?.Invoke();
    }
}
