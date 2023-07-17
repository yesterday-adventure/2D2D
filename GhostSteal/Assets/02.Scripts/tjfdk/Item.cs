using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isOn;
    protected GameObject itemAnim;

    private void Awake() {
        
        itemAnim = transform.GetChild(0).GetComponent<GameObject>();
    }

    public virtual void item() {

        
    }
}
