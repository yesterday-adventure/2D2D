using System.IO.MemoryMappedFiles;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Item
{
    private bool isUsed = false;
    public override void item(GameObject target) 
    {
        isUsed = !isUsed;

        if (!isUsed)
            Move.Instance.curItem = null;
        GameManager.Instance.isLight = !GameManager.Instance.isLight;
        target.GetComponent<Move>().canMove = !target.GetComponent<Move>().canMove;
        target.GetComponentInChildren<SpriteRenderer>().enabled = !target.GetComponentInChildren<SpriteRenderer>().enabled;
        target.GetComponent<BoxCollider2D>().enabled = !target.GetComponent<BoxCollider2D>().enabled; //missing
    }
}
