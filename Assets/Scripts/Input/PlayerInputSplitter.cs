using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSplitter : MonoBehaviour
{
    public InputActionAsset InputActionAsset;

    public IInputReader[] inputReaders;

    public string actionMapName = "Gameplay";

    private void Start()
    {
        InputActionAsset.Enable();
        InputActionMap actionMap = InputActionAsset.FindActionMap(actionMapName);

        if(GameManager.Instance.characters != null && GameManager.Instance.characters.Length > 0)
        {
            inputReaders = new IInputReader[GameManager.Instance.characters.Length];
            for(int i = 0; i < GameManager.Instance.characters.Length; i++)
            {
                inputReaders[i] = GameManager.Instance.characters[i].GetComponent<IInputReader>();
            }
        }
        for(int i = 0; i < inputReaders.Length; i++)
        {
            inputReaders[i].Initialize(actionMap, i);
        }
    }

    private void OnDestroy()
    {
        InputActionAsset.Disable();
    }
}
