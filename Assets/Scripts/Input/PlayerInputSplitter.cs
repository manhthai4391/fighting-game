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

        if(GameManager.Instance.Characters != null && GameManager.Instance.Characters.Length > 0)
        {
            inputReaders = new IInputReader[GameManager.Instance.Characters.Length];
            for(int i = 0; i < GameManager.Instance.Characters.Length; i++)
            {
                inputReaders[i] = GameManager.Instance.Characters[i].GetComponent<IInputReader>();
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
