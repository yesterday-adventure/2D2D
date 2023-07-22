using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (!GameManager.Instance.isPot || collision.GetComponent<PlayerInput>().MoveVal != 0))
        {
            GameManager.Instance.GameOver();
        }
    }
}
