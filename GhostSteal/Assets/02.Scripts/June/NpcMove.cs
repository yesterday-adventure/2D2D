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
        StartCoroutine(MoveRight(leftPos));
    }

    IEnumerator MoveRight(Transform _leftpos, bool s = false)
    {
        transform.rotation = Quaternion.Euler(new Vector2(0, 180));
        while (transform.position.x > _leftpos.position.x)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        if(s)
        {
            _leftpos.GetComponent<Switch>().OnCCTV();
        }

        yield return StartCoroutine(MoveLeft(rightPos));
    }


    IEnumerator MoveLeft(Transform _rightpos, bool s = false)
    {
        transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        while (transform.position.x < _rightpos.position.x)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        if (s)
        {
            _rightpos.GetComponent<Switch>().OnCCTV();
        }

        yield return StartCoroutine(MoveRight(leftPos));
    }


    public void OnCCTV(Transform pos)
    {
        StopAllCoroutines();
        if (transform.position.x < pos.position.x)
            StartCoroutine(MoveLeft(pos,true));
        else
            StartCoroutine(MoveRight(pos,true));
    }
}
