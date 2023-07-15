using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private bool isMove = false;
    private bool isRun = false; // 초기에는 false
    private bool isAttack = false; // 초기에는 false

    private SpriteRenderer sr;
    private PlayerAnimator animator;

    private void Awake()
    {
        sr = transform.Find("Visual").GetComponent<SpriteRenderer>();
        animator = transform.Find("Visual").GetComponent<PlayerAnimator>();

        isRun = false; // 초기화
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && !isAttack) // 디버그용
        {
            //isAttack = true;
            //StartCoroutine(Climbing());
            //StartCoroutine(Attacking());
            //animator.SetDie();
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Debug용, 키 바꿔도 됨
        {
            isRun = !isRun;
        }

        if (isAttack) return; // 어택 중일 때 움직이지 않도록, 추후 삭제
        Move();
    }

    private IEnumerator Attacking() // 추후 삭제
    {
        animator.SetAttack(true);
        yield return new WaitForSeconds(0.6f);
        animator.SetAttack(false);
        isAttack = false;
    }

    private IEnumerator Climbing() // 추후 삭제
    {
        animator.SetClimb(true);
        yield return new WaitForSeconds(3f);
        animator.SetClimb(false);
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

        float currentSpeed = isRun ? speed * 2 : speed; // 달리는 속도: 원 속도의 두 배로 잡음
        transform.position += Vector3.right * h * Time.deltaTime * currentSpeed;
    }
}
