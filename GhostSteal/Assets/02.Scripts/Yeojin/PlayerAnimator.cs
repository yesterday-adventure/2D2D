using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("Walking");
    private readonly int isRun = Animator.StringToHash("Running");
    private readonly int isClimb = Animator.StringToHash("Climbing");
    private readonly int isAttack = Animator.StringToHash("Attacking");

    private readonly int isSteal = Animator.StringToHash("Die"); // ���ʹ̸�

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();  
    }

    public void SetMove(bool value)
    {
        animator.SetBool(isMove, value);
    }

    public void SetRun(bool value)
    {
        animator.SetBool(isRun, value);
    }

    public void SetClimb(bool value)
    {
        animator.SetBool(isClimb, value); // ��Ʈ Ÿ�� �� true, �� ������ false �����ֱ�
    }

    public void SetAttack(bool value)
    {
        animator.SetBool(isAttack, value);
    }

    public void SetDie() // ���ΰ� ���XXX!!
    {
        animator.SetTrigger(isSteal);
    }
}
