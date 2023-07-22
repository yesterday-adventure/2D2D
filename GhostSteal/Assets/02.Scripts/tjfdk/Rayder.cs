using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayder : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.CompareTag("Player"))
        {
            if (other.transform.childCount != 1) {

                Destroy(other.transform.GetChild(1).gameObject);
                other.transform.GetComponentInChildren<SpriteRenderer>().enabled = true;
                other.transform.GetComponent<BoxCollider2D>().enabled = true;
            }
            Move.Instance.curItem = null;
            Move.Instance.pot = false;
            GameManager.Instance.isPot = false;
            GameManager.Instance.isLight = true;
        }
    }
}
