using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private bool isMove = false;
    private bool isRun = false; // �ʱ⿡�� false
    private bool isAttack = false; // �ʱ⿡�� false

    private SpriteRenderer sr;
    private PlayerAnimator animator;

    private void Awake()
    {
        sr = transform.Find("Visual").GetComponent<SpriteRenderer>();
        animator = transform.Find("Visual").GetComponent<PlayerAnimator>();

        isRun = false; // �ʱ�ȭ
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && !isAttack) // ����׿�
        {
            //isAttack = true;
            //StartCoroutine(Climbing());
            //StartCoroutine(Attacking());
            //animator.SetDie();
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Debug��, Ű �ٲ㵵 ��
        {
            isRun = !isRun;
        }

        if (isAttack) return; // ���� ���� �� �������� �ʵ���, ���� ����
        Move();
    }

    private IEnumerator Attacking() // ���� ����
    {
        animator.SetAttack(true);
        yield return new WaitForSeconds(0.6f);
        animator.SetAttack(false);
        isAttack = false;
    }

    private IEnumerator Climbing() // ���� ����
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

        float currentSpeed = isRun ? speed * 2 : speed; // �޸��� �ӵ�: �� �ӵ��� �� ��� ����
        transform.position += Vector3.right * h * Time.deltaTime * currentSpeed;
    }
}
