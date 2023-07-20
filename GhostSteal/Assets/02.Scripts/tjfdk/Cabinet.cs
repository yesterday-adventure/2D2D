using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Item
{
    // SpriteRenderer s;
    // PolygonCollider2D c;

    // private void Awake() {
        
    //     player = GameObject.Find("Player").GetComponent<Move>();
    //     s = player.GetComponent<SpriteRenderer>();
    //     c = player.GetComponent<PolygonCollider2D>();
    // }
    public override void item(GameObject target) {

        // target.canMove = !target.canMove;
        // s.enabled = !s.enabled;
        target.GetComponent<SpriteRenderer>().enabled = !target.GetComponent<SpriteRenderer>().enabled;
        target.GetComponent<PolygonCollider2D>().enabled = !target.GetComponent<PolygonCollider2D>().enabled; //missing
    }
}
