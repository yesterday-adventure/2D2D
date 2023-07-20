using System.Runtime.InteropServices;
using System.IO.IsolatedStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Item
{
    bool isTile = false;

    public override void item(GameObject target) {

        isTile = !isTile;

        if (isTile) {

            transform.SetParent(null);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else {
            
            transform.SetParent(target.transform);
            // transform.position = Vector3.zero; // 위치 머리 위로 해주고 싶은데 왜 안 될까 ㅎㅎ;
            // transform.position = new Vector2(0, 0.7f);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        // 위치 살짝 조정?
    }
}
