using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ResultText : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("text")]
    private TextMeshProUGUI _text;

    public void UpdateResult()
    {
        Character[] characters = GameManager.Instance.Characters;
        if (characters[0].IsDead)
        {
            if (characters[0].gameObject.CompareTag("Player"))
            {
                //Player 1 is dead
                _text.text = "Player 2 win!";
            }
            else
            {
                //Player 2 is dead
                _text.text = "Player 1 win!";
            }
        }
        else if (characters[1].IsDead)
        {
            if (characters[1].gameObject.CompareTag("Player"))
            {
                //Player 1 is dead
                _text.text = "Player 2 win!";
            }
            else
            {
                //Player 2 is dead
                _text.text = "Player 1 win!";
            }
        }
    }
}
