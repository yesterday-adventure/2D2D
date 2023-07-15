using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject distination;
    private GameObject itemAnim;

    public void elevator() {

        StartCoroutine(anim());
                
        //player.transform.position = distination.transform.position;
    }

    IEnumerator anim() {

        itemAnim.SetActive(true);
        yield return new WaitForSeconds(1f);
        itemAnim.SetActive(false);
    }
}
