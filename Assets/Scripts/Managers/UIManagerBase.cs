using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[DisallowMultipleComponent]
public class UIManagerBase : MonoBehaviour
{
    public static UIManagerBase Instance;

    [SerializeField]
    [FormerlySerializedAs("healths")]
    protected Health[] Healths;
    // Start is called before the first frame update
    private void Start()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        RegisterHealthSliderChangeEvent();
    }

    public virtual void RegisterHealthSliderChangeEvent()
    {
        
    }

    public virtual void UnregisterHealthSliderChangeEvent()
    {

    }

    private void OnDestroy()
    {
        UnregisterHealthSliderChangeEvent();
    }
}
