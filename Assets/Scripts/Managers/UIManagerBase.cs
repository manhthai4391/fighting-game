using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[DisallowMultipleComponent]
public class UIManagerBase : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("healths")]
    protected Health[] Healths;
    // Start is called before the first frame update
    private void Start()
    {
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
