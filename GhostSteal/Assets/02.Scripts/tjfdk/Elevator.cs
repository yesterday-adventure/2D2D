using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Item
{
    [SerializeField] private GameObject distination;

    public override void item(GameObject target) {

        Anim();
        Invoke("Anim", 1f);

        target.transform.position = distination.transform.position;
    }
}
