using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("Walking");
    private readonly int isRun = Animator.StringToHash("Running");
    private readonly int isSteal = Animator.StringToHash("Die"); // 에너미만

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

    public void SetDie()
    {
        animator.SetTrigger(isSteal);
    }
}
