using System.IO.IsolatedStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Item
{
    bool isTile = false;

    public override void item(GameObject target) {

        isTile = !isTile;

        if (isTile)
            transform.SetParent(null);
        else
            transform.SetParent(target.transform);
        // 위치 살짝 조정?
    }
}
