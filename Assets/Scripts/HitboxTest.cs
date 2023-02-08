using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxTest : MonoBehaviour
{
    [SerializeField]
    GameObject hitBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnableHitBox() 
    {
        hitBox.SetActive(true);
        Invoke(nameof(DisableHitBox), 0.2f);
    }

    void DisableHitBox()
    {
        hitBox.SetActive(false);
    }
}
