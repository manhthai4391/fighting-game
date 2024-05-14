using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSelectResponse : MonoBehaviour
{
    [SerializeField]
    private int playerIndex = 0;

    [SerializeField]
    private CharacterData[] characters;

    private const string selectedCharacterPlayerPrefKey = "SELECTED_CHARACTER_PLAYER_";

    private void Awake()
    {
        string key = selectedCharacterPlayerPrefKey + playerIndex;
        //int selectedCharacterID = PlayerPrefs.GetInt(key, 0);
        int selectedCharacterID = 0;

        for (int i = 0; i < characters.Length; i++)
        {
            if(i != selectedCharacterID)
            {
                Destroy(characters[i].CharacterGraphic);
                Destroy(characters[i].CharacterSkeleton);
            }
            else
            {
                characters[i].CharacterGraphic.SetActive(true);
                characters[i].CharacterSkeleton.SetActive(true);
            }
        }

        Animator animator = GetComponent<Animator>();
        animator.avatar = characters[selectedCharacterID].CharacterAvatar;
        StartCoroutine(Rebinding(animator));
    }

    private IEnumerator Rebinding(Animator animator)
    {
        yield return new WaitForSeconds(0.1f);
        animator.Update(0);
        animator.Rebind();
    }
}

[System.Serializable]
public struct CharacterData
{
    public Avatar CharacterAvatar;
    public GameObject CharacterGraphic;
    public GameObject CharacterSkeleton;
}
