using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    public void UpdateResult()
    {
        Character[] characters = FindObjectsOfType<Character>();
        if (characters[0].IsDead)
        {
            if (characters[0].gameObject.CompareTag("Player"))
            {
                //Player 1 is dead
                text.text = "Player 2 win!";
            }
            else
            {
                //Player 2 is dead
                text.text = "Player 1 win!";
            }
        }
        else if (characters[1].IsDead)
        {
            if (characters[1].gameObject.CompareTag("Player"))
            {
                //Player 1 is dead
                text.text = "Player 2 win!";
            }
            else
            {
                //Player 2 is dead
                text.text = "Player 1 win!";
            }
        }
    }
}
