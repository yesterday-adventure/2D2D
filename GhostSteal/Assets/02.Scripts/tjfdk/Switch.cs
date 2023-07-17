using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Item
{
    private void Awake() {
        
        itemAnim = GetComponentInChildren<GameObject>();
    }

    public void switchh() {

        itemAnim.SetActive(!itemAnim.activeSelf);

        isOn = !isOn;
    }

    public override void item() {

        base.item();
    }
}
