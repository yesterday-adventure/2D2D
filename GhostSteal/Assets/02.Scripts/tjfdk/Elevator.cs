using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject distination;
    private GameObject itemAnim;

    private void Awake() {
        
        itemAnim = gameObject.transform.GetChild(0).GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {

            
        }
    }

    public void elevator(GameObject target) {

        StartCoroutine(anim());
                
        target.transform.position = distination.transform.position;
        //player.transform.position = distination.transform.position;
    }

    IEnumerator anim() {

        itemAnim.SetActive(true);
        yield return new WaitForSeconds(1f);
        itemAnim.SetActive(false);
    }
}
