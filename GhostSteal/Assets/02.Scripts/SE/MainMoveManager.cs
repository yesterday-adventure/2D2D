using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMoveManager : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnim, thinkingAnim;
    [SerializeField]
    private GameObject showMoney;
    [SerializeField]
    private Image panel;

    private readonly int isJump = Animator.StringToHash("Jump");
    private readonly int isIdle = Animator.StringToHash("Idle");
    private readonly int isRun = Animator.StringToHash("Run");
    private readonly int isMoveStart = Animator.StringToHash("MoveStart");

    private void Start()
    {
        thinkingAnim.SetBool(isMoveStart, true);
        panel.DOFade(0, 1.5f);
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1.5f);
        showMoney.transform.DOMove(new Vector3(3, -2.215f, 0), 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.5f);
        playerAnim.SetBool(isIdle, true);

        yield return new WaitForSeconds(0.5f);
        thinkingAnim.SetBool(isJump, true);
        playerAnim.SetBool(isJump, true);
        yield return new WaitForSeconds(.5f);
        playerAnim.SetBool(isJump, false);
        thinkingAnim.SetBool(isJump, false);
        yield return new WaitForSeconds(1.5f);
        playerAnim.SetBool(isRun, true);
        thinkingAnim.SetBool(isMoveStart, false);
        showMoney.transform.DOMove(new Vector3(-11, -2.215f, 0), 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.5f);
        panel.DOFade(1, 1.5f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Intro");
    }
}
