using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isMove = false;

    [SerializeField] private float moveDistance; // 버튼의 이동 거리

    private float originPosX;       // 처음 위치
    private float targetPosX;       // 이동할 위치

    private RectTransform myTransform;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        originPosX = myTransform.anchoredPosition.x;
        targetPosX = originPosX;
    }

    // 부드러운 앉기
    IEnumerator CrouchCoroutine()
    {
        float currentPosX = myTransform.anchoredPosition.x;

        // 이동할 위치와 현재 위치가 다를 때까지 반복
        while (Mathf.Abs(currentPosX - targetPosX) > 0.01f)
        {
            float duration = 0.5f; // 애니메이션의 지속 시간
            myTransform.DOAnchorPosX(targetPosX, duration).SetEase(Ease.OutCubic);
            yield return new WaitForSeconds(duration);

            currentPosX = myTransform.anchoredPosition.x;
        }

        Debug.Log("애니메이션 재생중하고 끝남");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("마우스 들어옴");

        isMove = !isMove;

        if (isMove) // true이면
        {
            targetPosX = originPosX - moveDistance;
            Debug.Log(targetPosX);
        }

        StopAllCoroutines();
        StartCoroutine(CrouchCoroutine());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("마우스 나감");

        isMove = !isMove;

        if (!isMove) // false이면
        {
            targetPosX = originPosX;
        }

        StopAllCoroutines();
        StartCoroutine(CrouchCoroutine());
    }
}
