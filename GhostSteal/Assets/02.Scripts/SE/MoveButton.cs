using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isMove = false;

    [SerializeField] private float moveDistance; // ��ư�� �̵� �Ÿ�
    [SerializeField] private float time = 0.5f;     // �ִ� ���ӽð�

    private float originPosX;       // ó�� ��ġ
    private float targetPosX;       // �̵��� ��ġ

    private RectTransform myTransform;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        originPosX = myTransform.anchoredPosition.x;
        targetPosX = originPosX;
    }

    // �ε巯�� �ɱ�
    IEnumerator CrouchCoroutine()
    {
        float currentPosX = myTransform.anchoredPosition.x;

        myTransform.DOAnchorPosX(targetPosX, time).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(time);

        currentPosX = myTransform.anchoredPosition.x;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMove = !isMove;

        if (isMove) // true�̸�
        {
            targetPosX = originPosX - moveDistance;
            //Debug.Log(targetPosX);
        }

        StopAllCoroutines();
        StartCoroutine(CrouchCoroutine());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMove = !isMove;

        if (!isMove) // false�̸�
        {
            targetPosX = originPosX;
        }

        StopAllCoroutines();
        StartCoroutine(CrouchCoroutine());
    }
}
