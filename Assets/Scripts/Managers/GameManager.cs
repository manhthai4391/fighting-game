using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [FormerlySerializedAs("characters")]
    public Character[] Characters;

    [FormerlySerializedAs("onGameOverEvent")]
    public UnityEvent OnGameOverEvent; 

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

        foreach(Character character in Characters)
        {
            character.OnCharacterDieEvent += GameOver;
        }
    }

    private void GameOver()
    {
        foreach(Character character in Characters)
        {
            if(!character.IsDead)
            {
                character.Win();
            }
            character.OnCharacterDieEvent -= GameOver;
        }
        OnGameOverEvent?.Invoke();
    }
}
