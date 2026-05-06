using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSplitter : MonoBehaviour
{
    public InputActionAsset InputActionAsset;

    public string actionMapName = "Gameplay";

    [SerializeField]
    private Character[] _characters;

    private void Start()
    {
        InputActionAsset.Enable();
        InputActionMap actionMap = InputActionAsset.FindActionMap(actionMapName);

        IInputReader[] inputReaders;

        if(_characters != null && _characters.Length > 0)
        {
            inputReaders = new IInputReader[_characters.Length];
            for(int i = 0; i < _characters.Length; i++)
            {
                inputReaders[i] = _characters[i].GetComponent<IInputReader>();
                inputReaders[i].Initialize(actionMap, i);
            }
        }
    }

    private void OnDestroy()
    {
        InputActionAsset.Disable();
    }
}
