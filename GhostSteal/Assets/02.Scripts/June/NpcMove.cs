using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    [Header("위치")]
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;

    [Header("정보")]
    [SerializeField] float speed = 0.1f;

    private void Awake()
    {
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        transform.rotation = Quaternion.Euler(new Vector2(0, 180));
        while (transform.position.x > leftPos.position.x)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        yield return StartCoroutine(MoveLeft());
    }


    IEnumerator MoveLeft()
    {
        transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        while (transform.position.x < rightPos.position.x)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        yield return StartCoroutine(MoveRight());
    }
}
