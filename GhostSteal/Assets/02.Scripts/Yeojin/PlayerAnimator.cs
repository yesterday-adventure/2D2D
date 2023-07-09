using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("Walking");
    private readonly int isSteal = Animator.StringToHash("Stolen"); // ¸ö »¯±ä °Å

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();  
    }

    public void SetMove(bool value)
    {
        animator.SetBool(isMove, value);
    }

    public void SetStolen()
    {
        animator.SetTrigger(isSteal);
    }
}
