using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Item
{
    public void cavinet(GameObject target) {

        target.SetActive(!target.activeSelf);
        // 못 움직이게
    }

    public override void item() {

        base.item();
        Debug.Log("캐비닛 시발");
    }
}
