using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isMove = false;

    [SerializeField] private float moveDistance; // 버튼의 이동 거리
    [SerializeField] private float time = 0.5f;     // 애니 지속시간

    private float originPosX;       // 처음 위치
    private float targetPosX;       // 이동할 위치

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

        if (isMove) // true이면
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

        if (!isMove) // false이면
        {
            targetPosX = originPosX;
        }

        StopAllCoroutines();
        StartCoroutine(MoveCoroutine());
    }
}
