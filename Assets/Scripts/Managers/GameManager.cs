using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [FormerlySerializedAs("characters")]
    public Character[] Characters;

    [FormerlySerializedAs("onGameOverEvent")]
    public UnityEvent OnGameOverEvent; 

    private void Start()
    {
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
