using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item
{
    public override void item(GameObject target) {

        transform.SetParent(target.transform);
    }
}
