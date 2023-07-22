using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("X", GameManager.Instance.player.transform.position.x);
            PlayerPrefs.SetFloat("Y", GameManager.Instance.player.transform.position.y);
        }
    }
}