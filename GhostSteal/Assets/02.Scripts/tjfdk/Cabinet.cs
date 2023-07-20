using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Item
{
    private Move player;
    SpriteRenderer s;
    PolygonCollider2D c;

    private void Awake() {
        
        player = GameObject.Find("Player").GetComponent<Move>();
        s = player.GetComponent<SpriteRenderer>();
        c = player.GetComponent<PolygonCollider2D>();
    }
    public override void item() {

        player.canMove = !player.canMove;
        s.enabled = !s.enabled;
        c.enabled = !c.enabled;
    }
}
