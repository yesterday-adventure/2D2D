using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Item
{
    public override void item(GameObject target) {

        transform.SetParent(target.transform);
        // 위치 살짝 조정?
    }
}
