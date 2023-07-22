using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item
{
    bool isPot = false;

    public override void item(GameObject target) {
        
        SoundManager.instance.PlaySE("MP_Blop");

        if (isPot)
        {
            transform.SetParent(null);
            Move.Instance.curItem = null;
        }
        else
        {
            target.transform.position = new Vector3(transform.position.x, target.transform.position.y, target.transform.position.z);
            transform.SetParent(target.transform);
        }

        isPot = !isPot;
        GameManager.Instance.isPot = isPot;
        target.GetComponent<Move>().pot = !target.GetComponent<Move>().pot;
        target.GetComponentInChildren<SpriteRenderer>().enabled = !target.GetComponentInChildren<SpriteRenderer>().enabled;
    }
}
