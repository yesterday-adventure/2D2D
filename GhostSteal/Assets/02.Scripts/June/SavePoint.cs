using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.resetPos = new Vector3(transform.position.x, 
                collision.transform.position.y, collision.transform.position.z);
        }
    }
}