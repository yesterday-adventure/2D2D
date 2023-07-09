using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private bool isMove;

    private SpriteRenderer sr;
    private PlayerAnimator animator;

    private void Awake()
    {
        sr = transform.Find("Visual").GetComponent<SpriteRenderer>();
        animator = transform.Find("Visual").GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        if (h < 0)
        {
            isMove = true;
            sr.flipX = true;
        }
        else if (h > 0)
        {
            isMove = true;
            sr.flipX = false;
        }
        else
        {
            isMove = false;
        }
        animator.SetMove(isMove);
        transform.position += new Vector3(h ,0, 0) * Time.deltaTime * speed;
    }
}
