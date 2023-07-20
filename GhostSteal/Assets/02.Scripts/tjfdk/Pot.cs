using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item
{
    bool isPot = false;

    public override void item(GameObject target) {
        
        if (isPot)
            transform.SetParent(null);
        else
            transform.SetParent(target.transform);

        isPot = !isPot;

        target.GetComponent<Move>().pot = !target.GetComponent<Move>().pot;
        target.GetComponent<SpriteRenderer>().enabled = !target.GetComponent<SpriteRenderer>().enabled;
    }
}
