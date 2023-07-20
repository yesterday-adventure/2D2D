using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isOn = true;
    [SerializeField] protected GameObject itemAnim;

    public virtual void item(GameObject target) { // 필수 

        // 공통으로 들어가는 게 뭐가 있을까
    }

    protected void Anim() {

        itemAnim.SetActive(!itemAnim.activeSelf);
    }
}
