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

    [SerializeField] private AudioSource touchSound;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        originPosX = myTransform.anchoredPosition.x;
        targetPosX = originPosX;
    }

    IEnumerator MoveCoroutine()
    {
        touchSound.Play();

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
        StartCoroutine(MoveCoroutine());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMove = !isMove;

        if (!isMove) // false�̸�
        {
            targetPosX = originPosX;
        }

        StopAllCoroutines();
        StartCoroutine(MoveCoroutine());
    }
}
