using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Item
{
    [SerializeField] private List<CCTV> cctvs = new List<CCTV>();

    public override void item() {

        Anim();

        foreach (CCTV c in cctvs)
            c.item();
    }
}
