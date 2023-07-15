using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float distance = 3f;

    private bool isMove;
    private bool isRun;

    private SpriteRenderer sr;
    private PlayerAnimator animator;

    private void Awake()
    {
        sr = transform.Find("Visual").GetComponent<SpriteRenderer>();
        animator = transform.Find("Visual").GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Debug
        {
            isRun = !isRun;
        }
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        bool checkMoving = h != 0;
        isMove = checkMoving;
        if (h != 0) sr.flipX = (h < 0);

        if (!checkMoving)
        {
            animator.SetMove(checkMoving);
            animator.SetRun(checkMoving);
        }
        else
        {
            animator.SetMove(isMove);
            animator.SetRun(isRun);
        }

        float currentSpeed = isRun ? speed * 2 : speed; // 달리는 속도 두 배
        transform.position += Vector3.right * h * Time.deltaTime * currentSpeed;
    }
}
