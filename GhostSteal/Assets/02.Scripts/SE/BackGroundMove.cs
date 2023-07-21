using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField]
    private GameObject[] moves = new GameObject[2];
    [SerializeField]
    private float speed = 3f;

    private void Update()
    {
        foreach (var move in moves)
        {
            move.transform.position += Vector3.left * speed * Time.deltaTime;

            if (move.transform.position.x <= -12)
            {
                move.transform.position = new Vector2(12, move.transform.position.y);
            }
        }
    }
}
