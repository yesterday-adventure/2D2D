using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("Walking");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();  
    }

    public void SetMove(bool value)
    {
        animator.SetBool(isMove, value);
    }
}
