using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    GameObject _player;

    void Update()
    {
        transform.position = new Vector3(GameManager.Instance.player.transform.position.x,transform.position.y,-10);
    }
}
