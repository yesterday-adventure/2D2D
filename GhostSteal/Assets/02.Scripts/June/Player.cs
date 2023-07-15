using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(x, 0) * Time.deltaTime;
    }
}
