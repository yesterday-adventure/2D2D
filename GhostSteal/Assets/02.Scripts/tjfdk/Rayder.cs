using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Player"))
        {
            if (other.transform.childCount != 0) {

                Destroy(other.transform.GetChild(0).gameObject);
                other.transform.GetComponent<SpriteRenderer>().enabled = true;
                other.transform.GetComponent<PolygonCollider2D>().enabled = true;
            }
            Move.Instance.curItem = null;
        }
    }
}
