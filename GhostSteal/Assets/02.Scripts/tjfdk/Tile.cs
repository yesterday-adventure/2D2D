using System.IO.IsolatedStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Item
{
    bool isTile = false;

    public override void item(GameObject target) {

        isTile = !isTile;

        if (!isTile)
        {
            transform.SetParent(null);
            transform.position = new Vector3(target.transform.position.x,transform.position.y - 1f,transform.position.z);
            GameManager.Instance.isLight = true;
        }
        else
        {
            transform.SetParent(target.transform);
            transform.position = new Vector3(target.transform.position.x,transform.position.y + 1f,transform.position.z);
            GameManager.Instance.isLight = false;
        }
    }
}
