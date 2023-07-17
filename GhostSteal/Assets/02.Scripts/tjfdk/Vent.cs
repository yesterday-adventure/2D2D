using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : Item
{
    [SerializeField] private List<GameObject> vents = new List<GameObject>();

    public override void item() {

        foreach (GameObject v in vents)
            v.SetActive(true);
    }
}
