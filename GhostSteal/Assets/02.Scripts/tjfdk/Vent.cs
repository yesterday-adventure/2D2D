using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : Item
{
    [SerializeField] private Transform otherVent;

    public override void item(GameObject target)
    {
        if(otherVent == null)
        {
            Debug.LogError($"{transform} : Vent Script otherVent is null!");
        }

        target.transform.position = new Vector3(otherVent.position.x,
            target.transform.position.y - transform.position.y + otherVent.position.y, 
            target.transform.position.z);
    }
}