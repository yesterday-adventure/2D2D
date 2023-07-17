using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item
{
    private GameObject player;

    private void Awake() {
        
        player = GameObject.Find("Player");
    }
    public override void item() {

        transform.SetParent(player.transform);
    }
}
