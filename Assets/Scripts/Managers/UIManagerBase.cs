using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class UIManagerBase : MonoBehaviour
{
    public static UIManagerBase instance;

    [SerializeField]
    protected Health[] healths;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) 
        {
            instance = this;
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
