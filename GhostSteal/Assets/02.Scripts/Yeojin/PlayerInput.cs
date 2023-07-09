using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float distance = 3f;
    
    private bool isMove;
    private bool isEnemy;

    private SpriteRenderer sr;
    private PlayerAnimator animator;

    [SerializeField] private LayerMask targetLayer;
    private Transform target;

    private void Awake()
    {
        sr = transform.Find("Visual").GetComponent<SpriteRenderer>();
        animator = transform.Find("Visual").GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isEnemy)
        {
            PlayerAnimator targetAnim = target.transform.Find("Visual").GetComponent<PlayerAnimator>();
            targetAnim.SetStolen();
        }

        CheckEnemy();
        Move();
    }

    private void CheckEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, distance, targetLayer);
        foreach (Collider2D enemy in enemies)
        {
            Debug.Log("Enemy °¨Áö");
            target = enemy.transform;
            isEnemy = true;
        }
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

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
#endif
}
