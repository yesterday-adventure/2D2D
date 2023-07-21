using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    GameObject _player;

    private void Start()
    {
        _player = GameManager.Instance.player;
    }
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x,transform.position.y,-10);
    }
}
