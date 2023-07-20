using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item
{
    bool isPot = false;

    public override void item(GameObject target) {
        
        if (isPot) {

            transform.SetParent(null);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else {

            target.transform.position = transform.position;
            transform.SetParent(target.transform);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        isPot = !isPot;

        target.GetComponent<Move>().pot = !target.GetComponent<Move>().pot;
        target.GetComponent<SpriteRenderer>().enabled = !target.GetComponent<SpriteRenderer>().enabled;
    }
}
